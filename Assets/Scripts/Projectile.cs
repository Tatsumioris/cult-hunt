using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float radius = 1f;
    public LayerMask targetLayer = ~0;
    private float _damages = 0f;
    private float _speed = 0f;
    private float _range = 0f;
    private Vector3 _origin = Vector3.zero;

    private void Start()
    {
        _origin = transform.position;
    }

    private void Update()
    {
        float distance = _speed * Time.deltaTime;
        RaycastHit2D hitInfo = Physics2D.CircleCast(transform.position, radius, transform.up, distance, targetLayer);

        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out Health damageable))
        {
            damageable.TakeDamages(_damages);
            Destroy(gameObject);
            return;
        }

        else 
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, _origin) >= _range)
        {
            Destroy(gameObject);
        }
    }

    public void Launch (float damages, float speed, Vector2 direction, float range)
    {
        _damages = damages;
        _speed = speed;
        _range = range;
    }
}
