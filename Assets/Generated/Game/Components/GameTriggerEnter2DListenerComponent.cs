//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TriggerEnter2DListenerComponent triggerEnter2DListener { get { return (TriggerEnter2DListenerComponent)GetComponent(GameComponentsLookup.TriggerEnter2DListener); } }
    public bool hasTriggerEnter2DListener { get { return HasComponent(GameComponentsLookup.TriggerEnter2DListener); } }

    public void AddTriggerEnter2DListener(System.Collections.Generic.List<ITriggerEnter2DListener> newValue) {
        var index = GameComponentsLookup.TriggerEnter2DListener;
        var component = (TriggerEnter2DListenerComponent)CreateComponent(index, typeof(TriggerEnter2DListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTriggerEnter2DListener(System.Collections.Generic.List<ITriggerEnter2DListener> newValue) {
        var index = GameComponentsLookup.TriggerEnter2DListener;
        var component = (TriggerEnter2DListenerComponent)CreateComponent(index, typeof(TriggerEnter2DListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTriggerEnter2DListener() {
        RemoveComponent(GameComponentsLookup.TriggerEnter2DListener);
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

    static Entitas.IMatcher<GameEntity> _matcherTriggerEnter2DListener;

    public static Entitas.IMatcher<GameEntity> TriggerEnter2DListener {
        get {
            if (_matcherTriggerEnter2DListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TriggerEnter2DListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTriggerEnter2DListener = matcher;
            }

            return _matcherTriggerEnter2DListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddTriggerEnter2DListener(ITriggerEnter2DListener value) {
        var listeners = hasTriggerEnter2DListener
            ? triggerEnter2DListener.value
            : new System.Collections.Generic.List<ITriggerEnter2DListener>();
        listeners.Add(value);
        ReplaceTriggerEnter2DListener(listeners);
    }

    public void RemoveTriggerEnter2DListener(ITriggerEnter2DListener value, bool removeComponentWhenEmpty = true) {
        var listeners = triggerEnter2DListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveTriggerEnter2DListener();
        } else {
            ReplaceTriggerEnter2DListener(listeners);
        }
    }
}
