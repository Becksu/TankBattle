using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackState : IStateMachine<Bot>
{
    public float timer;
    public void OnEnter(Bot t)
    {
        t.StopMove();
        t.Atack();
        timer = 0;
    }

    public void OnExcute(Bot t)
    {
        timer += Time.deltaTime;
        if (timer > 1.3f)
        {
            t.ChangStateMachine(new PatrolState());
        }
        if (t.ranger.CharacterInRanger()&& timer>1.3f)
        {
            t.ChangStateMachine(new AtackState());
        }
    }

    public void OnExit(Bot t)
    {
         
    }
}
