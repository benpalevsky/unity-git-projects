using System.ComponentModel.Design.Serialization;
using System.Runtime.Remoting.Contexts;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    private Systems _systems;

    public GameSetup gameSetup;

    public GameObject instance;

    public GameEntity entity;

    // Use this for initialization
    private void Start() {
        var contexts = Contexts.sharedInstance;

        entity = contexts.game.CreateEntity();

        entity.AddPosition(0, 0);


        contexts.game.SetGameSetup(gameSetup);

        contexts.game.GetEntities()[0].AddResource(gameSetup.playerPrefab);

        instance = Instantiate(contexts.game.GetEntities()[0].resource.prefab);


        _systems = new Feature("Game");


        //make a new hello world system
        _systems.Add(new HelloWorldSystem());
        _systems.Add(new InitializePlayerSystem(contexts));
        _systems.Add(new InstantiateViewSystem(contexts));

        _systems.Initialize();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            entity.position.y += 0.5f;
            instance.transform.position = new Vector3(entity.position.x, entity.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            entity.position.y -= 0.5f;
            instance.transform.position = new Vector3(entity.position.x, entity.position.y, 0);
        }
    }
}