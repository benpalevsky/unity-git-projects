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

        _systems = new Feature("Game");


        //make a new hello world system
        _systems.Add(new HelloWorldSystem());
        _systems.Add(new InitializePlayerSystem(contexts));
        _systems.Add(new InstantiateViewSystem(contexts));

        _systems.Initialize();
    }

    private void Update() {
        var contexts = Contexts.sharedInstance;
    }
}