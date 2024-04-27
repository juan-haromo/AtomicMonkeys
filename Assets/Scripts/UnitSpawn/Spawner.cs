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
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            SpawnUnit(unitToSpawn, 1);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
           SpawnUnit(unitToSpawn, 2);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            SpawnUnit(unitToSpawn, 3);
            
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            SpawnUnit(unitToSpawn, 4);
            
            
        }
    }

    public void SpawnUnit(GameObject _unitToSpwan, int positionToSpwan)
    {
        if (Economy.instance.Buy(_unitToSpwan.GetComponentInChildren<Stats>().Cost))
        {
            Instantiate(_unitToSpwan, spawnPoints[positionToSpwan].position, _unitToSpwan.transform.rotation);
            WaveManager.instance.enemies[positionToSpwan].AddEnemy(_unitToSpwan.GetComponentInChildren<Stats>().Type);
            unitToSpawn = null;
        }
    }

    public void ChangeUnitToSpawn(GameObject _unitToSpawn)
    {
        unitToSpawn = _unitToSpawn;
    }
}