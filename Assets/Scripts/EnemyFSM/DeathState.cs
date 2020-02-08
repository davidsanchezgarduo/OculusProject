using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : EnemyBaseState
{
    public override void EnterState(EnemyFSM enemy)
    {
        enemy.EnemyAnimator.SetTrigger("Dead");
        enemy.Delete();
    }

    public override void OnCollisionEnter(EnemyFSM enemy)
    {

    }

    public override void Update(EnemyFSM enemy)
    {

    }
}
