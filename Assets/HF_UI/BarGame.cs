using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarGame : MonoBehaviour
{
    [Header("Unit 1")]
    public Image unitl1;
    public float cooldown1 = 1;
    bool isCooldown = false;
    public KeyCode unit1;
    public GameObject Buttonu1;

    [Header("Unit 2")]
    public Image unitl2;
    public float cooldown2 = 1;
    bool isCooldown2 = false;
    public KeyCode unit2;
    public GameObject Buttonu2;

    [Header("Unit 3")]
    public Image unitl3;
    public float cooldown3 = 1;
    bool isCooldown3 = false;
    public KeyCode unit3;
    public GameObject Buttonu3;

    [Header("Base")]
    public Image unitl4;
    public float cooldown4 = 1;
    bool isCooldown4 = false;
    public KeyCode unit4;
    public GameObject ButtonBase;

    [Header("Defense/Attack")]
    public Image Attack;
    public Image Defense;
    public float cooldown5 = 1;
    bool isCooldown5 = false;
    public KeyCode unit5;
    public KeyCode unit6;
    public GameObject ButtonA;
    public GameObject ButtonD;

    [Header("MejoraBase")]
    public Image unitl7;
    public float cooldown7 = 1;
    bool isCooldown7 = false;
    public KeyCode unit7;
    public GameObject ButtonUpdateBase;

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

    void Unitspawn() // First unit
    {
        if(Input.GetKey(unit1) && isCooldown == false) 
        {
            isCooldown = true;
            unitl1.fillAmount = 1;
            Buttonu1.SetActive(false);
        }

        CooldownUni1();
    }

    public void ButtonUnit1()
    {
        isCooldown = true;
        unitl1.fillAmount = 1;
        Buttonu1.SetActive(false);

        CooldownUni1();
    }

    void Unitspawn2() // Second unit
    {
        if (Input.GetKey(unit2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            unitl2.fillAmount = 1;
            Buttonu2.SetActive(false);

        }
        
        CooldownUni2();
    }

    public void ButtonUnit2()
    {
        isCooldown2 = true;
        unitl2.fillAmount = 1;
        Buttonu2.SetActive(false);

        CooldownUni2();
    }

    void Unitspawn3() // third unit
    {
        if (Input.GetKey(unit3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            unitl3.fillAmount = 1;
            Buttonu3.SetActive(false);
        }

        CooldownUni3();
    }

    public void ButtonUnit3()
    {
        isCooldown3 = true;
        unitl3.fillAmount = 1;
        Buttonu3.SetActive(false);

        CooldownUni3();
    }

    void Unitspawn4() // Base
    {
        if (Input.GetKey(unit4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            unitl4.fillAmount = 1;
            ButtonBase.SetActive(false);

        }

        CooldownBase();

    }

    void TowerSwap()
    {

        if (Input.GetKey(unit5) && isCooldown5 == false || Input.GetKey(unit6) && isCooldown5 == false)
        {
            isCooldown5 = true;
            Attack.fillAmount = 1;
            Defense.fillAmount = 1;

            ObjectOff();
        }

        CooldownAD();
    }

    public void ObjectOff()
    {
        ButtonA.SetActive(false);
        ButtonD.SetActive(false);
    }

    public void Unitspawn5()
    {
        if (Input.GetKey(unit7) && isCooldown7 == false)
        {
            isCooldown7 = true;
            unitl7.fillAmount = 1;
            ButtonUpdateBase.SetActive(false);

        }

        CooldownbaseUpdate();
    }

    public void ButtonUpdate()
    {
        isCooldown7 = true;
        unitl7.fillAmount = 1;
        ButtonUpdateBase.SetActive(false);

        CooldownbaseUpdate();

    }

    public void Mobjectoff(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void ButtonAD()
    {
        isCooldown5 = true;
        Attack.fillAmount = 1;
        Defense.fillAmount = 1;

        CooldownAD();
    }

    public void CooldownAD()
    {
        if (isCooldown5)
        {
            Attack.fillAmount -= 1 / cooldown5 * Time.deltaTime;
            Defense.fillAmount -= 1 / cooldown5 * Time.deltaTime;

            if (Attack.fillAmount <= 0)
            {
                Attack.fillAmount = 0;
                Defense.fillAmount = 0;
                isCooldown5 = false;
                ButtonA.SetActive(true);
                ButtonD.SetActive(true);
            }
        }
    }

    public void CooldownUni1()
    {
        if (isCooldown)
        {
            unitl1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (unitl1.fillAmount <= 0)
            {
                unitl1.fillAmount = 0;
                isCooldown = false;
                Buttonu1.SetActive(true);
            }
        }
    }

    public void CooldownUni2()
    {
        if (isCooldown2)
        {
            unitl2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (unitl2.fillAmount <= 0)
            {
                unitl2.fillAmount = 0;
                isCooldown2 = false;
                Buttonu2.SetActive(true);
            }
        }
    }

    public void CooldownUni3()
    {
        if (isCooldown3)
        {
            unitl3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (unitl3.fillAmount <= 0)
            {
                unitl3.fillAmount = 0;
                isCooldown3 = false;
                Buttonu3.SetActive(true);
            }
        }
    }

    public void CooldownbaseUpdate()
    {
        if (isCooldown7)
        {
            unitl7.fillAmount -= 1 / cooldown7 * Time.deltaTime;

            if (unitl7.fillAmount <= 0)
            {
                unitl7.fillAmount = 0;
                isCooldown7 = false;
                ButtonUpdateBase.SetActive(true);
            }
        }
    }
    public void Buttonbase()
    {
        isCooldown4 = true;
        unitl4.fillAmount = 1;

        CooldownBase();
    }

    public void CooldownBase()
    {
        if (isCooldown4)
        {
            unitl4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (unitl4.fillAmount <= 0)
            {
                unitl4.fillAmount = 0;
                isCooldown4 = false;
                ButtonBase.SetActive(true);
            }
        }
    }
}
