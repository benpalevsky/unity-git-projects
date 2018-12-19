using Entitas;
using UnityEngine;

public class IncrementNumberSystem : IExecuteSystem {
    public void Execute() {
        var entities = Contexts.sharedInstance.game.GetEntities();

        foreach (var e in entities) {
            if (!e.hasNumber) return;
            Debug.Log(e.number.x);
            e.number.x++;
        }
    }
}