using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy_IA : MonoBehaviour
{
    public float money = 0;
    public float moneyValue = 1;
    public static Economy_IA instance;
    public float upgradeCost = 5;
    public float upgradecount = 1;

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

   public void MoneyUpgrade()
    {
        if (money > upgradeCost && upgradecount <= 5)
        {
            Economy_IA.instance.money -= upgradeCost;
            Economy_IA.instance.moneyValue += (moneyValue * 0.25f);
            Economy_IA.instance.upgradeCost = upgradeCost * 4;
            upgradecount++;
        }
    }

    public bool Buy(int cost)
    {
            Economy_IA.instance.money -= cost;
        return true;
    }
}
