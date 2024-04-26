using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Inicialize stats
    [SerializeField] private int health;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int damage;
    [SerializeField] private int price;
    [SerializeField] private bool isdeath = false;
    [SerializeField] private int type;
    [SerializeField] private float attackSpeed;

    // funcions thats return valeus
    #region Valeus
    public int Health()
    {
        return health;
    }
    public float MovementSpeed()
    {
        return movementSpeed;
    }

    public int Damage()
    {
        return damage;
    }

    public int Price() 
    { 
    return price;
    }

    public bool IsDeath() 
    {
        return isdeath;
    }

    public float AttackSpeed()
    {
        return attackSpeed;
    }
    #endregion

    // funtion for take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            isdeath = true;
        }
    }

    public int Cost { get { return price; } }
}
