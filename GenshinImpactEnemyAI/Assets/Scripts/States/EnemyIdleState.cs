using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    // Variables
    public float idleTimeLeft;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Idle State");
        idleTimeLeft = Random.Range(enemy.idleWaitTimeMin, enemy.idleWaitTimeMax);
        Debug.Log("Wait Time: " + idleTimeLeft);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        StandForXSeconds(enemy);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {

    }

    void StandForXSeconds(EnemyStateManager enemy)
    {
        if (idleTimeLeft >= 0) // Continue idling
        {
            idleTimeLeft -= Time.deltaTime;
        }
        else // Wander to new location
        {
            enemy.SwitchState(enemy.WalkState);
        }
    }
}
