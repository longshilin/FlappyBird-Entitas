namespace Entitas {

    /// 如果想创建一个在开始时会初始化一次的系统，请实现此接口。
    public interface IInitializeSystem : ISystem {

        void Initialize();
    }
}
