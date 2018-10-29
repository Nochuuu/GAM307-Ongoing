using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : Enemy {

    // Use this for initialization
    void Start()
    {
        Initialise();
    }

    void Initialise()
    {
        health = 200;
        scoreValue = 70;
        speed = 40;

        attack = 30;
        defence = 80;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
