using Unity.VisualScripting;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public float targetPosition;
    private bool collidedEnemy = false;
    private float movement;
    public GameObject stats;
    private void Awake()
    {
        movement = GetComponentInChildren<Stats>().MovementSpeed();
    }

    void Update()
    {
           
        if (!collidedEnemy)
        {
            Movement();
            Debug.Log("collelere collele collele");
        }
        else
        {
            Debug.Log("es hora de atacar");
            attack();
        }
    }

    #region attack

    // heres the logic of a attack call
    void attack()
    {

    }
    #endregion

    #region movement
    private void Movement()
    {
        //We determine if the enemy is colliding or not, if its colliding it wont move
        if(!collidedEnemy){

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
            }
        }
    }
    #endregion

    //In the future, we must add an if to see if the collision is with a unit of the same tag or a different tag
    //If they have the same tag they should ignore each other
    void OnTriggerEnter(Collider other)
    {
        collidedEnemy = true;
        Debug.Log("chocaron");
        //Health(other.gameObject.GetComponent<UnitMovement>().damage);
    }

    void OnTriggerExit(Collider other)
    {
        collidedEnemy = false;
        Debug.Log("Se pelo");
    }
}