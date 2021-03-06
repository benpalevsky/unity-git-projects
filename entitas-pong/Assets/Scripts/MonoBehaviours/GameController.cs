﻿using System;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    private Systems _systems;

    public GameSetup gameSetup;

    public GameObject p1gameObj;
    public GameObject p2gameObj;
    public GameObject ballGameObj;

    public GameEntity p1entity;
    public GameEntity p2entity;
    public GameEntity ballEntity;
    
    public float i = 0;


    // Use this for initialization
    private void Start() {
        var contexts = Contexts.sharedInstance;

        p1entity = contexts.game.CreateEntity();
        p1entity.AddResource(gameSetup.player1);
        p1gameObj = Instantiate(p1entity.resource.prefab);
        p1entity.AddPosition(p1gameObj.transform.position.x, 0);
        p1entity.AddVelocity(0, 0);

        p2entity = contexts.game.CreateEntity();
        p2entity.AddResource(gameSetup.player2);
        p2gameObj = Instantiate(p2entity.resource.prefab);
        p2entity.AddPosition(p2gameObj.transform.position.x, 0);
        p2entity.AddVelocity(0, 0);

        ballEntity = contexts.game.CreateEntity();
        ballEntity.AddResource(gameSetup.ball);
        ballGameObj = Instantiate(ballEntity.resource.prefab);
        ballEntity.AddPosition(0,0);
        ballEntity.AddVelocity(0.05f , 0);
        


        contexts.game.SetGameSetup(gameSetup);


        _systems = new Feature("Game");


        //make a new hello world system
        _systems.Add(new HelloWorldSystem());
        _systems.Add(new InitializePlayerSystem(contexts));
        _systems.Add(new AddVelocityToPositionSystem(contexts));
        _systems.Add(new WorldWrapSystem(contexts));

        _systems.Initialize();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            p1entity.velocity.vy += 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            p1entity.velocity.vy -= 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            p2entity.velocity.vy += 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            p2entity.velocity.vy -= 0.1f;
        }
        
        
        if (ballGameObj.GetComponent<BoxCollider2D>().IsTouching(p2gameObj.GetComponent<BoxCollider2D>())
            || ballGameObj.GetComponent<BoxCollider2D>().IsTouching(p1gameObj.GetComponent<BoxCollider2D>())) {
            ballEntity.velocity.vx = -0.1f;
            Debug.Log(i++);
        }

        p1gameObj.transform.position = new Vector3(p1entity.position.x, p1entity.position.y, 0);
        p2gameObj.transform.position = new Vector3(p2entity.position.x, p2entity.position.y, 0);
        ballGameObj.transform.position = new Vector3(ballEntity.position.x, ballEntity.position.y, 0);
        
        
        
        
        _systems.Execute();
  


    }
    
}