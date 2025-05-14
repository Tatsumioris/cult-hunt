using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    public Vector3 bulletDirection;

    // Update is called once per frame
    void Update()
    {
        
        transform.position += bulletDirection * Time.deltaTime * speed;
        Debug.Log($"bulletDirection: {bulletDirection}");

        
    }

    private void OnTriggerEnter2D(Collider2D collision) // Quand il rentre en collision avec un Collider2D il est détruit
    {
        Debug.Log("Bullet hit enemy");

        CultisteHealth enemy = collision.gameObject.GetComponent<CultisteHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage();
        }

        gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
    }
}
