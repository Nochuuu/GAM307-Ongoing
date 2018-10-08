using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public TextMeshProUGUI enemyCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemyCount.text = "Enemy Count: " + Enemy.enemyCount.ToString();
	}
}
