using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private List<Transform> spawnPoints;
    public static UnitSpawn instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {   int randomIndex = Random.Range(0, spawnPoints.Count);
            SpawnUnit(prefab, randomIndex);
        }
    }

    public void SpawnUnit(GameObject unitToSpwan, int positionToSpwan)
    {
        //Get enemy script to check price
        if (true)//Script economy
        {
            Instantiate(unitToSpwan, spawnPoints[positionToSpwan].position,unitToSpwan.transform.rotation);
        }
    }
}
