using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWarrior : Enemy {

    // Use this for initialization
    void Start()
    {
        Initialise();
        
    }

    void Initialise()
    {
        health = 250;
        scoreValue = 40;
        speed = 20;

        attack = 10;
        defence = 10;

        healthUI.text = "Health: " + health.ToString();
        healthBar.transform.localScale = Vector3.one;
        healthBarSections = ((float)health / 100) / 100;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
