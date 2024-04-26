using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBulletScript : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletLifeTime;
    public Vector2 direction;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("destroyBullet", bulletLifeTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BaseHealth>().ChangeHealth(bulletDamage);
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public void setDirection(Vector2 target)
    {
        direction = target - new Vector2(transform.position.x, transform.position.y);
    }
}
