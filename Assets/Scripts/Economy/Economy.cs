using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    public float money = 0;
    public float moneyValue = 1;
    public static Economy instance;
    public float upgradeCost;
    public int upgradeCount = 1;

    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        { Destroy(this); }
    }
    void Update()
    {

        money += (moneyValue * Time.deltaTime);
        moneyDisplay.text = "Money= " + (int)money;

    }

    void MoneyUpgrade()
    {
        if (money > upgradeCost && upgradeCount <= 5)
        {
            Economy_IA.instance.money -= upgradeCost;
            Economy_IA.instance.moneyValue += (moneyValue * 0.25f);
            Economy_IA.instance.upgradeCost = upgradeCost * 4;
            upgradeCount++;
        }
    }

    public bool Buy(int cost)
    {

        if (money > cost)
        {
            Economy.instance.money -= cost;
            return true;
        }
        StartCoroutine(CantBuy());
        return false;

    }
    private IEnumerator CantBuy()
    {
        instance.moneyDisplay.color = Color.red;
        yield return new WaitForSeconds(1.5f);
        instance.moneyDisplay.color = Color.white;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

}