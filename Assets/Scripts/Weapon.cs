using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float fireRate;
    public float velocity;
    public float damage;
    public int maxMag;
    public int currentAmmo;
    public float reloadSpeed;

    public bool shotgun;
    public int pellets;
    public float spread;

    public Weapon()
    {
    }

    public void set_1911()
    {
        fireRate = .001f;
        velocity = 30f;
        damage = 35f;
        shotgun = false;
        maxMag = 7;
        currentAmmo = maxMag;
        reloadSpeed = 1f;
    }

    public void set_shotgun()
    {
        fireRate = 1f;
        velocity = 40f;
        damage = 25f;
        shotgun = true;
        pellets = 7;
        spread = 50f;
    }
}
