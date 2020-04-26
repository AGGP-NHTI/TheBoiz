using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float fireRate;
    public float velocity;
    public float damage;

    public Weapon()
    {
    }

    public void set_1911()
    {
        fireRate = .001f;
        velocity = 30f;
        damage = 35f;
    }
}
