using UnityEngine;
using Entitas.CodeGeneration.Attributes;


[CreateAssetMenu]
[Game, Unique]

public class GameSetup : ScriptableObject {
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
}