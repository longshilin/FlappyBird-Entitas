using UnityEngine;

[RequireComponent(typeof(UnityView))]
public class CollisionReporter : MonoBehaviour
{
    private UnityView _listener;

    private void Awake()
    {
        _listener = GetComponent<UnityView>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var e = _listener.Entity;

        if (e.hasCollision)
        {
            e.ReplaceCollision(other.gameObject);
        }
        else
        {
            e.AddCollision(other.gameObject);
        }
    }
}