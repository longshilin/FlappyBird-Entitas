﻿using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener
{
    public virtual void Link(IEntity entity)
    {
        gameObject.Link(entity);
        var e = (GameEntity)entity;
        // add components
        e.AddPositionListener(this);
        e.AddDestroyedListener(this);

        var pos = e.position.Value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroyed(GameEntity entity)
    {
        Destroy();
    }

    protected virtual void Destroy()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}