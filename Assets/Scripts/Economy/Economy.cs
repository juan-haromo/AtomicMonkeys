using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public TextMeshPro moneyDisplay;
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

    bool Buy(int cost)
    {

        if (money > cost)
        { Economy.instance.money -= cost;
            return true;
        }
        else
        { //add player feedback
            StartCoroutine(CantBuy());
        }
        return false;
    
    }
    private IEnumerator CantBuy()
    { Economy.instance.moneyDisplay.color = Color.red;
        new WaitForSeconds(1f);
        Economy.instance.moneyDisplay.color = Color.white;
        yield return null;
    }

}