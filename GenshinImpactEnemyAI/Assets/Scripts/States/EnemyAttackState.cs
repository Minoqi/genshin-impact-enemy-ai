using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log(enemy.name + " has entered ATTACK state");

        // Adjust UI
        string newUIText = "Idle" + "\n" + "Walk" + "\n" + "Pre-Attack" + "\n" + "> Attack" + "\n" + "Hurt" + "\n" + "Die";
        enemy.currentStatusUI.text = newUIText;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        GetInAttackRange(enemy);
        enemy.TakeDamage(enemy);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision colission)
    {

    }

    // Get close to the player to attack
    private void GetInAttackRange(EnemyStateManager enemy)
    {
        // Move towards player
        enemy.transform.position = Vector3.MoveTowards(enemy.gameObject.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime);

        // Attack player if close enough
        if (Vector3.Distance(enemy.gameObject.transform.position, enemy.player.transform.position) < enemy.distanceToAttackPlayer)
        {
            enemy.gm.GetComponent<GameManager>().nextEnemyCanAttack = false;

            Debug.Log(enemy.name + " did damage!");

            enemy.WalkState.timeLeftTilAttackAgain = 5f;
            enemy.SwitchState(enemy.WalkState);
        }
        else if (Vector3.Distance(enemy.gameObject.transform.position, enemy.baseCenter.position) > 5) // Remove enemy from preattack list
        {
            for (int i = 0; i < enemy.gm.GetComponent<GameManager>().preattackEnemies.Count; i++)
            {
                if (enemy.gameObject == enemy.gm.GetComponent<GameManager>().preattackEnemies[i])
                {
                    enemy.gm.GetComponent<GameManager>().preattackEnemies.RemoveAt(i);
                }
            }

            enemy.WalkState.timeLeftTilAttackAgain = 5f;
            enemy.SwitchState(enemy.WalkState);
        }
        else
        {
            enemy.WalkState.timeLeftTilAttackAgain = 5f;
            enemy.SwitchState(enemy.WalkState);
        }
    }
}
