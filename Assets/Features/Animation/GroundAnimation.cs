using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GroundAnimation : MonoBehaviour, IAnyGameLostListener, IAnyGameStartedListener
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        var e = Contexts.sharedInstance.game.CreateEntity();
        e.AddAnyGameLostListener(this);
        e.AddAnyGameStartedListener(this);
    }

    public void OnAnyGameLost(GameEntity entity)
    {
        _animator.enabled = false;
    }

    public void OnAnyGameStarted(GameEntity entity)
    {
        _animator.enabled = true;
    }
}