using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //Repris du code Damageable
    //public float maxHealth = 10f;

    //public bool destroyOnDeath = false;
    //public UnityEvent onDie = new UnityEvent();

    //private float _health = 0f;

    //public bool IsDead => _health <= 0f;

    //private void Awake ()
    //{
    //    _health = maxHealth;
    //}

    //public bool TakeDamages(float damage)
    //{
    //    if (IsDead)
    //        return false;

    //    _health -= damage;
    //    if (_health <= 0)
    //    {
    //        _health = 0f;
    //        onDie?.Invoke();

    //        if (destroyOnDeath)
    //            Destroy(gameObject);
    //    }
    //    return true;
    //}

    public float health = 1;

    public void GetDamage()
    {
        health--; //Reduis la vie de celui qui a ce script "health--;" raccourci pour dire que la vie est réduite de 1

        Debug.Log("Player took damage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
