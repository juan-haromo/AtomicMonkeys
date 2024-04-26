using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public float moveSpeed = 50f;
    [SerializeField]public Vector2 maxPosition;
    [SerializeField]public Vector2 minPosition;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
        Vector3 position=new Vector3(0,0,0);

            
        int edgescrollsize = 20;

        if(Input.mousePosition.x>Screen.width-edgescrollsize && target.position.x < maxPosition.x || Input.GetKey(KeyCode.D) && target.position.x < maxPosition.x)
        {
            position.x = +1f;
        }
        if (Input.mousePosition.x <  edgescrollsize && target.position.x > minPosition.x || Input.GetKey(KeyCode.A) && target.position.x > minPosition.x)
        {
            position.x = -1f;
        }
        
        Vector3 movedir=transform.forward*position.z+transform.right*position.x;

        transform.position += movedir * moveSpeed * Time.deltaTime;
    }
}
