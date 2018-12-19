using System.Runtime.Remoting.Contexts;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    private Systems _systems;

    public GameSetup gameSetup;


    // Use this for initialization
    private void Start() {

        var contexts = Contexts.sharedInstance;
        var e1 = contexts.game.CreateEntity();
        var e2 = contexts.game.CreateEntity();
        
        e1.AddGameSetup(gameSetup);

        //make a new hello world system
        _systems = CreateHelloWorldSystem(contexts);
        //call the hello world function
        _systems.Initialize();
        
        
        _systems = CreateAddNumberSystem(contexts);
        
        _systems.Initialize();


    
        //now it's an increment number system
        //lets increment all entities with the increment number component
        _systems = CreateIncrementNumberSystem(contexts);


    }

    private void Update() {
        
        _systems.Execute();

        
    }


    private static Systems CreateHelloWorldSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"
        return new Feature("Game").Add(new HelloWorldSystem());
    }
    
    private static Systems CreateIncrementNumberSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"
        
        return new Feature("Game").Add(new IncrementNumberSystem());
    }
    
    
    private static Systems CreateAddNumberSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"
        
        return new Feature("Game").Add(new AddNumberSystem());

    }
}