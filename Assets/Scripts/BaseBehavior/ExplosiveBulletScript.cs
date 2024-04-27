using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExplosiveBulletScript : MonoBehaviour
{
    public GameObject enemyExplosionPrefab;
    public GameObject allyExplosionPrefab;
    public string targetTag;

    private void OnDestroy()
    {
        if(targetTag == "Enemy")
        {
            Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
        }
        else if(targetTag == "Ally")
        {
            Instantiate(allyExplosionPrefab, transform.position, transform.rotation);
        }
    }
}
