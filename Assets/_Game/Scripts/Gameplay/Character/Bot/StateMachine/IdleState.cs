using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IStateMachine<Bot>
{
    public float timer;
    public float randomTimer;
    public void OnEnter(Bot t)
    {
        timer = 0;
        randomTimer = Random.Range(1f, 3f);
    }

    public void OnExcute(Bot t)
    {
        timer += Time.deltaTime;
        Debug.Log(t.currenState);

        if (timer > randomTimer)
        {
            t.ChangStateMachine(new PatrolState());
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
