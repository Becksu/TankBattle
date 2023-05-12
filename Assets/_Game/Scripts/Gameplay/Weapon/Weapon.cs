using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Character character;
    public Character Character
    {
        get { return character; }
        set { character = value; }
    }
    public PoolType type;
    public Rigidbody rb;
    public Vector3 direction;
    public float speed;
    public int characterWeaponId;
    public int weaponPower;
    public float timerMove;


    private void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        OnInit();
    }

    void Update()
    {
        OnUpdate();
    }
    private void FixedUpdate()
    {
        OnFixUpdate();
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
    public virtual void OnFixUpdate()
    {

    }
    public virtual void DespawnWeapon()
    {
        MuitiplePool.Instance.ReturnGameObject(type, gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            if (characterWeaponId != character.characterID)
            {
                character.Damage(weaponPower,Character);
                Invoke(nameof(DespawnWeapon), .2f);
            }
        }
    }
}
