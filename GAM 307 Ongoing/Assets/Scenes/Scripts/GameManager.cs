using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    TITLE,
    INGAME,
    PAUSED,
    GAMEOVER,
}

public enum DifficultyLevel
{
    EASY,
    MEDIUM,
    HARD,
}

public class GameManager : Singleton<GameManager>
{

    public int score = 0;
    public GameState gameState;
    public DifficultyLevel difficulty;

    void Start ()
    {
        gameState = GameState.TITLE;
        difficulty = DifficultyLevel.MEDIUM;
        score = 0;
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            difficulty = DifficultyLevel.EASY;
            GameEvents.ReportOnDifficultyChange(difficulty);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            difficulty = DifficultyLevel.MEDIUM;
            GameEvents.ReportOnDifficultyChange(difficulty);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            difficulty = DifficultyLevel.HARD;
            GameEvents.ReportOnDifficultyChange(difficulty);
        }
    }

    #region Events
    private void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
        GameEvents.OnEnemyDie += OnEnemyDie;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
        GameEvents.OnEnemyDie -= OnEnemyDie;
    }

    void OnEnemyHit(EnemyType enemyType, int scoreValue)
    {
        AddScore(scoreValue);
    }

    void OnEnemyDie()
    {
        AddScore(100);
    }
    #endregion

    public void AddScore(int newScore)
    {
        score += newScore;
    }


}
