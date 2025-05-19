using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultisteBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private float timer;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, 0).normalized * force;

        //float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10) // Au bout de X temps la balle disparait
        {
            Destroy(gameObject);
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.gameObject.GetComponent<Health>().health--;
    //        Destroy(gameObject);
            
    //    }
    //    Debug.Log("PREND CA");


    //}

    private void OnTriggerEnter2D(Collider2D collision) // Quand il rentre en collision avec un Collider2D il est détruit
    {
        Debug.Log("Bullet hit player", this); // le this fait que quand on double clique sur le message il nous ramène directement ici

        Health player = collision.gameObject.GetComponent<Health>();
        if (player != null)
        {
            player.TakeDamage(); // ctrl + r r renomme dans tout les scripts
            Debug.Log("Degat reçu", this);      
        }

        gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
    }
}

