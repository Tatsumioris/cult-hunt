using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Repris du code Enemy
    public float speed = 1f;

    private Rigidbody2D _rigidbody = null;

    private void Awake()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.position += (Vector2)transform.up * speed * Time.deltaTime;
    }
}
