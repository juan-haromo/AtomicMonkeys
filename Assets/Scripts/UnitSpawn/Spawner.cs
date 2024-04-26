using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject unitToSpawn;
    [SerializeField] private List<Transform> spawnPoints;
    public static Spawner instance;

    private void Start()
    {
        if (instance == null)
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            SpawnUnit(unitToSpawn, randomIndex);
        }
    }

    public void SpawnUnit(GameObject unitToSpwan, int positionToSpwan)
    {
        //Get enemy script to check price
        if (true)//Script economy
        {

            Instantiate(unitToSpwan, spawnPoints[positionToSpwan].position, unitToSpwan.transform.rotation);
        }
    }
}