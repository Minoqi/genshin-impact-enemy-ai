using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPreAttackState : EnemyBaseState
{
    // Variables
    private bool playerIsClose = false;
    private float preattackTimeLeft;

    public override void EnterState(EnemyStateManager enemy)
    {
        // Set attack status
        playerIsClose = false;
        enemy.gm.GetComponent<GameManager>().preattackEnemies.Add(enemy.gameObject);

        // Adjust UI
        string newUIText = "Idle" + "\n" + "Walk" + "\n" + "> Pre-Attack" + "\n" + "Attack" + "\n" + "Hurt" + "\n" + "Die";
        enemy.currentStatusUI.text = newUIText;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (playerIsClose && enemy.gm.GetComponent<GameManager>().nextEnemyCanAttack) // Player is close and an enemy can attack
        {
            if (enemy.gm.GetComponent<GameManager>().preattackEnemies[0] == enemy.gameObject) // Check if first on the list
            {
                enemy.SwitchState(enemy.AttackState);
            }
        }
        else
        {
            // Move towards player
            enemy.gameObject.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime);
        }

        CheckRangeFromPlayer(enemy);
        enemy.TakeDamage(enemy);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {

    }

    public void CheckRangeFromPlayer(EnemyStateManager enemy)
    {
        // Check if in attack range
        if (Vector3.Distance(enemy.gameObject.transform.position, enemy.player.transform.position) < enemy.distanceToAttackPlayer)
        {
            playerIsClose = true;
        }
        else if (Vector3.Distance(enemy.gameObject.transform.position, enemy.player.transform.position) > enemy.baseRangeAI)
        {
            enemy.WalkState.timeLeftTilAttackAgain = 5f;
            enemy.SwitchState(enemy.WalkState);
        }
        else
        {
            playerIsClose = false;
        }
    }
}
