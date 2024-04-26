using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    public float money=0;
    public float moneyValue=1;
    public static Economy instance;
    public float upgradeCost;

    // Update is called once per frame
    private void Awake()
    {
        if (instance == null )
        {instance=this; }
        else
        { Destroy(this); }
    }
    void Update()
    {

        money +=(moneyValue * Time.deltaTime);
        moneyDisplay.text = "Money= " + (int)money;

    }

    void MoneyUpgrade()
    {
        if(money>upgradeCost)
        Economy.instance.moneyValue += (moneyValue*.75f);
        Economy.instance.money -= upgradeCost;
        Economy.instance.upgradeCost = upgradeCost*2;

    }

    public bool Buy(int cost)
    {

        if (money > cost)
        { Economy.instance.money -= cost;
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

}