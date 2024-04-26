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
        if (Input.GetKeyUp(KeyCode.Q))
        {
            SpawnUnit(unitToSpawn, 0);
            unitToSpawn = null;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            SpawnUnit(unitToSpawn, 1);
            unitToSpawn = null;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            SpawnUnit(unitToSpawn, 2);
            unitToSpawn = null;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            SpawnUnit(unitToSpawn, 3);
            unitToSpawn = null;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            SpawnUnit(unitToSpawn, 4);
            unitToSpawn = null;
        }
    }

    public void SpawnUnit(GameObject unitToSpwan, int positionToSpwan)
    {
        //Get enemy script to check price
        if (Economy.instance.Buy(unitToSpawn.GetComponentInChildren<Stats>().Cost))//Script economy
        {
            Instantiate(unitToSpwan, spawnPoints[positionToSpwan].position, unitToSpwan.transform.rotation);
        }
    }

    public void ChangeUnitToSpawn(GameObject _unitToSpawn)
    {
        unitToSpawn = _unitToSpawn;
    }
}