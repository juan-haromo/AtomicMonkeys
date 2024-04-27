using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public float bulletRate;
    private Vector3 target;
    public string targetTag;


    //Variables Nuevas para los especiales de la base
    public int maxTargets;
    public int currentTargetIndex;
    public GameObject basicBulletPrefab;
    public GameObject enemyExplosiveBulletPrefab;
    public GameObject allyExplosiveBulletPrefab;
    public GameObject smallBulletPrefab;
    private GameObject currentBullet;
    private bool isMultiTarget;
    public DetectionRangeScript detectionRangeScript;
    private bool isShooting;

    //Estas quiza podrian estar en otro script llamado BaseDefense o algo asi
    public BaseHealth baseHealth;
    public float healAmmount;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        isMultiTarget = false;
        currentBullet = basicBulletPrefab;
        bulletRate = 1f;
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
        bullet.GetComponent<DefaultBulletScript>().setTag(targetTag);
    }

    private void MultiTargetCheck()
    {
        if (detectionRangeScript.getEnemyFromIndex(currentTargetIndex) != null)
        {
            target = detectionRangeScript.getEnemyFromIndex(currentTargetIndex).position;
            currentTargetIndex += 1;
            if (currentTargetIndex >= detectionRangeScript.getEnemyCount() || currentTargetIndex >= maxTargets)
            {
                currentTargetIndex = 0;
            }
        }
        else if (currentTargetIndex > 0)
        {
            currentTargetIndex--;
        }
    }

    private void SingleTargetCheck()
    {
        target = detectionRangeScript.getEnemyFromIndex(0).position;
    }

    public void StartShooting()
    {
        InvokeRepeating("shootBullet", 0f, bulletRate);
        currentTargetIndex = 0;
        isShooting = true;
    }

    public void StopShooting()
    {
        CancelInvoke("shootBullet");
        isShooting = false;
    }

    private void HealBase()
    {
        baseHealth.ChangeHealth(healAmmount);
    }

    private void TemporalInputs()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            //Princess
            if (isShooting == true)
            {
                StopShooting();
                isMultiTarget = false;
                currentBullet = basicBulletPrefab;
                bulletRate = 1f;
                StartShooting();
            }
            isMultiTarget = false;
            currentBullet = basicBulletPrefab;
            bulletRate = 1f;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            //Canoneer
            if (isShooting == true)
            {
                StopShooting();
                isMultiTarget = false;
                if(targetTag == "Enemy")
                {
                    currentBullet = enemyExplosiveBulletPrefab;
                }
                else if(targetTag == "Ally")
                {
                    currentBullet = allyExplosiveBulletPrefab;
                }
                bulletRate = 2f;
                StartShooting();
            }
            isMultiTarget = false;
            if (targetTag == "Enemy")
            {
                currentBullet = enemyExplosiveBulletPrefab;
            }
            else if (targetTag == "Ally")
            {
                currentBullet = allyExplosiveBulletPrefab;
            }
            bulletRate = 2f;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            //Dager Duchess
            if (isShooting == true)
            {
                StopShooting();
                isMultiTarget = true;
                currentBullet = smallBulletPrefab;
                bulletRate = 0.3f;
                StartShooting();
            }
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
