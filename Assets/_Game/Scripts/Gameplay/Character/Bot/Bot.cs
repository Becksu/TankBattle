using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public IStateMachine<Bot> currenState;
    public NavMeshAgent meshAgent;


    public override void OnInit()
    {
        base.OnInit();
        meshAgent.isStopped = false;
        ChangStateMachine(new IdleState());
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        OnExcuteStateMachine();
    }
    protected override void CharacterDie()
    {
        base.CharacterDie();
        MuitiplePool.Instance.ReturnGameObject(PoolType.Bot, gameObject);
        int random = Random.Range(1, 3);
        LevelManager.Instance.countDie--;
        if (LevelManager.Instance.countDie == 0)
        {
            LevelManager.Instance.WinGame();
        }
        Invoke(nameof(Spawner), random);
       
    }
    public void Spawner()
    {
        LevelManager.Instance.SpawnerBot();
    }
    public void OnExcuteStateMachine()
    {
        if (GameManager.Instance.IsStateGame(GameState.Gameplay))
        {
            if (currenState != null)
            {
                if (!isDie)
                {
                    currenState.OnExcute(this);
                }
                else
                {
                    meshAgent.isStopped = true;
                }
            }
        }

    }
    public void ChangStateMachine(IStateMachine<Bot> state)
    {
        if (currenState != null)
        {
            currenState.OnExit(this);
        }
        currenState = state;
        if (currenState != null)
        {
            currenState.OnEnter(this);
        }
    }

    private Vector3 SetTarget()
    {
        Vector3 target = new Vector3();
        target.x = Random.Range(-74, 74);
        target.z = Random.Range(-74, 74);
        target.y = tF.position.y;
        return target;
    }

    public void MoveBot()
    {
        meshAgent.isStopped = false;
        meshAgent.SetDestination(SetTarget());
        ChangAnim(Constans.ANIM_MOVE);
    }
    public void StopMove()
    {
        meshAgent.isStopped = true;
    }
}
