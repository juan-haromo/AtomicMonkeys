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
    [SerializeField] private const int totalLines = 5;
    [SerializeField] Economy_IA EIA;
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject melee;
    [SerializeField] private GameObject range;
    //Acceso al wave manager
    //WaveManager.instance
    // economy.instance.moneyS
    void Update()
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
    }

    //calculed the enemies total amoundt
    int totalAmount()
    {
        int amount = 0;
        for (int i = 0; i < totalLines; i++)
        {
            amount += WaveManager.instance.enemies[i].totalAmount;
        }
        return amount;
    }
    void lineMoreAmount()
    {
        for (int i = 0; i < totalLines; i++)
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
    // here will choice whats gonna do
    int Choice()
    {
        ammount = totalAmount();
        if (ammount > 2)
        {
            lineMoreAmount();
           if(LineAmount > 2 )
            {
                return 2;
            }
        }
        else
        {
            if(true)
            {

            }
        }
        int auxChoice = 0;
        return auxChoice;
    }

    #region actions
    // here will place the torret
    void PlaceTorret()
    {

    }
    // here will place an unit
    void Placeunit(int line)
    {
        int auxTanks, auxMelee, auxRange;
        auxTanks = WaveManager.instance.enemies[line].tankAmount;
        auxMelee = WaveManager.instance.enemies[line].meleeAmount;
        auxRange = WaveManager.instance.enemies[line].rangeAmount;

        if (auxRange >= auxTanks && auxRange >= auxMelee)
        {
            Spawners_IA.instance.ChangeUnitToSpawn(tank);
            Spawners_IA.instance.IA_Spawns(line);
        }
        else if (auxTanks >= auxRange && auxTanks >= auxMelee)
        {
            Spawners_IA.instance.ChangeUnitToSpawn(melee);
            Spawners_IA.instance.IA_Spawns(line);
        }
        else if (auxMelee >= auxRange && auxMelee >= auxTanks)
        {
            Spawners_IA.instance.ChangeUnitToSpawn(range);
            Spawners_IA.instance.IA_Spawns(line);
        }

    }

    // here will buy economy
    void PlaceEconomy()
    {
        Economy_IA.instance.MoneyUpgrade();
    }
    #endregion 
}
