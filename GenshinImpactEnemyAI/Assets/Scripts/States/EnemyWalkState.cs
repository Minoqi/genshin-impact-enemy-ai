using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    // Variables
    public Transform target;
    public float timeLeftTilAttackAgain;

    public override void EnterState(EnemyStateManager enemy)
    {
        target = enemy.wanderPoints[Random.Range(0, enemy.wanderPoints.Length)];

        // Adjust UI
        string newUIText = "Idle" + "\n" + "> Walk" + "\n" + "Pre-Attack" + "\n" + "Attack" + "\n" + "Hurt" + "\n" + "Die";
        enemy.currentStatusUI.text = newUIText;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        MoveToTarget(enemy);

        if (timeLeftTilAttackAgain > 0)
        {
            timeLeftTilAttackAgain -= Time.deltaTime;
        }
        else
        {
            enemy.CheckForIntruder(enemy);
        }

        enemy.TakeDamage(enemy);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {
        
    }

    void MoveToTarget(EnemyStateManager enemy)
    {
        // Move
        enemy.gameObject.transform.position = Vector3.MoveTowards(enemy.gameObject.transform.position, target.position, enemy.speed * Time.deltaTime);

        // Check if at target
        if (Vector2.Distance(target.position, enemy.gameObject.transform.position) < 0.25f)
        {
            enemy.SwitchState(enemy.IdleState);
        }
    }
}
