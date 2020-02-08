using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    public ParticleSystem dust;
    public ParticleSystem dissolve;

    public float maxHealth = 5;
    public float currentHealth;

    private Material baseMaterial;
    public Material damageMaterial;
    public Material deadMaterial;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        baseMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        dissolve.Pause();
    }

    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        // Debug.Log("Distance to player: " + enemyAgent.remainingDistance);
        if (currentHealth > 0)
        {
            if (enemyAgent.remainingDistance <= 1.2f && enemyAgent.hasPath)
            {
                enemyAnimator.SetFloat("Speed", 0f);
                enemyAnimator.SetBool("Punch", true);
            }
            else
            {
                enemyAnimator.SetFloat("Speed", enemyAgent.speed);
                enemyAnimator.SetBool("Punch", false);
            }
        }
        else
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        GetComponentInChildren<SkinnedMeshRenderer>().material = damageMaterial;
    }

    public void Die()
    {
        enemyAnimator.SetTrigger("Dead");
        enemyAgent.isStopped = true;
        GetComponentInChildren<SkinnedMeshRenderer>().material = deadMaterial;
        dissolve.Play();
        Collider collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().score += 1;
            Destroy(this.gameObject);
        }
    }

    public void PlayDust()
    {
        dust.Play();
    }

    public void StopDust()
    {
        dust.Stop();
    }
}
