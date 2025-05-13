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
        rb.velocity = new Vector3(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().health--;
            Destroy(gameObject);
            
        }*/
        Debug.Log("PREND CA BORDEL");


    }
}
