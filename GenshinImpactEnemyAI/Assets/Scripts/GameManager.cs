using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public GameObject qEnemy, wEnemy, eEnemy, rEnemy; 
    public List<GameObject> preattackEnemies;
    public bool nextEnemyCanAttack;
    public float timeBetweenAttacksMin, timeBetweenAttacksMax;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AttackAI();

        if (!nextEnemyCanAttack)
        {
            AttackTimer();
        }
    }

    public void AttackTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            nextEnemyCanAttack = true;
            timeLeft = Random.Range(timeBetweenAttacksMin, timeBetweenAttacksMax);
        }
    }

    public void AttackAI()
    {
        // Attack Enemy 1
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Press Q");
            qEnemy.GetComponent<EnemyStateManager>().tookDamage = true;
        }

        // Attack Enemy 2
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Press W");
            wEnemy.GetComponent<EnemyStateManager>().tookDamage = true;
        }

        // Attack Enemy 3
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Press E");
            eEnemy.GetComponent<EnemyStateManager>().tookDamage = true;
        }

        // Attack Enemy 4
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Press R");
            rEnemy.GetComponent<EnemyStateManager>().tookDamage = true;
        }
    }
}
