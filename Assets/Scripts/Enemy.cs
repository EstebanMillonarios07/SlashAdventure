using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public virtual void GetDamage(int damage)
    {

    }


    public virtual void Die()
    {
        Debug.Log("nos morimos");
        //gameObject.SetActive(false);
        Destroy(gameObject);

    }
}

