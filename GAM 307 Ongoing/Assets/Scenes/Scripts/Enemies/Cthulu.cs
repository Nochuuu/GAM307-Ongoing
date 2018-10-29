using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cthulu : Enemy {

	// Use this for initialization
	void Start ()
    {
        Initialise();
	}
	
    void Initialise()
    {
        health = 500;
        scoreValue = 150;
        speed = 10;

        attack = 50;
        defence = 30;
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
