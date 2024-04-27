using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRangeScript : MonoBehaviour
{
    public List<Transform> enemiesInRange;
    public string targetTag;
    public BaseAttack baseAttack;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<Transform>();
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
            }
        }
    }
}
