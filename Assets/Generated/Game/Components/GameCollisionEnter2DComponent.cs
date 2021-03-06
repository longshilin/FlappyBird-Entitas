//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CollisionEnter2DComponent collisionEnter2D { get { return (CollisionEnter2DComponent)GetComponent(GameComponentsLookup.CollisionEnter2D); } }
    public bool hasCollisionEnter2D { get { return HasComponent(GameComponentsLookup.CollisionEnter2D); } }

    public void AddCollisionEnter2D(UnityEngine.Collision2D newValue) {
        var index = GameComponentsLookup.CollisionEnter2D;
        var component = (CollisionEnter2DComponent)CreateComponent(index, typeof(CollisionEnter2DComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCollisionEnter2D(UnityEngine.Collision2D newValue) {
        var index = GameComponentsLookup.CollisionEnter2D;
        var component = (CollisionEnter2DComponent)CreateComponent(index, typeof(CollisionEnter2DComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCollisionEnter2D() {
        RemoveComponent(GameComponentsLookup.CollisionEnter2D);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollisionEnter2D;

    public static Entitas.IMatcher<GameEntity> CollisionEnter2D {
        get {
            if (_matcherCollisionEnter2D == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollisionEnter2D);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollisionEnter2D = matcher;
            }

            return _matcherCollisionEnter2D;
        }
    }
}
