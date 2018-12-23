using Entitas;

public class UpdatePositionSystem : IExecuteSystem {

    private GameContext gameContext;
    
    public UpdatePositionSystem(Contexts _contexts) {
        gameContext = _contexts.game;
    }
    
    public void Execute() {
        var entities = gameContext.GetGroup(
            GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity)
        ).GetEntities();

        foreach (var e in entities) {
            e.position.y += e.velocity.vy;
        }
    }
}