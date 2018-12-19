using Entitas;

public class AddNumberSystem : IInitializeSystem {
    public void Initialize() {
        var entities = Contexts.sharedInstance.game.GetEntities();

        foreach (var e in entities) {
            e.AddNumber(0);
        }
    }
}