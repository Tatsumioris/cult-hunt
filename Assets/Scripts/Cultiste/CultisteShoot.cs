using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultisteShoot : MonoBehaviour
{
    public GameObject CultisteBullet;
    public Transform bulletPos;
    public bool CanShoot;


    private float timer;
    private GameObject player;

    public Anim anim;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 20)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
                animator.SetBool("IsShootingC", true);

            }
        }
    }

        

    void shoot()
    {
        Instantiate(CultisteBullet, bulletPos.position, Quaternion.identity);
        // Debug.Break();                     // Debug.Break fait que quand il est appelé il stop directement le play
        Debug.Log("Shoot from ennemy");


    }
    //public void StopShooting()
    //{
    //    animator.SetBool("IsShootingC", false);
    //}

}
