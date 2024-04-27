using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager_IA : MonoBehaviour
{
    public static DefenseManager_IA instance;
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
