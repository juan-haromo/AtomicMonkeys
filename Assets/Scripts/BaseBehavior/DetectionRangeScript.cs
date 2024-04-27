using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRangeScript : MonoBehaviour
{
    public List<Transform> enemiesInRange;
    public string targetTag;
    public BaseAttack baseAttack;
    private bool hasEnemiesNear;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<Transform>();
    }

    private void Update()
    {
        if (hasEnemiesNear)
        {
            if(enemiesInRange[0] == null)
            {
                enemiesInRange.Remove(enemiesInRange[0]);
                if (enemiesInRange.Count == 0)
                {
                    baseAttack.StopShooting();
                    hasEnemiesNear = false;
                }
            }
        }
    }

    public int getEnemyCount()
    {
        return enemiesInRange.Count;
    }
    
    public Transform getEnemyFromIndex(int index)
    {
        if(enemiesInRange.Count > 0 && index < enemiesInRange.Count)
        {
            if (enemiesInRange[index] != null)
            {
                return enemiesInRange[index];
            }
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (enemiesInRange.Count == 0)
            {
                enemiesInRange.Add(other.gameObject.transform);
                baseAttack.StartShooting();
                hasEnemiesNear = true;
            }
            else
            {
                enemiesInRange.Add(other.gameObject.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            enemiesInRange.Remove(other.gameObject.transform);
            if (enemiesInRange.Count == 0)
            {
                baseAttack.StopShooting();
                hasEnemiesNear = false;
            }
        }
    }
}
