using UnityEngine;

[RequireComponent(typeof(UnityView))]
public class TriggerReporter : MonoBehaviour
{
    private UnityView _listener;

    private void Awake()
    {
        _listener = GetComponent<UnityView>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var e = _listener.Entity;

        e.ReplaceTriggerEnter2D(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var e = _listener.Entity;

        e.ReplaceTriggerExit2D(other);
    }
}