using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    private Systems _systems;
    private GameEntity e;
    public static GameContext context;


    // Use this for initialization
    private void Start() {
        
        context = new GameContext();

        _systems = CreateHelloWorldSystem();
        _systems.Initialize();
        
        e = context.CreateEntity();
        e.AddNumber(0);

        //_systems = CreateIncrementNumberSystem();


    }

    private void Update() {
        
        //_systems.Execute();

        
    }


    private static Systems CreateHelloWorldSystem() {
        //this creates our HelloWorldSystem under the "Game"
        return new Feature("Game").Add(new HelloWorldSystem());
    }
    
    private static Systems CreateIncrementNumberSystem() {
        //this creates our HelloWorldSystem under the "Game"
        return new Feature("Game").Add(new IncrementNumberSystem());
    }
}