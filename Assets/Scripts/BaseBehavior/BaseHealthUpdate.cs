using System.Collections.Generic;
using UnityEngine;

public class BaseHealthUpdate : UnitMovement
{
    //public float targetPosition;
    //private bool collidedEnemy = false;
    //private float movement;
    //public int damageTaken = 0;
    //public int health;
    //public GameObject stats;
    //public string tagToAttack;
    //public UnitMovement enemy = null;

    //public float attackSpeed;
    //public float indextime = 0;
    //AnimationsTransicions transicions;

    [SerializeField] GameObject resultScreen;
    [SerializeField] List<GameObject> off;
    private void Awake()
    {
        movement = GetComponentInChildren<Stats>().MovementSpeed();
        health = GetComponentInChildren<Stats>().Health();
        //transicions = GetComponentInChildren<AnimationsTransicions>();
        attackSpeed = GetComponentInChildren<Stats>().AttackSpeed();
    }

    void Update()
    {
  

        if (!collidedEnemy)
        {
            //transicions.Walking();
            Movement();
        }
        else
        {
            attack();

            if (indextime > attackSpeed)
            {
                //UpdateHealth(damageTaken);
                DealDamage();
                //Debug.Log(health);
                indextime = 0;
            }
            indextime += Time.deltaTime;

        }
        Debug.Log(health);
        if (health <= 0)
        {
            Debug.Log("Die");
            health = 0;
            //transicions.Hurting();
            //transicions.Dying();
            Destroy(gameObject);
            return;
        }
    }

    #region attack

    // heres the logic of a attack call
    void attack()
    {
        //transicions.Attacking();
    }
    #endregion

    #region movement
    private void Movement()
    {

        //We determine if the enemy is colliding or not, if its colliding it wont move
        if (!collidedEnemy)
        {

            //We look at which direction the unity should move
            if (transform.position.x < targetPosition)
            {
                float newPosition = transform.position.x + (movement * Time.deltaTime);
                transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > targetPosition)
            {
                float newPosition = transform.position.x - (movement * Time.deltaTime);
                transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
                //We flip the enmy so it faces the correct direction
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else //(transform.position.x == targetPosition - 0.5f)
            {
                Debug.Log("ya llego");
                movement = 0;
                transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
            }
        }
    }
    #endregion

    //In the future, we must add an if to see if the collision is with a unit of the same tag or a different tag
    //If they have the same tag they should ignore each other
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToAttack))
        {
            collidedEnemy = true;
            Debug.Log("chocaron");
            //Health(other.gameObject.GetComponent<UnitMovement>().damage);

            //We acces the damage that the other unit deals
            //damageTaken = other.gameObject.GetComponent<Stats>().Damage();
            if (enemy == null)
            {
                enemy = other.GetComponent<UnitMovement>();
                movement = 0;
            }
            enemy.DealDamage();
            Debug.Log(damageTaken);

        }


    }

    void OnTriggerExit(Collider other)
    {
        collidedEnemy = false;
        movement = GetComponentInChildren<Stats>().MovementSpeed();
        Debug.Log("Se pelo");
        enemy = null;
    }

    public void UpdateHealth(int _damageTaken)
    {
        health -= _damageTaken;
    }

    public void DealDamage()
    {
        if (enemy != null)
        {
            enemy.health -= stats.GetComponentInChildren<Stats>().Damage();
        }
        else
        {
            movement = stats.GetComponentInChildren<Stats>().MovementSpeed();
            collidedEnemy = false;
            Movement();
        }
    }

    private void OnDestroy()
    { 
        for(int i  = 0; i<off.Count; i++)
        {
            off[i].SetActive(false);
        }
        Time.timeScale= 0f;
        resultScreen.SetActive(true);
    }
}