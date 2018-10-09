using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public static float rotateSpeed = 10;
	// Use this for initialization
	void Start ()
    {
        EnemyManager.instance.enemyCount++;
	}

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
    }

    void OnMouseDown()
    {
        StartCoroutine(FadeMe());
    }

    IEnumerator FadeMe()
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return null;
    
        }
        yield return new WaitForSeconds(1);
        EnemyManager.instance.enemyCount--;
        GameManager.instance.score += 100;
        Destroy(this.gameObject);
    }
}
