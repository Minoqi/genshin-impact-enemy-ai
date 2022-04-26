using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    // Variables
    public Transform target;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Walk State");
        target = enemy.wanderPoints[Random.Range(0, enemy.wanderPoints.Length)];
        Debug.Log("Current destination target: " + target);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        MoveToTarget(enemy);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {
        
    }

    void MoveToTarget(EnemyStateManager enemy)
    {
        // Move
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.position, enemy.speed * Time.deltaTime);

        // Check if at target
        if (Vector2.Distance(target.position, enemy.transform.position) < 0.25f)
        {
            enemy.SwitchState(enemy.IdleState);
        }
    }
}
