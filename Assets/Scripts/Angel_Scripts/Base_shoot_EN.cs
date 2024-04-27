using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base_shoot : MonoBehaviour
{
    [SerializeField] GameObject disparo;
    [SerializeField] GameObject target;
    [SerializeField] private bool canShoot = false;
    [SerializeField] private float indexTime;
    [SerializeField] private int attackSpeed;
    [SerializeField] private int torretDamage;

    private void Update()
    {
        if (canShoot)
        {
            if(indexTime > attackSpeed)
            {
                Debug.Log("the torret will shoot");
                shoot();
                indexTime = 0;
            }
            indexTime += Time.deltaTime;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ally"))
        {
            Debug.Log("alguien esta en el rango de la torreta");
            target = other.gameObject;
            canShoot = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ally"))
        {
            canShoot = false;
        }
    }

    private void shoot()
    {
        Debug.Log("la bala fue disparada");
        GameObject shoot = Instantiate(disparo,transform.position,transform.rotation);
        shoot.GetComponent<DefaultBulletScript>().bulletDamage = torretDamage;
        Rigidbody rb = shoot.GetComponent<Rigidbody>();
        rb.AddForce((target.transform.position-transform.position) * shoot.GetComponent<DefaultBulletScript>().bulletSpeed);
    }
}
