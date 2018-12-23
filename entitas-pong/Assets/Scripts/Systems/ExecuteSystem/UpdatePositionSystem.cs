using Entitas;

public class UpdatePositionSystem : IExecuteSystem {
    
    private Contexts contexts;
    private GameEntity p1entity;
    private GameEntity p2entity;
    
    public UpdatePositionSystem(Contexts _contexts) {
        contexts = _contexts;
        p1entity = contexts.game.GetEntities()[0];
        p2entity = contexts.game.GetEntities()[1];
    }
    
    public void Execute() {
        p1entity.position.y += p1entity.velocity.vy;
        p2entity.position.y += p2entity.velocity.vy;
    }
}