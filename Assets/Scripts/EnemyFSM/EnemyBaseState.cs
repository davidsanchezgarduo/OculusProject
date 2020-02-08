using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyFSM enemy);
    public abstract void Update(EnemyFSM enemy);
    public abstract void OnCollisionEnter(EnemyFSM enemy);
}
