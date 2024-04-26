using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int x; 
    public int y;

    GameObject defensePlaced;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject turret;
    public bool objecToBuild;//true = wall, false = turret

    public void BuildTurret()
    {
        if(defensePlaced == null)
        {
            if(objecToBuild) 
            { 
                defensePlaced = (GameObject)Instantiate(wall,transform.position,transform.rotation); 
            }
            else
            {
                defensePlaced = (GameObject)Instantiate(turret, transform.position, transform.rotation);
            }
            WaveManager.instance.towers[x][y] = true;
        }
    }
}
