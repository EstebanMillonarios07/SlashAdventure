using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    // Start is called before the first frame update
    [SerializeField]int health = 3;
    // Update is called once per frame
    public void GetDamage(int damage) { health -= damage; } 
    
        
    
}
