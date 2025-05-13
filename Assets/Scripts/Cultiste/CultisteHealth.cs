using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultisteHealth : MonoBehaviour
{
    public float health = 1;

    public void GetDamage()
    {
        health--; //Reduis la vie de celui qui a ce script "health--;" raccourci pour dire que la vie est réduite de 1
        
        Debug.Log("Enemy took damage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
