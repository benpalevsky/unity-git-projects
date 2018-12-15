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

    private private Systems CreateSystems()
    {
        return new Feature("Game").Add(new HelloWorldSystem());
    }
}
