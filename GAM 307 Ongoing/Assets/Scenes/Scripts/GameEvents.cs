using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    //Event variables
    public static event Action<EnemyType, int> OnEnemyHit = null;
    public static event Action OnEnemyDie = null;
    public static event Action<GameState> OnGameStateChange = null;
    public static event Action<DifficultyLevel> OnDifficultyChange = null;

    //Event Happenings
    public static void ReportOnEnemyHit(EnemyType enemyType, int score)
    {
        if (OnEnemyHit != null)
            OnEnemyHit(enemyType, score);
    }
    
    public static void ReportOnEnemyDie()
    {
        if (OnEnemyDie != null)
            OnEnemyDie();
    }

    public static void ReportOnGameStateChange(GameState gs)
    {
        if (OnGameStateChange != null)
            OnGameStateChange(gs);
    }

    public static void ReportOnDifficultyChange(DifficultyLevel difficulty)
    {
        if (OnDifficultyChange != null)
            OnDifficultyChange(difficulty);
    }

    //Helper Class
    static void Log(string msg)
    {
        Debug.Log(msg);
    }
}
