using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    

    public float health = 1;

    public void TakeDamage()
    {
        health--; //Reduis la vie de celui qui a "health--;" raccourci pour dire que la vie est réduite de 1

        Debug.Log("Player took damage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
