using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float fireRateMultiplier = 3f;
    public float damagesMultiplier = 1f;
    public float range = 6f;

    private Health _damageable = null;
    private float _fireCooldown = 0f;

    private void Awake()
    {
        if (_damageable == null)
            _damageable = GetComponent<Health>();
    }

    void Update()
    {
        if (_fireCooldown > 0f)
            _fireCooldown -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _fireCooldown <= 0f)
        {
            Fire();
            _fireCooldown = weapon.fireRate / fireRateMultiplier;
        }
    }

    private void Fire()
    {
        Projectile projectileInstance = Instantiate(weapon.projectilePrefab, Projectile.position, Quaternion.identity);
        projectileInstance.Launch(weapon.damages * damagesMultiplier, weapon.speed, cannonRenderer.transform.up, range);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
            _damageable.TakeDamages(1);
        }
    }



}
