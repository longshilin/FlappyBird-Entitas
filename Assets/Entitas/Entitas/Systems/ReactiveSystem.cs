using System.Collections.Generic;

namespace Entitas {

    /// 如果基于指定收集器的实体进行了更改，则ReactiveSystem会调用Execute(entities)，并且只会传递更改后的实体。
    /// 一个常用的用例是对更新做出反应，例如更新实体位置，以更新相关gamObject的gameObject.transform.position。
    public abstract class ReactiveSystem<TEntity> : IReactiveSystem where TEntity : class, IEntity {

        readonly ICollector<TEntity> _collector;
        readonly List<TEntity> _buffer;
        string _toStringCache;

        /// ReactiveSystem构造函数，直接传递Context上下文，通过GetTrigger(context)来创建ReactiveSystem的收集器
        protected ReactiveSystem(IContext<TEntity> context) {
            _collector = GetTrigger(context);
            _buffer = new List<TEntity>();
        }

        /// ReactiveSystem构造函数，直接传递ReactiveSystem的收集器
        protected ReactiveSystem(ICollector<TEntity> collector) {
            _collector = collector;
            _buffer = new List<TEntity>();
        }

        /// 指定将触发ReactiveSystem的收集器。
        protected abstract ICollector<TEntity> GetTrigger(IContext<TEntity> context);

        /// 这将排除所有未通过过滤器的实体
        protected abstract bool Filter(TEntity entity);

        protected abstract void Execute(List<TEntity> entities);

        /// 激活ReactiveSystem并开始基于指定的收集器观察监听更改。默认情况下，ReactiveSystem被激活。
        public void Activate() {
            _collector.Activate();
        }

        /// 停用ReactiveSystem。停用后不会跟踪任何更改。这还将清除ReactiveSystem。默认情况下，ReactiveSystem是激活的。
        public void Deactivate() {
            _collector.Deactivate();
        }

        /// 清除所有积累的更改。
        public void Clear() {
            _collector.ClearCollectedEntities();
        }

        /// 如果收集器中存在实体的话，将使用更改后的实体调用Execute(entities)，否则它将不会调用Execute(entities)
        public void Execute() {
            if (_collector.count != 0) {
                foreach (var e in _collector.collectedEntities) {
                    if (Filter(e)) {
                        e.Retain(this);
                        _buffer.Add(e);
                    }
                }

                _collector.ClearCollectedEntities();

                if (_buffer.Count != 0) {
                    try {
                        Execute(_buffer);
                    } finally {
                        for (int i = 0; i < _buffer.Count; i++) {
                            _buffer[i].Release(this);
                        }
                        _buffer.Clear();
                    }
                }
            }
        }

        /// 重写ToString
        public override string ToString() {
            if (_toStringCache == null) {
                _toStringCache = "ReactiveSystem(" + GetType().Name + ")";
            }

            return _toStringCache;
        }

        /// 终结器（也称为析构函数）用于在垃圾回收器收集类实例时执行任何必要的最终清理操作。
        /// 此处在该对象垃圾回收的时候停用此ReactiveSystem。
        ~ReactiveSystem() {
            Deactivate();
        }
    }
}
