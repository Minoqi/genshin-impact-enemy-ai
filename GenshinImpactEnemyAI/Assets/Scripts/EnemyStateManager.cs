using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateManager : MonoBehaviour
{
    // Variables
    EnemyBaseState currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyWalkState WalkState = new EnemyWalkState();
    public EnemyPreAttackState PreAttackState = new EnemyPreAttackState();
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyHurtState HurtState = new EnemyHurtState();
    public EnemyDeadState DeadState = new EnemyDeadState();

    // Manager & UI
    public GameManager gm;
    public Text currentStatusUI, currentHealthUI;

    // Stats
    public float idleWaitTimeMin, idleWaitTimeMax;
    public float preattackWaitTimeMin, preattackWaitTimeMax;
    public float speed, health;
    public Transform[] wanderPoints;
    public Transform baseCenter;
    public float baseRange, baseRangeAI;
    public GameObject player;
    public float distanceToAttackPlayer;
    public bool tookDamage;

    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);

        health = 100;
        tookDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    // Check if player is within the base
    public void CheckForIntruder(EnemyStateManager enemy)
    {
        if (Vector3.Distance(baseCenter.position, player.transform.position) <= baseRange)
        {
            enemy.SwitchState(PreAttackState);
        }
    }

    public void TakeDamage(EnemyStateManager enemy)
    {
        if (tookDamage)
        {
            enemy.SwitchState(HurtState);
        }
    }
}
