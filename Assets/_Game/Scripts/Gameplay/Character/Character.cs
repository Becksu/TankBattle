using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public Ranger ranger;
    public bool isDie = false;
    private void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnAwake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void OnInit()
    {

    }
    public virtual void OnUpdate()
    {

    }
    public void CharacterDie()
    {
        ranger.listCharacter.Clear();
    }
}
