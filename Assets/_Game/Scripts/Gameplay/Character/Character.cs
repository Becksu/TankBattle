using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    [Range(0, 100)][SerializeField] protected int hp;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected PoolType weaponTypePool;
    [SerializeField] protected PoolType characterPool;
    [SerializeField] protected Transform pointWeapon;
    [SerializeField] protected ParticleSystem fxScore;

    public Ranger ranger;
    public bool isDie => hp <= 0;
    public Transform tF;
    public int characterID;
    public int score;
    private void Awake()
    {
        OnAwake();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnAwake()
    {
        rb = GetComponent<Rigidbody>();
        tF = transform;
    }
    public virtual void OnInit()
    {
        ranger.listCharacter.Clear();
        meshrender.material = GetMaterial();
        score = 0;
        hp = 100;
    }
    public virtual void OnUpdate()
    {

    }
    protected virtual void CharacterDie()
    {

    }
    public void Damage(int damage, Character character)
    {
        if (!isDie)
        {
            hp -= damage;
            if (isDie)
            {
                AddScore(character);
                ranger.listCharacter.Clear();
                Invoke(nameof(CharacterDie), 2f);
            }
        }
    }
    public void AddScore(Character character)
    {
        character.score++;
        character.fxScore.Play();
        UIGamePlay.Instance.SetScoreText();
    }
    public void Atack()
    {
        if (ranger.CharacterInRanger())
        {
            tF.LookAt(ranger.CharacterInRanger().transform.position);
            GameObject go = MuitiplePool.Instance.GetGameObject(weaponTypePool, pointWeapon.position);
            Weapon weapon = go.GetComponent<Weapon>();
            weapon.direction = ranger.CharacterInRanger().transform.position - tF.position;
            weapon.transform.rotation = Quaternion.LookRotation(weapon.direction);
            weapon.characterWeaponId = characterID;
            weapon.Character = this;
        }
    }
}
