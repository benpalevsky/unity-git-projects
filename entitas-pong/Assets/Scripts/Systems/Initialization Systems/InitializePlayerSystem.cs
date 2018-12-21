using Entitas;

public class InitializePlayerSystem : IInitializeSystem {
    
    private Contexts contexts;

    //constructor
    public InitializePlayerSystem(Contexts _contexts) {
        contexts = _contexts;
    }

    public void Initialize() {
        var entity = contexts.game.CreateEntity();
        entity.isPlayer = true;
        entity.AddResource(contexts.game.gameSetup.value.playerPrefab);
    }
}