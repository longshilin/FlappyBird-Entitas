using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        EmitMouseDown();
    }

    void EmitMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var e = _contexts.input.CreateEntity();
            e.AddMouseDown(new Vector2(mouseWorldPos.x, mouseWorldPos.y));
        }
    }
}