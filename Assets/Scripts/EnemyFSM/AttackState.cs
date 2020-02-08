using UnityEngine;

public class AttackState : EnemyBaseState
{
    public override void EnterState(EnemyFSM enemy)
    {
        enemy.EnemyAnimator.SetBool("Punch", true);
        // Debug.Log("Launch Attack Animation");
    }

    public override void OnCollisionEnter(EnemyFSM enemy)
    {
        // Lógica de Transición a Death State
        if (enemy.lifes == 0)
            enemy.TransitionToState(enemy.EnemyDeathState);
    }

    public override void Update(EnemyFSM enemy)
    {
        enemy.EnemyAgent.SetDestination(enemy.Player.position);
        if ((enemy.transform.position - enemy.Player.position).sqrMagnitude > 25f)
            enemy.TransitionToState(enemy.EnemyChaseState);
    }
}
