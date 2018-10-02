using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FadeMe());	
	}

    IEnumerator FadeMe()
    {
        yield return new WaitForSeconds(2);

        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
    
        }
    }
}
