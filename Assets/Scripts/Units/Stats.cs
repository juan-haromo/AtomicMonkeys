using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int damage;
    [SerializeField] private int price;
    [SerializeField] private bool isdeath = false;

    public int Health()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) 
        { 
            health = 0;
            isdeath = true;
        }
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
}
