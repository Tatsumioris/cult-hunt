using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultisteAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    
    public float distance;

    public Anim anim;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Detective");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        animator.SetBool("IsWalkingC", true);

        if (distance < 15) {
            speed = 0f;
            animator.SetBool("IsWalkingC", false);
        }
        else if (distance > 10)
            speed = 3f;
            
    }
}
