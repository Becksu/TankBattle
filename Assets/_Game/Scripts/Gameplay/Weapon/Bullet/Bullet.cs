using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    public override void OnInit()
    {
        base.OnInit();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    public override void OnFixUpdate()
    {
        base.OnFixUpdate();
        MoveBullet();
    }
    public void MoveBullet()
    {
        timerMove += Time.deltaTime;
        rb.velocity = direction * speed * Time.deltaTime;
        if (timerMove > 2f)
        {
            timerMove = 0;
            DespawnWeapon();
        }
    }

}
