namespace Entitas {

    /// 如果想在执行操作后执行清理逻辑，请实现该接口
    public interface ICleanupSystem : ISystem {

        void Cleanup();
    }
}
