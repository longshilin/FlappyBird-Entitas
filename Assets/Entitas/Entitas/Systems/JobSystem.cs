using System;
using System.Threading;

namespace Entitas {

    /// JobSystem使用实体的子集调用Execute(entities)，并在指定数量的线程上分配工作负载。
    /// 在Entitas中编写多线程代码时，请勿使用诸如AddXyz()和ReplaceXyz()之类的生成方法。
    public abstract class JobSystem<TEntity> : IExecuteSystem where TEntity : class, IEntity {

        readonly IGroup<TEntity> _group;
        readonly int _threads;
        readonly Job<TEntity>[] _jobs;

        int _threadsRunning;

        protected JobSystem(IGroup<TEntity> group, int threads) {
            _group = group;
            _threads = threads;
            _jobs = new Job<TEntity>[threads];
            for (int i = 0; i < _jobs.Length; i++) {
                _jobs[i] = new Job<TEntity>();
            }
        }

        protected JobSystem(IGroup<TEntity> group) : this(group, Environment.ProcessorCount) {
        }

        public virtual void Execute() {
            _threadsRunning = _threads;
            var entities = _group.GetEntities();
            var remainder = entities.Length % _threads; // 残余部分：总的实体数和总的线程数取余
            var slice = entities.Length / _threads + (remainder == 0 ? 0 : 1); // 总的切片数，执行完所有的实体需要划分的时间切片
            for (int t = 0; t < _threads; t++) { // 将执行的方法任务按照时间切片排入每个线程队列中
                var from = t * slice;
                var to = from + slice;
                if (to > entities.Length) {
                    to = entities.Length;
                }

                var job = _jobs[t];
                job.Set(entities, from, to);
                if (from != to) {
                    ThreadPool.QueueUserWorkItem(queueOnThread, _jobs[t]);
                } else {
                    Interlocked.Decrement(ref _threadsRunning);
                }
            }

            while (_threadsRunning != 0) {
            }

            foreach (var job in _jobs) {
                if (job.exception != null) {
                    throw job.exception;
                }
            }
        }

        /// 此方法在所在的线程池线程变得可用时，按照时间切片中的job任务数遍历执行Execute(entity)方法。
        void queueOnThread(object state) {
            var job = (Job<TEntity>)state;
            try {
                for (int i = job.from; i < job.to; i++) {
                    Execute(job.entities[i]);
                }
            } catch (Exception ex) {
                job.exception = ex;
            } finally {
                Interlocked.Decrement(ref _threadsRunning);
            }
        }

        /// 每个线程并发对每个entity执行逻辑
        protected abstract void Execute(TEntity entity);
    }

    /// 多线程执行时的一个执行单位，Job任务
    class Job<TEntity> where TEntity : class, IEntity {

        public TEntity[] entities;
        public int from;
        public int to;
        public Exception exception;

        /// 设置一个Job需要处理的任务
        public void Set(TEntity[] entities, int from, int to) {
            this.entities = entities;
            this.from = from;
            this.to = to;
            exception = null;
        }
    }
}
