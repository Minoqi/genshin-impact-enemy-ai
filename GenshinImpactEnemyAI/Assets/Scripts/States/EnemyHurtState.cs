using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyBaseState
{
    // Variables
    private float timeLeft = 2f;
    private bool delay;

    public override void EnterState(EnemyStateManager enemy)
    {
        // Adjust UI
        string newUIText = "Idle" + "\n" + "Walk" + "\n" + "Pre-Attack" + "\n" + "Attack" + "\n" + "> Hurt" + "\n" + "Die";
        enemy.currentStatusUI.text = newUIText;

        timeLeft = 2f;
        delay = false;
        TakeDamage(enemy);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (delay)
        {
            debugBufferDelay(enemy);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {

    }

    private void TakeDamage(EnemyStateManager enemy)
    {
        enemy.health -= 10;
        enemy.currentHealthUI.text = enemy.health.ToString();

        delay = true;
    }

    private void debugBufferDelay(EnemyStateManager enemy)
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            if (enemy.health <= 0)
            {
                enemy.SwitchState(enemy.DeadState);
            }
            else
            {
                enemy.tookDamage = false;
                enemy.SwitchState(enemy.WalkState);
            }
        }
    }
}
