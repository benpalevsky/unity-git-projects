using System.Runtime.Remoting.Contexts;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    private Systems _systems;

    public GameSetup gameSetup;


    // Use this for initialization
    private void Start() {
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGameSetup(gameSetup);


        //make a new hello world system
        _systems = CreateHelloWorldSystem(contexts);
        //call the hello world function
        _systems.Initialize();

        _systems = CreateInitializePlayerSystem(contexts);
        _systems.Initialize();
        
        _systems = CreateInstantiateViewSystem(contexts);
        _systems.Initialize();
    }

    private void Update() {
        var contexts = Contexts.sharedInstance;

        _systems.Execute();
        
    }


    private static Systems CreateHelloWorldSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"
        return new Feature("Game").Add(new HelloWorldSystem());
    }

    private static Systems CreateInitializePlayerSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"
        return new Feature("Game").Add(new InitializePlayerSystem(contexts));
    }

    private static Systems CreateInstantiateViewSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"

        return new Feature("Game").Add(new InstantiateViewSystem(contexts));
    }


    private static Systems CreateAddNumberSystem(Contexts contexts) {
        //this creates our HelloWorldSystem under the "Game"

        return new Feature("Game").Add(new AddNumberSystem());
    }
}