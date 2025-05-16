using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jump;
    public Rigidbody2D rb;
    public bool isJumping;
    public Gun gun;

    private float Move;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        { 
            rb.AddForce(new Vector3(rb.velocity.x, jump));
            animator.SetBool("IsJumpingR", true);
            

        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            GetComponent<Gun>().enabled = true;
            animator.SetBool("IsJumpingR", false);
        }
        
        if(other.gameObject.CompareTag("Box"))
        {
            isJumping = false;
            GetComponent<Gun>().enabled = true;
            animator.SetBool("IsJumpingR", false);
        }


    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
            GetComponent<Gun>().enabled = false;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            isJumping = true;
            GetComponent<Gun>().enabled = false;
        }



        //else
        //{
        //    animator.SetBool("IsJumpingR", false);
        //}
    }
}
