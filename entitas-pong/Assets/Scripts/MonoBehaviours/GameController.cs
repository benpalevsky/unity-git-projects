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

        entity.AddPosition(-3, 0);


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
        entity.position.x += 0.01f;
        instance.transform.position = new Vector3(entity.position.x, entity.position.y, 0);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Debug.Log("hiiii");
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log("heyyyy");
        }
    }
}