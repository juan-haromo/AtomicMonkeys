using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBulletScript : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletLifeTime;
    public Vector3 direction;
    private Rigidbody rb;
    public Transform target;

    // Start is called before the first frame update
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("destroyBullet", bulletLifeTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BaseHealth>().ChangeHealth(bulletDamage);
            destroyBullet();
        }
    }

    private void destroyBullet()
    {
        Destroy(this.gameObject);
    }

    public void setDirection()
    {
        direction = target.position - gameObject.transform.position;
    }
}
