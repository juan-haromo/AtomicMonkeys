using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Stats st;
    int health;
    //stats
    private void Awake()
    {
        st = GetComponent<Stats>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se estan atacando");
        UpdateHealth(other.gameObject.GetComponent<Stats>().Damage());
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Ya no");
    }

    void UpdateHealth(int damageTaken)
    {
        st.TakeDamage(damageTaken);
    }
}
