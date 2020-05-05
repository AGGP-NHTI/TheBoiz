using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist
{
    public float health;
    public float speed; // Walkspeed
    public float damage; // Attack Damage
    public float attack_cooldown; // Self explainitory
    public float retreat_dist;
    public float proj_velocity;

    public Cultist()
    {
        health = 100f;
        speed = 2.5f;
        damage = 25f;
        attack_cooldown = 1.5f;
        retreat_dist = 12f;
        proj_velocity = 7f;
    }
}
