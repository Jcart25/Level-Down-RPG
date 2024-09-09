using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;
    public float timer;
    public bool Attacking = false;
    public float AttackTime;
    public float WaitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Attacking == true)
        {
            //AttackTime = 0; 
            StartAttacking();
            //StartAttacking();
            //StartAttacking();
            /*
            AttackTime = 5;
            AttackTime -= Time.deltaTime;
            if(AttackTime <= 0)
            {
                Attacking = false;
            }

            timer += Time.deltaTime;

            if (timer > 1.5)
            {
                timer = 0;
                shoot();
            }
            */
        }
        
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }

    public void StartAttacking()
    {
        
        //AttackTime = 0;
        Attacking = true;
        AttackTime += Time.deltaTime;

        if (AttackTime >= 6)
        {
            Attacking = false;
        }
        
        //timer = 0;
        timer += Time.deltaTime;

        if (timer > 1.5)
        {
            timer = 0;
            shoot();
        }
    }

    public void TrueAttack()
    {
        Attacking = true;
    }

    public void ResetAttackValues()
    {
        if(AttackTime >= 6)
        {
            AttackTime -= 6;
        }
    }
}

