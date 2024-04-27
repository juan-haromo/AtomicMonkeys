using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBulletScript : MonoBehaviour
{
    public int bulletDamage;
    public float bulletSpeed;
    public float bulletLifeTime;
    public Vector3 direction;
    private Rigidbody rb;
    public string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("DestroyBullet", bulletLifeTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * bulletSpeed);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<UnitMovement>().UpdateHealth(bulletDamage);
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public void setDirection(Vector3 target)
    {
        direction = target - transform.position;
    }

    public void setTag(string tag)
    {
        targetTag = tag;
    }
}
