using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        // Adjust UI
        string newUIText = "Idle" + "\n" + "Walk" + "\n" + "Pre-Attack" + "\n" + "Attack" + "\n" + "Hurt" + "\n" + "> Die";
        enemy.currentStatusUI.text = newUIText;

        Die(enemy);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {

    }

    private void Die(EnemyStateManager enemy)
    {
        enemy.gameObject.SetActive(false);
    }
}
