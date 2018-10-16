using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public TextMeshProUGUI enemyCount;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame

    //void Update()
    //{
    //    enemyCount.text = "Enemy Count: <color=red>" + EnemyManager.instance.enemyCount.ToString();
    //    scoreText.text = "Score: <color=green>" + GameManager.instance.score.ToString();
    //}

    private void OnEnable()
    {
        GameEvents.OnEnemyDie += OnEnemyDie;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDie -= OnEnemyDie;
    }

    void OnEnemyDie()
    {
        enemyCount.text = "Enemy Count: <color=red>" + EnemyManager.instance.enemyCount.ToString();
        scoreText.text = "Score: <color=green>" + GameManager.instance.score.ToString();
    }
}
