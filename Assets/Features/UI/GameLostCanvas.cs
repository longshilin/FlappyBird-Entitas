using UnityEngine;

public class GameLostCanvas : MonoBehaviour, IAnyGameLostListener
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        var e = contexts.game.CreateEntity();
        e.AddAnyGameLostListener(this);
    }

    public void OnAnyGameLost(GameEntity entity)
    {
        _animator.SetTrigger("Appear");
    }
}
