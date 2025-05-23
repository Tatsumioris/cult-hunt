using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;
    public bool isMoving;

 

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("", isMoving);
    }
}
