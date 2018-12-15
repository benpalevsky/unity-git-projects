using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{

    private Systems systems;

    // Use this for initialization
    void Start()
    {
        systems = CreateSystems();
        systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Systems CreateSystems()
    {
        //this creates our HelloWorldSystem under the "Game"
        return new Feature("Game").Add(new HelloWorldSystem());
    }
}
