using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExplosiveBulletScript : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
