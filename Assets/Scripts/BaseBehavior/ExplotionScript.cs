using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionScript : MonoBehaviour
{
    public float explotionLifeTime;
    public float explotionDamage;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", explotionLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BaseHealth>().ChangeHealth(explotionDamage);
        }
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
