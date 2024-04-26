using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MonoBehaviour
{
    public static DefenseManager instance;
    public GameObject wall;
    public GameObject turret;
    public bool objecToBuild = false;//true = wall, false = turret

    private void Awake()
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
}
