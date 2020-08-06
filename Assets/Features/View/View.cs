using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace GeometryTowers.View
{
    public class View : MonoBehaviour, IView, IGeometryTowersComponentsPositionListener
    {
        public virtual void Link(IEntity entity)
        {
            gameObject.Link(entity);
            var e = (GameEntity)entity;

            e.AddGeometryTowersComponentsPositionListener(this);

            var pos = e.geometryTowersComponentsPosition.Value;
            transform.localPosition = new Vector3(pos.x, pos.y);
        }

        public virtual void OnDestroyed(GameEntity entity)
        {
            Terminate();
        }

        protected void Terminate()
        {
            gameObject.Unlink();
            Destroy(gameObject);
        }

        public void OnGeometryTowersComponentsPosition(GameEntity entity, Vector2Int value)
        {
            transform.localPosition = new Vector3(value.x, value.y);
        }
    }
}
