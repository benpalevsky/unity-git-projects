﻿using Entitas;
using UnityEngine;

public class HelloWorldSystem : IInitializeSystem
{

    public void Initialize()
    {
        UnityEngine.Debug.Log("Hello World");
    }


}
