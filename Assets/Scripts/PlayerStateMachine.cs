//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;
    public float speed, health;

    public float lastDamageAmt; // Value of the last amount of damage taken -- so we can pass in proper weapon damage

    public Rigidbody2D plr_body;
    private Vector2 movement;


    public State currentState;
    private string currentStateType;

    public SpriteRenderer sprite_renderer;
    public Sprite[] plr_sprites;
    public int AnimateRunBaseIndex;
    public int anim_frame = 0;

    private int stepAmt = 0;

    public bool canShoot, isAlive;
    public Weapon plr_weapon;
    public GameObject proj;
    public Vector3 plr_dir;

    public AudioClip gunShot;
    public AudioClip[] impact;
    public AudioSource plr_audio;
    public AudioClip[] impact_flesh;

    private void Awake()
    {
        plr_sprites = Resources.LoadAll<Sprite>("player");
        canShoot = true;
        plr_weapon = new Weapon();
        plr_weapon.set_1911();

        impact = new AudioClip[3];
        impact_flesh = new AudioClip[3];

        plr_audio = GetComponent<AudioSource>();
        impact[0] = Resources.Load<AudioClip>("bulletimpact1");
        impact[1] = Resources.Load<AudioClip>("bulletimpact2");
        impact[2] = Resources.Load<AudioClip>("bulletimpact3");

        impact_flesh[0] = Resources.Load<AudioClip>("bulletflesh1");
        impact_flesh[1] = Resources.Load<AudioClip>("bulletflesh2");
        impact_flesh[2] = Resources.Load<AudioClip>("bulletflesh3");
        gunShot = Resources.Load<AudioClip>("m16");
    }

    void Start()
    {
        health = 100f;
        isAlive = true;
    }


    void Update()
    {
        step();

        if (currentState != null)
        {
            currentState.Tick();
        }

        playerMovement();

        //States
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                canShoot = false;
                SetState(new PlayerShoot(this));
            }
        }

        updateWalkingFrame();

        spriteAngle();
    }

    public void SetState(State state)
    {
        if (state != null)
        {
            state.OnStateExit();
        }
        currentState = state;
        //currentStateType = currentState.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    public void playerShoot()
    {
        GameObject projectile = Instantiate(proj, transform.position, Quaternion.identity,
        GetComponentInParent<Transform>()); // Create projectile)
        projectile.GetComponent<Rigidbody2D>().velocity = (new Vector2(plr_dir.x, plr_dir.y).normalized) * plr_weapon.velocity; // Set projectiles velocity
        proj.GetComponent<ProjectileScript>().damage = plr_weapon.damage; // Set projectiles damage
        proj.GetComponent<ProjectileScript>().impact = impact[Random.Range(0, 3)];
        proj.GetComponent<ProjectileScript>().impact_flesh = impact_flesh[Random.Range(0, 3)];
        //proj.GetComponent<ProjectileScript>().owner = GetComponentInParent<GameObject>();

        //Debug.Log(proj.GetComponent<ProjectileScript>().owner); // Check if the owner was applied properly

        plr_audio.volume = .25f;
        plr_audio.PlayOneShot(gunShot);
    }

    void spriteAngle()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        plr_dir = dir;

        if (angle > -25 && angle < 25) //Right
        {
            //sprite_renderer.sprite = plr_sprites[20];
            AnimateRunBaseIndex = 21;
        }
        else if (angle > 25 && angle < 75) //Right Up
        {
            //sprite_renderer.sprite = plr_sprites[14];
            AnimateRunBaseIndex = 15;
        }
        else if (angle > 75 && angle < 115) //Up
        {
            //sprite_renderer.sprite = plr_sprites[2];
            AnimateRunBaseIndex = 12;
        }
        else if (angle > 115 && angle < 165) //Left Up
        {
            //sprite_renderer.sprite = plr_sprites[11];
            AnimateRunBaseIndex = 9;
        }
        else if (angle > 165 || angle < -165) //Left
        {
            //sprite_renderer.sprite = plr_sprites[5];
            AnimateRunBaseIndex = 3;
        }
        else if (angle > -165 && angle < -115) //Left Down
        {
            //sprite_renderer.sprite = plr_sprites[8];
            AnimateRunBaseIndex = 6;
        }
        else if (angle > -115 && angle < -75) //Down
        {
            //sprite_renderer.sprite = plr_sprites[0];
            AnimateRunBaseIndex = 0;
        }
        else if (angle > -75 && angle < -25) //Right Down
        {
            //sprite_renderer.sprite = plr_sprites[17];
            AnimateRunBaseIndex = 18;
        }

        sprite_renderer.sprite = plr_sprites[AnimateRunBaseIndex + anim_frame];
    }

    void updateWalkingFrame()
    {
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            if (step())
            {
                anim_frame += 1;

                if (anim_frame > 2)
                {
                    anim_frame = 0;
                }
            }
        }
        else
        {
            anim_frame = 1;
        }
    }

    bool step()
    {
        stepAmt += 1;


        if (stepAmt > 30)
        {

            stepAmt = 0;
            return true;

        }

        return false;
    }

    void playerMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical = Input.GetAxis("Vertical") * speed;

        movement = new Vector2(moveHorizontal, moveVertical);
        plr_body.velocity = movement * speed;
    }
}
