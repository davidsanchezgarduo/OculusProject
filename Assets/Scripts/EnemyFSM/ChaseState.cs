using UnityEngine;

public class ChaseState : EnemyBaseState
{
    public override void EnterState(EnemyFSM enemy)
    {

    }

    public override void OnCollisionEnter(EnemyFSM enemy)
    {
        //Logica de transición a Death State
        if (enemy.lifes == 0)
            enemy.TransitionToState(enemy.EnemyDeathState);
    }

    public override void Update(EnemyFSM enemy)
    {
        enemy.EnemyAgent.SetDestination(enemy.Player.position);
        enemy.EnemyAnimator.SetFloat("Speed", enemy.EnemyAgent.velocity.magnitude);

        // Lógica de Transción a Attack State
        if ((enemy.transform.position - enemy.Player.position).sqrMagnitude < 2f)
            enemy.TransitionToState(enemy.EnemyAttackState);

        // Lógica de Transicón a Patrol State
        if ((enemy.transform.position - enemy.Player.position).sqrMagnitude > 100f)
            enemy.TransitionToState(enemy.EnemyPatrolState);
    }

}
