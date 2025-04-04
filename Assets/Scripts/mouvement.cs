using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour

{
    public float speed;
    
    void Update()
    {
        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.z += 1;
        }

        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
            
        }
    }
}
