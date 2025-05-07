using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
    
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);//Va chercher le prefab Bullet et prendre la position du firePoint. Le Quaternion dit qu'il a une rotation par défaut

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);//Projete un rayon depuis le firePoint et orienter vers la droite
        if (hit) 
        {
            Debug.Log("Hit" + hit.collider.gameObject);

            Cultiste enemy = hit.collider.gameObject.GetComponent<Cultiste>();
            if (enemy != null)
            {
                enemy.GetDamage();
            } 
        }
    }
}
