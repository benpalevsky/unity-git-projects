﻿using Entitas;
using UnityEngine;

public class WorldWrapSystem : IExecuteSystem {

    private GameContext gameContext;

    public WorldWrapSystem(Contexts _contexts) {
        gameContext = _contexts.game;
    }
    
    public void Execute() {
        var entities = gameContext.GetGroup(
            GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity)
        ).GetEntities();

        foreach (var e in entities) {
            if (e.position.y > 3f) {
                e.position.y = -2.9f;
            } else if (e.position.y < -3f) {
                e.position.y = 2.9f;
            }
        }
    }
}