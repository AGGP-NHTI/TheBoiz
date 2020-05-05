using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie
{
    public float health;
    public float speed; // Walkspeed
    public float damage; // Attack Damage
    public float attack_cooldown; // Self explainitory

    public Zombie()
    {
        health = 50f;
        speed = 2.5f;
        damage = 25f;
        attack_cooldown = 1.5f;
    }
}
