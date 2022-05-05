using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    // Variables
    private float idleTimeLeft;

    public override void EnterState(EnemyStateManager enemy)
    {
        // Set time
        idleTimeLeft = Random.Range(enemy.idleWaitTimeMin, enemy.idleWaitTimeMax);

        // Adjust UI
        string newUIText = "> Idle" + "\n" + "Walk" + "\n" + "Pre-Attack" + "\n" + "Attack" + "\n" + "Hurt" + "\n" + "Die";
        enemy.currentStatusUI.text = newUIText;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        StandForXSeconds(enemy);
        enemy.CheckForIntruder(enemy);
        enemy.TakeDamage(enemy);
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
