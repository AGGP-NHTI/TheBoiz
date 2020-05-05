using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pride
{

    public float health;
    public float speed;
    public float slam_damage;
    public float cooldown;
    public float slam_buildup;
    public float slam_AOE;
    public float charge_buildup;
    public float charge_damage;
    public float charge_speed;
    public float charge_buildup_speed;
    public float charge_duration;

    public Pride()
    {
        health = 1000f;
        speed = 1f;
        slam_damage = 50f;
        cooldown = 8f;
        slam_buildup = 1.5f;
        slam_AOE = 3f;
        charge_buildup = 3f;
        charge_damage = 50f;
        charge_speed = 5f;
        charge_buildup_speed = .5f;
        charge_duration = 2f;
    }
}
