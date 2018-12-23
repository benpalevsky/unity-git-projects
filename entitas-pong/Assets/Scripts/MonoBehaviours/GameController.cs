using System.ComponentModel.Design.Serialization;
using System.Runtime.Remoting.Contexts;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    private Systems _systems;

    public GameSetup gameSetup;

    public GameObject p1gameObj;
    public GameObject p2gameObj;

    public GameEntity p1entity;
    public GameEntity p2entity;

    // Use this for initialization
    private void Start() {
        var contexts = Contexts.sharedInstance;

        p1entity = contexts.game.CreateEntity();
        p2entity = contexts.game.CreateEntity();

        p1entity.AddPosition(0, 0);
        p2entity.AddPosition(0, 0);


        contexts.game.SetGameSetup(gameSetup);

        contexts.game.GetEntities()[0].AddResource(gameSetup.player1);
        contexts.game.GetEntities()[1].AddResource(gameSetup.player2);

        p1gameObj = Instantiate(contexts.game.GetEntities()[0].resource.prefab);
        p2gameObj = Instantiate(contexts.game.GetEntities()[1].resource.prefab);


        _systems = new Feature("Game");


        //make a new hello world system
        _systems.Add(new HelloWorldSystem());
        _systems.Add(new InitializePlayerSystem(contexts));
        _systems.Add(new InstantiateViewSystem(contexts));

        _systems.Initialize();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            p1entity.position.y += 0.5f;
            p1gameObj.transform.position = new Vector3(p1entity.position.x, p1entity.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            p1entity.position.y -= 0.5f;
            p1gameObj.transform.position = new Vector3(p1entity.position.x, p1entity.position.y, 0);
        }
    }
}