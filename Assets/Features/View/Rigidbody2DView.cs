using System;
using Entitas;
using UnityEngine;

public class Rigidbody2DView : UnityView, ISyncPosition, IVelocityListener
{
    public override Vector3 Position
    {
        get { return base.Position; }
        set { throw new Exception("Rigidbody2DView.Position must not be set!"); }
    }

    public override Quaternion Rotation
    {
        get { return base.Rotation; }
        set { throw new Exception("Rigidbody2DView.Rotation must not be set!"); }
    }

    public override Vector3 Scale
    {
        get { return base.Scale; }
        set { throw new Exception("Rigidbody2DView.Scale must not be set!"); }
    }

    Rigidbody2D _rigidbody2D;

    public override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void Link(IEntity entity)
    {
        base.Link(entity);
        base.Position = _entity.position.Value;

        if (_entity.hasPositionListener)
        {
            _entity.RemovePositionListener();
        }

        if (_entity.hasRotationListener)
        {
            _entity.RemoveRotationListener();
        }

        if (_entity.hasScaleListener)
        {
            _entity.RemoveScaleListener();
        }

        _entity.AddSyncPosition(this);
        _entity.AddVelocityListener(this);
    }

    public void OnVelocity(GameEntity entity, Vector3 value)
    {
        _rigidbody2D.velocity = value;
    }
}