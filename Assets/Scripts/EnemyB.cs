using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    // Start is called before the first frame update

    // Update is called once per frame
    public override void GetDamage(int damage)
    {
        health -= damage;



        if (health <= 0)
        {
            Die();

        }

    }
}
