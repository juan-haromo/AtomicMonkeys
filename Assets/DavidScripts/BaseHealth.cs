using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth;
    [SerializeField] private float health;

    private void Start()
    {
        health = maxHealth;
    }

    public void ChangeHealth(float ammount)
    {
        health += ammount;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
