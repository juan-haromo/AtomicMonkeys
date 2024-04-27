using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public float bulletRate;
    private Vector3 target;
    //public GameObject[] enemies;
    

    //Variables Nuevas para los especiales de la base
    public int maxTargets;
    public int currentTargetIndex;
    public GameObject basicBulletPrefab;
    public GameObject explosiveBulletPrefab;
    public GameObject smallBulletPrefab;
    private GameObject currentBullet;
    public List<GameObject> enemies;
    private bool isMultiTarget;

    //Estas quiza podrian estar en otro script llamado BaseDefense o algo asi
    public BaseHealth baseHealth;
    public float healAmmount;

    // Start is called before the first frame update
    void Start()
    {
        isMultiTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        TemporalInputs();
    }

    private void shootBullet()
    {
        if (isMultiTarget)
        {
            MultiTargetCheck();
        }
        else
        {
            SingleTargetCheck();
        }
        GameObject bullet = Instantiate(currentBullet, transform.position, transform.rotation);
        bullet.GetComponent<DefaultBulletScript>().setDirection(target);
    }

    private void MultiTargetCheck()
    {
        if (enemies[currentTargetIndex] != null)
        {
            target = enemies[currentTargetIndex].transform.position;
            currentTargetIndex += 1;
            if (currentTargetIndex >= enemies.Count || currentTargetIndex >= maxTargets)
            {
                currentTargetIndex = 0;
            }
        }
    }

    private void SingleTargetCheck()
    {
        if (enemies[0]!=null)
        {
            target = enemies[0].transform.position;
        }
    }

    private void StartShooting()
    {
        InvokeRepeating("shootBullet", 0f, bulletRate);
    }

    private void StopShooting()
    {
        CancelInvoke("shootBullet");
    }

    private void HealBase()
    {
        baseHealth.ChangeHealth(healAmmount);
    }

    private void TemporalInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartShooting();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopShooting();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            //Princess
            isMultiTarget = false;
            currentBullet = basicBulletPrefab;
            bulletRate = 1f;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            //Canoneer
            isMultiTarget= false;
            currentBullet = explosiveBulletPrefab;
            bulletRate = 2f;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            //Dager Duchess
            isMultiTarget = true;
            currentBullet = smallBulletPrefab;
            bulletRate = 0.3f;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            HealBase();
        }
    }
}
