namespace Entitas {

    /// 如果要创建可以添加到实体的组件，请实现此接口。 
    ///（可选）您可以添加以下属性：
    /// [Unique]：代码生成器将为上下文生成其他方法，以确保仅存在具有此组件的一个实体。
    /// 例如，context.isAnimating = true或context.SetResources(); 
    /// [MyContextName，MyOtherContextName]：您可以使此组件仅在指定的上下文中可用。代码生成器可以为您生成这些属性。
    /// 在Entitas.CodeGeneration.Attributes / Attributes中可以找到更多可用的属性。
    public interface IComponent {
    }
}
