using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Repris du code WeaponAsset
    // Gère les paramètres de base de l'arme
    public float fireRate = 1f;

    public float damages = 1f;

    public float speed = 1f;

    public Projectile projectilePrefab = null;
}
