using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class BarGame : MonoBehaviour
{
    [Header("Unit 1")]
    public Image unitl1;
    public float cooldown1 = 1;
    bool isCooldown = false;
    public KeyCode unit1;

    [Header("Unit 2")]
    public Image unitl2;
    public float cooldown2 = 1;
    bool isCooldown2 = false;
    public KeyCode unit2;

    [Header("Unit 3")]
    public Image unitl3;
    public float cooldown3 = 1;
    bool isCooldown3 = false;
    public KeyCode unit3;

    [Header("Base")]
    public Image unitl4;
    public float cooldown4 = 1;
    bool isCooldown4 = false;
    public KeyCode unit4;

    [Header("Defense/Attack")]
    public Image Attack;
    public Image Defense;
    public float cooldown5 = 1;
    bool isCooldown5 = false;
    public KeyCode unit5;
    public KeyCode unit6;

    [Header("MejoraBase")]
    public Image unitl7;
    public float cooldown7 = 1;
    bool isCooldown7 = false;
    public KeyCode unit7;

    [Header("Enemies")]
    public GameObject enemie1;
    public GameObject enemie2; 
    public GameObject enemie3;



    private void Start()
    {
        unitl1.fillAmount = 0;
        unitl2.fillAmount = 0;
        unitl3.fillAmount = 0;
        unitl4.fillAmount = 0;
        unitl7.fillAmount = 0;

    }

    private void Update()
    {
        Unitspawn();
        Unitspawn2();
        Unitspawn3();
        Unitspawn4();
        TowerSwap();
        Unitspawn5();

    }

    void Unitspawn()
    {
        if(Input.GetKey(unit1) && isCooldown == false) 
        {
            isCooldown = true;
            unitl1.fillAmount = 1;
            Spawner.instance.ChangeUnitToSpawn(enemie1);
        }

        if(isCooldown)
        {
            unitl1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(unitl1.fillAmount <= 0) 
            {
                unitl1.fillAmount = 0;
                isCooldown = false;
            }
        }


    }

    void Unitspawn2()
    {
        if (Input.GetKey(unit2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            unitl2.fillAmount = 1;
            Spawner.instance.ChangeUnitToSpawn(enemie2);
        }

        if (isCooldown2)
        {
            unitl2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (unitl2.fillAmount <= 0)
            {
                unitl2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Unitspawn3()
    {
        if (Input.GetKey(unit3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            unitl3.fillAmount = 1;
            Spawner.instance.ChangeUnitToSpawn(enemie3);

        }

        if (isCooldown3)
        {
            unitl3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (unitl3.fillAmount <= 0)
            {
                unitl3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Unitspawn4()
    {
        if (Input.GetKey(unit4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            unitl4.fillAmount = 1;

        }

        if (isCooldown4)
        {
            unitl4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (unitl4.fillAmount <= 0)
            {
                unitl4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }

    void TowerSwap()
    {
        if (Input.GetKey(unit5) && isCooldown5 == false)
        {
            isCooldown5 = true;
            Attack.fillAmount = 1;
            Defense.fillAmount = 1;
        }

        if (Input.GetKey(unit6) && isCooldown5 == false)
        {
            isCooldown5 = true;
            Attack.fillAmount = 1;
            Defense.fillAmount = 1;
        }

        if (isCooldown5)
        {
            Attack.fillAmount -= 1 / cooldown5 * Time.deltaTime;
            Defense.fillAmount -= 1 / cooldown5 * Time.deltaTime;

            if (Attack.fillAmount <= 0)
            {
                Attack.fillAmount = 0;
                Defense.fillAmount = 0;
                isCooldown5 = false;
            }
        }
    }

    void Unitspawn5() // Upgrade Base
    {
        if (Input.GetKey(unit7) && isCooldown7 == false)
        {
            isCooldown7 = true;
            unitl7.fillAmount = 1;
            // Economy.instance.MoneyUpgrade();

        }

        if (isCooldown7)
        {
            unitl7.fillAmount -= 1 / cooldown7 * Time.deltaTime;

            if (unitl7.fillAmount <= 0)
            {
                unitl7.fillAmount = 0;
                isCooldown7 = false;
            }
        }
    }
}
