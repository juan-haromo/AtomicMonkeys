using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelfTarget : MonoBehaviour
{
    private void Start()
    {
        GetComponent<UnitMovement>().targetPosition = this.transform.position.x;
    }
}
