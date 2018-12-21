using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InstantiateViewSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;


    //what does :base(context) mean?
    //constructor looks a bit weird
    public InstantiateViewSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }


    //tells Entitas which component events can be handled
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        //don't understand this line
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities) {
        
        Debug.Log("hey");
        foreach (var e in _contexts.game.GetEntities()) {
            //straight up unity method here
            var gameObject = e.resource.prefab;
            Debug.Log("hi");


            var instance = GameObject.Instantiate(gameObject);


            //add the view component (which is just a prefab reference) 
            //and link Entitas with the Prefab

            instance.Link(e);

            e.AddView(instance);
        }
    }
}