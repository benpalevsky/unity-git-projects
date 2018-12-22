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
        //this line tells the reactive system when to activate
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasResource;
    }

    
    //this is execute for a reactive system
    //gets called when 
    protected override void Execute(List<GameEntity> entities) {
        
        Debug.Log("hey");
        foreach (var e in entities) {
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