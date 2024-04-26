using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationsTransicions : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Walking();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Dying();
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            Idling();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Attacking();
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            Hurting();
        }
    }
    */
    public void Idling()
    {
        animator.SetBool("IsIdle", true);

        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsHurt", false);
    }
    public void Walking()
    {
        animator.SetBool("IsWalking", true);

        animator.SetBool("IsIdle", false);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsHurt", false);
    }
    public void Attacking()
    {
        animator.SetBool("IsAttacking", true);

        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsHurt", false);
    }
    public void Hurting()
    {
        animator.SetBool("IsHurt", true);

        animator.SetBool("IsIdle", false);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsWalking", false);
    }

    public void Dying()
    {
        animator.SetBool("IsDead", true);
        Destroy(this.gameObject, 2.5f);
    }
}
