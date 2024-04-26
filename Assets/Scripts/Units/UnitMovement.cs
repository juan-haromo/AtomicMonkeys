using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public float targetPosition;
    public float movementSpeed;
    //private bool collidedEnemy = false;

    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        {
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
}

/*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Ally"))
        {
            collidedEnemy = true;
            Debug.Log("chocaron");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Ally"))
        {
            collidedEnemy = false;
            Debug.Log("Dejaron de chocar");
        }
    }
*/