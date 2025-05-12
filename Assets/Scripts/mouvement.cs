using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class mouvement : MonoBehaviour

{
    public float speed;
    public float crouchSpeed;
    public GameObject FirePoint;
    public Gun gun;

    public Transform ceilingCheck;
    public float ceilingRadius = 0.2f;
    public LayerMask groundLayer;


    private bool isFacingRight = true;
    private bool isCrouching = false;
    private Vector3 originalFirePointLocalPos;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float originalHeight;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();           // On prend le collider puis on garde sa hauteur d'origine
        boxCollider = GetComponent<BoxCollider2D>();
        originalHeight = boxCollider.size.y;
        originalFirePointLocalPos = FirePoint.transform.localPosition;
    }
    void Update()
    {
        HandleCrouch();

        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
            if (!isFacingRight) Flip();
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
            if (isFacingRight) Flip();

        }
        float currentSpeed = isCrouching ? crouchSpeed : speed;

        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * currentSpeed * Time.deltaTime;
            
        }
  
    }

    void HandleCrouch()
    {
        bool crouchInput = Input.GetKey(KeyCode.S);

        if (crouchInput)
        {
            if (!isCrouching)
            {
                isCrouching = true;
                boxCollider.size = new Vector3(boxCollider.size.x, originalHeight / 2);
                boxCollider.offset = new Vector3(boxCollider.offset.x, boxCollider.offset.y - originalHeight / 4);
                GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log("Crouch ON");
            }
        }
        else
        {
            if (!Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundLayer))
            {
                if (isCrouching)
                {
                    isCrouching = false;
                    boxCollider.size = new Vector3(boxCollider.size.x, originalHeight);
                    boxCollider.offset = new Vector3(boxCollider.offset.x, boxCollider.offset.y + originalHeight / 4);
                    GetComponent<SpriteRenderer>().color = Color.white;
                    Debug.Log("OOH DEBOUT");

                }
            }
        }
    }

    void Flip()
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

    void OnDrawGizmosSelected()
    {
        if (ceilingCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ceilingCheck.position, ceilingRadius);
        }
    }
}
