using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine<T>
{
    public void OnEnter(T t);
    public void OnExcute(T t);
    public void OnExit(T t);
}
