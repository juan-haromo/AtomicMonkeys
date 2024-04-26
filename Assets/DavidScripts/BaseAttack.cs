using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public float bulletRate;
    private Vector2 target;
    public GameObject[] enemies;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shootBullet", 0f, bulletRate);
    }

    // Update is called once per frame
    void Update()
    {
        target = getFirstEnemy().transform.position;
    }

    private void shootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<DefaultBulletScript>().setDirection(target);
    }

    private GameObject getFirstEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                return enemies[i];
            }
        }
        return null;
    }
}
