using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class mouvement : MonoBehaviour

{
    public float speed;
    public GameObject FirePoint;
    public Gun gun;

    private bool isFacingRight = true;
    private Vector3 originalFirePointLocalPos;

    private void Start()
    {
        originalFirePointLocalPos = FirePoint.transform.localPosition;
    }
    void Update()
    {
        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
            if (!isFacingRight) Flip();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
            //transform.Rotate(0f, 180f, 0f);
            if (isFacingRight) Flip();

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
        }

        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
            
        }
  
    }
    
    void Flip ()
    {
        isFacingRight = !isFacingRight;

        //Vector3 scale = transform.localScale; //inverse l'échelle sur x et retourne visuellement le personnage
        //scale.x *= -1;
        //transform.localScale = scale;

        Vector3 firePointPos = originalFirePointLocalPos; // bouge le firePoint de l'autre côté 
        firePointPos.x *= isFacingRight ? 1 : -1;
        FirePoint.transform.localPosition = firePointPos;

        Debug.Log("Flip");
        gun.GunFlip();
    }
}
