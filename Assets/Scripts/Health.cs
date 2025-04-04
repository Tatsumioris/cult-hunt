using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10f;

    public bool destroyOnDeath = false;
    public UnityEvent onDie = new UnityEvent();

    private float _health = 0f;

    public bool IsDead => _health <= 0f;

    private void Awake ()
    {
        _health = maxHealth;
    }

    public bool TakeDamages(float damage)
    {
        if (IsDead)
            return false;

        _heath -= damages;
        if (_health <= 0)
        {
            _health = 0f;
            onDie?.Invoke();

            if (destroyOnDeath)
                Destroy(gameObject);
        }
        return true;
    }
}
