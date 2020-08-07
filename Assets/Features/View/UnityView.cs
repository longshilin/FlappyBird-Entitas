using Entitas;
using Entitas.Unity;
using UnityEngine;
using View;

public class UnityView : MonoBehaviour, IUnityView, IPositionListener, IRotationListener, IScaleListener, IDestroyedListener
{
    protected GameEntity _entity;

    public virtual Vector3 Position
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }

    public virtual Quaternion Rotation
    {
        get => transform.localRotation;
        set => transform.localRotation = value;
    }

    public virtual Vector3 Scale
    {
        get => transform.localScale;
        set => transform.localScale = value;
    }

    public GameEntity Entity => _entity;

    public virtual void Link(IEntity entity)
    {
        gameObject.Link(entity);
        _entity = (GameEntity)entity;

        // add components
        _entity.AddPositionListener(this);
        _entity.AddDestroyedListener(this);

        var pos = _entity.position.Value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = value;
    }

    public virtual void OnDestroyed(GameEntity entity)
    {
        Destroy();
    }

    protected virtual void Destroy()
    {
        gameObject.Unlink();

        _entity.Destroy();
        Destroy(gameObject);
    }

    public void OnRotation(GameEntity entity, Quaternion value)
    {
        transform.localRotation = value;
    }

    public void OnScale(GameEntity entity, Vector3 value)
    {
        transform.localScale = value;
    }

    public virtual void Awake()
    {
    }
}