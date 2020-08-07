using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _parent;
    private Contexts _contexts;

    public ViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Asset);

    protected override bool Filter(GameEntity entity) => entity.hasAsset && !entity.hasView;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.AddView(InstantiateView(e));
        }
    }

    IView InstantiateView(GameEntity entity)
    {
        var prefab = Resources.Load<GameObject>(entity.asset.Value);
        var view = Object.Instantiate(prefab, _parent).GetComponent<IView>();
        view.Link(entity);
        return view;
    }
}