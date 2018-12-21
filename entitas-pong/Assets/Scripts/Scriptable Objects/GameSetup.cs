using UnityEngine;
using Entitas.CodeGeneration.Attributes;


[CreateAssetMenu]
[Game, Unique]

public class GameSetup : ScriptableObject {
    public GameObject playerPrefab;
}