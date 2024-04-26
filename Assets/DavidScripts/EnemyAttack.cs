using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
        {
            collision.gameObject.GetComponent<BaseHealth>().ChangeHealth(damage);
            Destroy(this.gameObject);
        }
    }
}
