namespace Entitas {

    /// 如果想要创建一个在最后应该拆卸一次的系统，请实现此接口
    public interface ITearDownSystem : ISystem {

        void TearDown();
    }
}
