using UnityEngine;

public class PatrolState : EnemyBaseState
{
    private Vector2 patrolRange = new Vector2(3f, 3f);
    private float startTime;
    private float destinationUpdate = 2f;
    private Vector3 destination;

    public override void EnterState(EnemyFSM enemy)
    {
        enemy.EnemyAnimator.SetFloat("Speed", 0f);
        destination = new Vector3(enemy.transform.position.x + UnityEngine.Random.Range(-patrolRange.x, patrolRange.x),
                                 enemy.transform.position.y,
                                 enemy.transform.position.z + UnityEngine.Random.Range(-patrolRange.y, patrolRange.y));
        enemy.EnemyAgent.SetDestination(destination);
        startTime = Time.time;
    }

    public override void OnCollisionEnter(EnemyFSM enemy)
    {
        //Logica de transición a Death State
        if (enemy.lifes == 0)
            enemy.TransitionToState(enemy.EnemyDeathState);
    }

    public override void Update(EnemyFSM enemy)
    {
        enemy.EnemyAnimator.SetFloat("Speed", enemy.EnemyAgent.velocity.magnitude);
        if ((Time.time - startTime) > destinationUpdate)
        {
            startTime = Time.time;
            destination = new Vector3(enemy.transform.position.x + UnityEngine.Random.Range(-patrolRange.x, patrolRange.x),
                                     enemy.transform.position.y,
                                     enemy.transform.position.z + UnityEngine.Random.Range(-patrolRange.y, patrolRange.y));
            enemy.EnemyAgent.SetDestination(destination);
        }

        // Lógica de transición a Chase State
        if ((enemy.transform.position - enemy.Player.position).sqrMagnitude < 100f)
            enemy.TransitionToState(enemy.EnemyChaseState);
    }

}
