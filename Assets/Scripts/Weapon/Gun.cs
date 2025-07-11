using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
    
{
    public GameObject leftBulletPrefab;
    public GameObject rightBulletPrefab;
    public Transform firePoint;
    public bool gunFacingRight = true;
    public Vector3 firePointDirection;
    public bool CanShoot;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && CanShoot)
        {
            Shoot();
            CanShoot = false;
            animator.SetBool("IsShootingR", true);

        }
        else
        {
            animator.SetBool("IsShootingR", false);
        }

    }

    void Shoot()
    {
        //GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation );//Va chercher le prefab Bullet et prendre la position du firePoint. Le Quaternion dit qu'il a une rotation par d�faut Quaternion.identity

        if (gunFacingRight)
        {
            GameObject bulletInstance = Instantiate(rightBulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            GameObject bulletInstance = Instantiate(leftBulletPrefab, firePoint.position, firePoint.rotation);
        }

        //RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePointDirection);//Projete un rayon depuis le firePoint et orienter vers la droite
        //if (hit) 
        //{
        //    Debug.Log("Hit" + hit.collider.gameObject);

        //    CultisteHealth enemy = hit.collider.gameObject.GetComponent<CultisteHealth>();
        //    if (enemy != null)
        //    {
        //        enemy.TakeDamage();
        //    } 
        //}

        StartCoroutine(fireRate());
    }

    IEnumerator fireRate()
    {
        CanShoot = false;

        yield return new WaitForSeconds(2);

        CanShoot = true;
    }

    void fireActivate()
    {
        CanShoot = true;
        
    }

    public void GunFlip()
    {
        gunFacingRight = !gunFacingRight;
    }
}
