using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public float targetPosition;
    private bool collidedEnemy = false;
    private float movement;
    public int damageTaken = 0;
    public int health;
    public GameObject stats;
    public string tagToAttack;
    public UnitMovement enemy = null;

    public float attackSpeed;
    public float indextime = 0;
    AnimationsTransicions transicions;
    private void Awake()
    {
        movement = GetComponentInChildren<Stats>().MovementSpeed();
        health = GetComponentInChildren<Stats>().Health();
        transicions = GetComponentInChildren<AnimationsTransicions>();
        attackSpeed = GetComponentInChildren<Stats>().AttackSpeed();
    }

    void Update()
    {

        if (!collidedEnemy)
        {
            transicions.Walking();
            Movement();
            Debug.Log("collelere collele collele");
        }
        else
        {
            Debug.Log("es hora de atacar");
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

        if (health <= 0)
        {
            health = 0;
            transicions.Hurting();
            transicions.Dying();
            Destroy(gameObject, 5);
            return;
        }
    }

    #region attack

    // heres the logic of a attack call
    void attack()
    {
        transicions.Attacking();
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

    public void UpdateHealth(int damageTaken)
    {
        health -= damageTaken;
    }

    public void DealDamage()
    {
        if (enemy != null)
        {
            enemy.health -= stats.GetComponentInChildren<Stats>().Damage();
        }
        else
        {
            collidedEnemy = false;
            Movement();
        }
    }
}