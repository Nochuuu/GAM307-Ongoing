using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public TextMeshProUGUI enemyCount;
    public TextMeshProUGUI scoreText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemyCount.text = "Enemy Count: <color=red>" + EnemyManager.instance.enemyCount.ToString();
        scoreText.text = "Score: <color=green>" + GameManager.instance.score.ToString();
    }
}
