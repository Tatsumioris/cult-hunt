using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Quand il rentre en collision avec un Collider2D il est détruit
    {
        Debug.Log("Bullet hit enemy");

        Cultiste enemy = collision.gameObject.GetComponent<Cultiste>();
        if (enemy != null)
        {
            enemy.GetDamage();
        }

        gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
    }
}
