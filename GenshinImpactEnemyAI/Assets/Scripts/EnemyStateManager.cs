using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Stats
    public float idleWaitTimeMin, idleWaitTimeMax;

    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
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

    void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
