using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other )
    {
        if (other.CompareTag ("Enemy"))
        {
            other.GetComponent<Enemy>().GetDamage(1);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
