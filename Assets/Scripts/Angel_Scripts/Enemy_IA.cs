using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    // cosas nesesarias
    [SerializeField] private int ammount = 0;
    [SerializeField] private int choiceLine = 0;
    [SerializeField] private int LineAmount = 0;
    [SerializeField] private const int TOTALLINES = 5;
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject melee;
    [SerializeField] private GameObject range;
    [SerializeField] private float indextime;
    [SerializeField] private float actionspeed;    
    [SerializeField] private List<GameObject> backnodes;
    [SerializeField] private List<GameObject> frondknodes;


    //Acceso al wave manager
    //WaveManager.instance
    // economy.instance.moneyS
    void Update()
    {
        if (indextime > actionspeed)
        {
            switch (Choice())
            {
                case 1:
                    PlaceTorret();
                    break;
                case 2:
                    Placeunit(choiceLine);
                    break;
                case 3:
                    PlaceEconomy();
                    break;
                default:
                    Debug.Log("waiting");
                    break;
            }
            indextime = 0;
        }
        indextime += Time.deltaTime;
    }

    //calculed the enemies total amoundt
    int totalAmount()
    {
        int amount = 0;
        for (int i = 0; i < TOTALLINES; i++)
        {
            amount += WaveManager.instance.enemies[i].totalAmount;
        }
        return amount;
    }
    void lineMoreAmount()
    {
        for (int i = 0; i < TOTALLINES; i++)
        {
            if (i == 0)
            {
                choiceLine = i;
                LineAmount = WaveManager.instance.enemies[i].totalAmount;
            }
            else if(LineAmount < WaveManager.instance.enemies[i].totalAmount)
            {
                choiceLine = i;
                LineAmount = WaveManager.instance.enemies[i].totalAmount;
            }
        }
    }
    int totalLinesAmount()
    {
        int _totalLines = 0;
        for (int i = 0; i < TOTALLINES; i++)
        {
            if (WaveManager.instance.enemies[i].totalAmount > 0)
            {
                _totalLines++;
            }
        }
        return _totalLines;
    }
    // here will choice whats gonna do
    int Choice()
    {
        if ((float)DefenseManager_IA.instance.turret.GetComponentInChildren<Stats>().Price() < Economy_IA.instance.money)
        {
            return 1;
        }
        else
        {
            ammount = totalAmount();
            if (ammount > 2)
            {
                lineMoreAmount();
                if (LineAmount > 2)
                {
                    return 2;
                }
            }
            else if (totalLinesAmount() >= 3)
            {
                defaultSpawn();
            }
            else if (Economy.instance.money > Economy.instance.upgradeCost)
            {
                return 3;
            }
        }
        return 4;
    }
    #region actions
    // here will place the torret
    void PlaceTorret()
    {
        Debug.Log("place torret");
        DefenseManager_IA.instance.objecToBuild = false;
        backnodes[0].GetComponent<Note_IA>().BuildTurret();
    }
    // here will place an unit
    void Placeunit(int line)
    {
        Debug.Log("place unit");
        int auxTanks, auxMelee, auxRange;
        auxTanks = WaveManager.instance.enemies[line].tankAmount;
        auxMelee = WaveManager.instance.enemies[line].meleeAmount;
        auxRange = WaveManager.instance.enemies[line].rangeAmount;


        if (auxTanks >= auxRange && auxTanks >= auxMelee)
        {
            if (melee.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
            {
                Debug.Log("si hay dinero para los melees");
                Spawners_IA.instance.ChangeUnitToSpawn(melee);
                Spawners_IA.instance.IA_Spawns(line);
            }
            else
            {
                Debug.Log("no hay dinero para los melees");
            }
        }
        else if (auxMelee >= auxRange && auxMelee >= auxTanks)
        {
            if (range.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
            {
                Debug.Log("si hay dinero para range");
                Spawners_IA.instance.ChangeUnitToSpawn(range);
                Spawners_IA.instance.IA_Spawns(line);
            }
            else
            {
                Debug.Log("no hay dinero para range");
            }
        }
        else if (auxRange >= auxTanks && auxRange >= auxMelee)
        {
            if (tank.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
            {
                Debug.Log("si hay dinero para hacer tanques");
                Spawners_IA.instance.ChangeUnitToSpawn(tank);
                Spawners_IA.instance.IA_Spawns(line);
            }
            else
            {
                Debug.Log("no hay dinero para los tanques");
            }
        }
        else 
        {
            if (melee.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
            {
                Debug.Log("hay dinero para la opcion default");
                Spawners_IA.instance.ChangeUnitToSpawn(melee);
                Spawners_IA.instance.IA_Spawns(line);
            }
            else
            {
                Debug.Log("no hay dinero para la opcion default");
            }
        }
    }

    // here will buy economy
    void PlaceEconomy()
    {
        Debug.Log("Economy");
        if(Economy_IA.instance.upgradecount < 5)
        {
            Debug.Log("Upgrade time");
            Economy_IA.instance.MoneyUpgrade();
        }
        else
        {
            defaultSpawn();
        }
    }

    void defaultSpawn()
    {
        int auxRandomUnit, auxRandomLine;
        auxRandomUnit = UnityEngine.Random.Range(1, 4);
        auxRandomLine = UnityEngine.Random.Range(0, 5);
        switch(auxRandomUnit)
        {
            // tanks
            case 1:
                if (tank.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
                {
                    Spawners_IA.instance.ChangeUnitToSpawn(tank);
                    Spawners_IA.instance.IA_Spawns(auxRandomLine);
                }
                break;
            // melee
            case 2:
                if (melee.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
                {
                    Spawners_IA.instance.ChangeUnitToSpawn(melee);
                    Spawners_IA.instance.IA_Spawns(auxRandomLine);
                }
                break;
            // range
            case 3:
                if (range.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
                {
                    Spawners_IA.instance.ChangeUnitToSpawn(range);
                    Spawners_IA.instance.IA_Spawns(auxRandomLine);
                }
                break;
            default:
                if (melee.GetComponentInChildren<Stats>().Cost < Economy.instance.money)
                {
                    Spawners_IA.instance.ChangeUnitToSpawn(melee);
                    Spawners_IA.instance.IA_Spawns(auxRandomLine);
                }
                break;
        }
    }
    #endregion 
}
