> 本篇主要介绍有关System类的源码分析，拿项目中的PlayerSpawnSystem来举例。



**PlayerSpawnSystem**是创建Player的System，继承至`ReactiveSystem<GameEntity>`，而基类的含义可以通过其类注释看到：

>如果基于指定的收集器进行了更改，则ReactiveSystem会调用Execute（entities），并且只会传递已更改的实体。
>常见用例是对更改做出反应，例如实体位置的更改以更新相关gameObject的gameObject.transform.position。

下面通过层层递进的关系解析整个System的调用规则。

### ReactiveSystem构造函数

在上一篇文章中，描述GameSystems类的构造函数中，添加多个System通过new关键字，其实就是执行的System的构造方法，下面以ReactiveSystem为例。

```csharp
// System的构造函数，通过GetTrigger中的GameMatcher来匹配目标集合
protected ReactiveSystem(IContext<TEntity> context)
{
    this._collector = this.GetTrigger(context);
    this._buffer = new List<TEntity>();
}
```

为了讲清楚整个初始化的过程还必须提到GameSystems所继承的类`Feature`，这个类通常用来定义多个System组合在一起得到的一个Feature功能集，细心的读者可能看到了Feature类其实是继承于`Entitas.VisualDebugging.Unity.DebugSystems`或者`Entitas.Systems`，为什么是或者？

那是因为如果满足`(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)` 则继承于前者以开启可视化的调试功能，而DebugSystem其实也是继承于`Entitas.Systems`；如果满足`(!ENTITAS_DISABLE_DEEP_PROFILING && DEVELOPMENT_BUILD)`则开启DEEP_PROFILING的模式；如果前两者都不满足，则直接继承至`Entitas.Systems`，不附带Debug功能。

总结下来就是Editor下走第一种模式，手机端开发模式走第二种，否则走第三种模式。其中DebugSystems就是用作调试的System辅助类，下面会对它进行剖析。



### DebugSystems



说完了DebugSystem类，就该进入主角Systems类了。

### Systems
Systems类是实现了`IInitializeSystem, ISystem, IExecuteSystem, ICleanupSystem, ITearDownSystem`这五个接口，这些接口共分为四种System类型，它们都同继承于ISystem接口，四种接口类型意味着四个不同的阶段。



#### Initialize



#### Execute

在`ReactiveSystem`类的构造函数`ReactiveSystem()`实例化时，直接调用`GetTrigger()`方法，拿到`ICollector<TEntity>`集合，通过`Execute()`方法将`ICollector<TEntity>`集合通过`Filter(TEntity entity)`方法筛选之后得到的`List<TEntity>`，最后交由`Execute(List<TEntity> entities)`方法执行这些Entity。

```csharp
// 来自ReactiveSystem类

// System的执行器，筛选并执行目标集合
public void Execute()
{
  if (this._collector.count == 0)
	return;
  foreach (TEntity collectedEntity in this._collector.collectedEntities)
  {
	if (this.Filter(collectedEntity)) // 通过Filter(TEntity entity)来筛选目标实体集合
	{
	  collectedEntity.Retain((object) this);
	  this._buffer.Add(collectedEntity);
	}
  }
  this._collector.ClearCollectedEntities();
  if (this._buffer.Count == 0)
	return;
  try
  {
	this.Execute(this._buffer); // 交由Execute(List<TEntity> entities)执行
  }
  finally
  {
	for (int index = 0; index < this._buffer.Count; ++index)
	  this._buffer[index].Release((object) this);
	this._buffer.Clear();
  }
}

```

这里提到的`Filter(TEntity entity)`和`Execute(List<TEntity> entities)`抽象方法就是System中重写的出现最多的那两个方法。

