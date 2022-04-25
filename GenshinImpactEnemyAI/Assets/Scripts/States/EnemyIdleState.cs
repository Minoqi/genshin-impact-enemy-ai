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
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {

    }

    bool StandForXSeconds()
    {
        if (idleTimeLeft >= 0) // Continue idling
        {
            idleTimeLeft -= Time.deltaTime;
        }
        else // Wander to new location
        {

        }
    }

    // to switch states do enemy.SwitchState(enemy.stateName);
}
