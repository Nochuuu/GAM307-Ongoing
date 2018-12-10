using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum EnemyType
{
    Kobold,
    Kraken,
    Cthulu,
    SkeletonWarrior,
    Rattata,
}

public class Enemy : MonoBehaviour {


    public EnemyType enemyType;

    [Header("General")]
    public int health;
    public int speed;
    public int scoreValue;

    [Header("Traits")]
    public int attack;
    public int defence;

    [Header("UI Elements")]
    public TextMeshProUGUI healthUI;
    public Image healthBar;

    public float healthBarSections;

	void Start ()
    {
        EnemyManager.instance.enemyCount++;

        //healthBarSections = (float)health / 100;
	}

    public void GotHit(int baseDamage)
    {
        health -= baseDamage;

        GameEvents.ReportOnEnemyHit(enemyType, scoreValue);

        if (health <= 0)
            StartCoroutine(Die());

        healthUI.text = "Health: " + health.ToString();

        Vector3 temp = healthBar.transform.localScale;
        temp.x = health * healthBarSections;
        healthBar.transform.localScale = temp;

    }

    void OnMouseDown()
    {
        StartCoroutine(Die());
    }

    #region Enemy Die
    IEnumerator Die()
    {
        GetComponent<Collider>().enabled = false;

        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return null;
    
        }

        GameEvents.ReportOnEnemyDie();

        //EnemyManager.instance.enemyCount--;
        //EnemyManager.instance.SpawnEnemy();
        //GameManager.instance.score += 100;
        //GameManager.instance.AddScore(100);

        Destroy(this.gameObject);
    }
    #endregion

    #region Difficulty switch
    private void OnEnable()
    {
        GameEvents.OnDifficultyChange += OnDifficultyChange;
    }

    private void OnDisable()
    {
        GameEvents.OnDifficultyChange -= OnDifficultyChange;
    }

    
    void OnDifficultyChange(DifficultyLevel difficulty)
    {
        
        switch(difficulty)
        {
            case DifficultyLevel.EASY:
                GetComponent<Renderer>().material.color = Color.green;
                transform.localScale = new Vector3(3, 3, 3);
                break;
            case DifficultyLevel.MEDIUM:
                GetComponent<Renderer>().material.color = Color.blue;
                transform.localScale = new Vector3(2, 2, 2);
                break;
            case DifficultyLevel.HARD:
                GetComponent<Renderer>().material.color = Color.red;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                GetComponent<Renderer>().material.color = Color.green;
                transform.localScale = new Vector3(3, 3, 3);
                break;
        }
        #endregion



        #region Old code
        //if(difficulty == DifficultyLevel.EASY)
        //{
        //    GetComponent<Renderer>().material.color = Color.green;
        //    transform.localScale = new Vector3(3, 3, 3);
        //}
        //if (difficulty == DifficultyLevel.MEDIUM)
        //{
        //    GetComponent<Renderer>().material.color = Color.blue;
        //    transform.localScale = new Vector3(2, 2, 2);
        //}
        //if (difficulty == DifficultyLevel.HARD)
        //{
        //    GetComponent<Renderer>().material.color = Color.red;
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        #endregion
    }
}
