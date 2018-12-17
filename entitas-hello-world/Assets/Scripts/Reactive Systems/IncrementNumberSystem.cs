using Entitas;
using UnityEngine;

public class IncrementNumberSystem : IExecuteSystem {
    
    public void Execute() {
        var entities = GameController.context.GetEntities();
        
        Debug.Log(entities[0].number.x);
        entities[0].number.x++;
        
    }
    
}