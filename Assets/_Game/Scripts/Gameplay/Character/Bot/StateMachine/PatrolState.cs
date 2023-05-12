using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IStateMachine<Bot>
{
    public float timer;
    public float randomTimer;
    public void OnEnter(Bot t)
    {
        timer = 0;
        randomTimer = Random.Range(2f, 4f);
        Debug.Log(t.currenState);
    }

    public void OnExcute(Bot t)
    {
        timer += Time.deltaTime;
        if(timer<randomTimer)
        {
            t.MoveBot();
        }
        else
        {
            t.ChangStateMachine(new IdleState());
        }
        if (t.ranger.CharacterInRanger()&&timer>1f)
        {
            t.ChangStateMachine(new AtackState());
        }
    }

    public void OnExit(Bot t)
    {

    }
}
