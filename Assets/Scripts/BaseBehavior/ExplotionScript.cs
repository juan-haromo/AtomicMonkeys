using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionScript : MonoBehaviour
{
    public float explotionLifeTime;
    public int explotionDamage;
    public string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", explotionLifeTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<UnitMovement>().UpdateHealth(explotionDamage);
        }
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
