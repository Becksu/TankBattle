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
    [SerializeField] protected ParticleSystem fxDie;
    [SerializeField] protected Animator animator;
    protected string currenAnim;

    public Ranger ranger;
    public bool isDie => hp <= 0;
    public Transform tF;
    public int characterID;
    public int score;
    private void Awake()
    {
        OnAwake();
    }

    void Update()
    {
        if (GameManager.Instance.IsStateGame(GameState.Gameplay))
        {
            OnUpdate();
        }
    }

    public virtual void OnAwake()
    {
        rb = GetComponent<Rigidbody>();
        tF = transform;
    }
    public virtual void OnInit()
    {
        ranger.listCharacter.Clear();
        Material mat = GetMaterial();
        for(int i = 0; i < meshrender.Length; i++)
        {
            meshrender[i].material = mat;
        }
        score = 0;
        hp = 100;
        ChangAnim(Constans.ANIM_MOVE);
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
                fxDie.Play();
                SoundsManager.Instance.SFXMusic(Constans.SFX_Explode);
                ChangAnim(Constans.ANIM_DIE);
                Invoke(nameof(CharacterDie), 1f);
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
            SoundsManager.Instance.SFXMusic(Constans.SFX_Gun);
            ChangAnim(Constans.ANIM_ATACK);
        }
        else
        {
            ChangAnim(Constans.ANIM_MOVE);
        }
    }
    public virtual void ChangAnim(string anim)
    {
        if (currenAnim != null)
        {
            animator.ResetTrigger(currenAnim);
        }
        currenAnim = anim;
        if(currenAnim != null)
        {
            animator.SetTrigger(currenAnim);
        }
    }
}
