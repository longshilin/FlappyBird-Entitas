using System.Collections.Generic;

namespace Entitas {

    /// 如果基于指定的收集器进行了更改，则ReactiveSystem会调用Execute(entities)，并且只会传递已更改的实体。
    /// 常见用例是对更改做出反应，例如实体位置的更改以更新相关gameObject的gameObject.transform.position。
    /// 其与ReactiveSystem的区别在于，MultiReactiveSystem中通过GetTrigger()拿到的是一个收集器组集合。
    public abstract class MultiReactiveSystem<TEntity, TContexts> : IReactiveSystem
        where TEntity : class, IEntity
        where TContexts : class, IContexts {

        readonly ICollector[] _collectors;
        readonly HashSet<TEntity> _collectedEntities;
        readonly List<TEntity> _buffer;
        string _toStringCache;

        protected MultiReactiveSystem(TContexts contexts) {
            _collectors = GetTrigger(contexts);
            _collectedEntities = new HashSet<TEntity>();
            _buffer = new List<TEntity>();
        }

        protected MultiReactiveSystem(ICollector[] collectors) {
            _collectors = collectors;
            _collectedEntities = new HashSet<TEntity>();
            _buffer = new List<TEntity>();
        }

        /// 指定将触发ReactiveSystem的收集器。
        protected abstract ICollector[] GetTrigger(TContexts contexts);

        /// 这将排除所有未通过过滤器的实体。
        protected abstract bool Filter(TEntity entity);

        protected abstract void Execute(List<TEntity> entities);

        /// 激活ReactiveSystem并开始观察基于指定收集器的更改。 
        /// 默认情况下，ReactiveSystem被激活。
        public void Activate() {
            for (int i = 0; i < _collectors.Length; i++) {
                _collectors[i].Activate();
            }
        }

        /// 停用ReactiveSystem。 
        /// 停用后不会跟踪任何更改。 
        /// 这还将清除ReactiveSystem。 
        /// 默认情况下，ReactiveSystem被激活。
        public void Deactivate() {
            for (int i = 0; i < _collectors.Length; i++) {
                _collectors[i].Deactivate();
            }
        }

        /// 清除所有累积的更改。
        public void Clear() {
            for (int i = 0; i < _collectors.Length; i++) {
                _collectors[i].ClearCollectedEntities();
            }
        }

        /// Will call Execute(entities) with changed entities
        /// if there are any. Otherwise it will not call Execute(entities).
        /// 如果有的话,将使用更改后的实体调用Execute(entities)。
        /// 否则，它将不会调用Execute(entities)。
        public void Execute() {
            for (int i = 0; i < _collectors.Length; i++) {
                var collector = _collectors[i];
                if (collector.count != 0) {
                    _collectedEntities.UnionWith(collector.GetCollectedEntities<TEntity>());
                    collector.ClearCollectedEntities();
                }
            }

            foreach (var e in _collectedEntities) {
                if (Filter(e)) {
                    e.Retain(this);
                    _buffer.Add(e);
                }
            }

            if (_buffer.Count != 0) {
                try {
                    Execute(_buffer);
                } finally {
                    for (int i = 0; i < _buffer.Count; i++) {
                        _buffer[i].Release(this);
                    }
                    _collectedEntities.Clear();
                    _buffer.Clear();
                }
            }
        }

        /// 重写ToString
        public override string ToString() {
            if (_toStringCache == null) {
                _toStringCache = "MultiReactiveSystem(" + GetType().Name + ")";
            }

            return _toStringCache;
        }

        /// 终结器（也称为析构函数）用于在垃圾回收器收集类实例时执行任何必要的最终清理操作。
        /// 此处在该对象垃圾回收的时候停用此ReactiveSystem。
        ~MultiReactiveSystem() {
            Deactivate();
        }
    }
}
