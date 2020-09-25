namespace Entitas {

    /// 如果要创建一个每帧执行的系统，请实现这个接口
    public interface IExecuteSystem : ISystem {

        void Execute();
    }
}
