using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public float targetPosition;
    public float movementSpeed;
    private bool collidedEnemy = false;

    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        //We determine if the enemy is colliding or not, if its colliding it wont move
        if(!collidedEnemy){

            //We look at which direction the unity should move
            if (transform.position.x < targetPosition)
            {
                float newPosition = transform.position.x + (movementSpeed * Time.deltaTime);
                transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > targetPosition)
            {
                float newPosition = transform.position.x - (movementSpeed * Time.deltaTime);
                transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
            }
        }
    }

    //In the future, we must add an if to see if the collision is with a unit of the same tag or a different tag
    //If they have the same tag they should ignore each other
    void OnTriggerEnter(Collider other)
    {
            collidedEnemy = true;
            Debug.Log("chocaron");
    }

    private void OnTriggerExit(Collider other)
    {
        collidedEnemy = false;
        Debug.Log("Se pelo");
    
    }

}