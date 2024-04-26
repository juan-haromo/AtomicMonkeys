using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base_shoot : MonoBehaviour
{
    [SerializeField] GameObject disparo;
    [SerializeField] private bool canShoot = false;
    [SerializeField] private float indexTime;
    [SerializeField] private int attackSpeed;
    [SerializeField] private float torretDamage;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("alguien entro al rango de la torreta");
            canShoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            canShoot = false;
        }
    }

    private void shoot()
    {
        Debug.Log("la basa fue disparada");
        GameObject shoot = Instantiate(disparo,transform);
        shoot.GetComponent<DefaultBulletScript>().bulletDamage = torretDamage;
        Rigidbody rb = shoot.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * shoot.GetComponent<DefaultBulletScript>().bulletSpeed);
    }
}
