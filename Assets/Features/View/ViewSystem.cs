using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace GeometryTowers.View
{
    public class ViewSystem : ReactiveSystem<GameEntity>
    {
        readonly Transform _parent;

        public ViewSystem(Contexts contexts) : base(contexts.game)
        {
            _parent = new GameObject("Views").transform;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.GeometryTowersViewAsset);

        protected override bool Filter(GameEntity entity) => entity.hasGeometryTowersViewAsset && !entity.hasGeometryTowersViewView;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                e.AddGeometryTowersViewView(InstantiateView(e));
            }
        }

        private IView InstantiateView(GameEntity entity)
        {
            var prefab = Resources.Load<GameObject>(entity.geometryTowersViewAsset.Value);
            var view = Object.Instantiate(prefab, _parent).GetComponent<IView>();
            view.Link(entity);
            return view;
        }
    }
}