using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public int lifes;
    private Collision collisionObject;
    public Collision CollisionObject
    {
        get { return collisionObject; }
    }
    private Animator enemyAnimator;
    public Animator EnemyAnimator
    {
        get { return enemyAnimator; }
    }
    private NavMeshAgent enemyAgent;
    public NavMeshAgent EnemyAgent
    {
        get { return enemyAgent; }
    }
    private Transform player;
    public Transform Player
    {
        get { return player; }
    }

    private EnemyBaseState currentState;
    public readonly PatrolState EnemyPatrolState = new PatrolState();
    public readonly ChaseState EnemyChaseState = new ChaseState();
    public readonly AttackState EnemyAttackState = new AttackState();
    public readonly DeathState EnemyDeathState = new DeathState();

    void Start()
    {
        lifes = 5;
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TransitionToState(EnemyPatrolState);
    }

    void Update()
    {
        currentState.Update(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionObject = collision;
        if (collisionObject.transform.tag == ("Bullet"))
            lifes--;
        currentState.OnCollisionEnter(this);
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void Delete()
    {
        StartCoroutine("WaitToDestroy");
        // StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
