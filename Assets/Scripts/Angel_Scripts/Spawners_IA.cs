using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners_IA : MonoBehaviour
{
    public GameObject unitToSpawn;
    [SerializeField] private List<Transform> spawnPoints;
    public static Spawners_IA instance;

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
    public void IA_Spawns(int line)
    {
        switch(line)
        {
            case 0:
                SpawnUnit(unitToSpawn, 0);
                break;
            case 1:
                SpawnUnit(unitToSpawn, 1);
                break;
            case 2:
                SpawnUnit(unitToSpawn, 2);
                break;
            case 3:
                SpawnUnit(unitToSpawn, 3);
                break;
            case 4:
                SpawnUnit(unitToSpawn, 4);
                break;
            default:
                Debug.Log("algo fallo en la matriz");
                break;
        }
    }
    public void SpawnUnit(GameObject _unitToSpwan, int positionToSpwan)
    {
        if (Economy.instance.Buy(_unitToSpwan.GetComponentInChildren<Stats>().Cost))
        {
            Instantiate(_unitToSpwan, spawnPoints[positionToSpwan].position, _unitToSpwan.transform.rotation);
            unitToSpawn = null;
        }
    }

    public void ChangeUnitToSpawn(GameObject _unitToSpawn)
    {
        unitToSpawn = _unitToSpawn;
    }
}
