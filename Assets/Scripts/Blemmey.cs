using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blemmey
{

    public float health;
    public float speed;
    public float damage;
    public float attack_cooldown;

    public Blemmey()
    {
        health = 125f;
        speed = 4f;
        damage = 40f;
        attack_cooldown = 2f;
    }
}
