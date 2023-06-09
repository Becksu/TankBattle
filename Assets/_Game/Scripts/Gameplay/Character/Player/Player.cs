using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public JoystickControler joystick;
    [Range(0, 10)] public float speed;
    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnUpdate()
    {
        if (isDie) currenAnim = null; StopMove();
        base.OnUpdate();
        Move();
    }
    protected override void CharacterDie()
    {
        LevelManager.Instance.LoseGame();
    }
    public void Move()
    {
        if (GameManager.Instance.IsStateGame(GameState.Gameplay))
        {
            if (Input.GetMouseButton(0))
            {
                if (isDie) return;
                rb.velocity = joystick.direction * speed * Time.deltaTime;
                Vector3 dirc = joystick.direction;
                float angle = Mathf.Atan2(dirc.x, dirc.z) * Mathf.Rad2Deg;
                Quaternion rotate = Quaternion.Euler(0, angle, 0);
                rb.rotation = rotate;
                ChangAnim(Constans.ANIM_MOVE);

            }
            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
                Atack();
            }
        }
    }
    public void StopMove()
    {

        rb.velocity = Vector3.zero;
    }
}
