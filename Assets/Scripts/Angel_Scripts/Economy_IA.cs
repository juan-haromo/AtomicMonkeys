using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy_IA : MonoBehaviour
{
    public float money = 0;
    public float moneyValue = 1;
    public static Economy_IA instance;
    public float upgradeCost = 5;

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        { Destroy(this); }
    }
    private void Update()
    {
        money += (moneyValue * Time.deltaTime);
    }

    void MoneyUpgrade()
    {
        if (money > upgradeCost)
        {
            Economy_IA.instance.moneyValue += (moneyValue * .75f);
            Economy_IA.instance.money -= upgradeCost;
            Economy_IA.instance.upgradeCost = upgradeCost * 2;
        }
    }

    public bool Buy(int cost)
    {
        if (money > cost)
        {
            Economy.instance.money -= cost;
            return true;
        }
        return false;
    }
}
