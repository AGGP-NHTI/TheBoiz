using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    public float health;
    public bool isAlive;

    public float lastDamageAmt; // Value of the last amount of damage taken -- so we can pass in proper weapon damage

    public State currentState;
    public Zombie zom;

    public SpriteRenderer sprite_renderer;
    public Sprite[] zom_sprites;
    public int AnimateRunBaseIndex;
    public int anim_frame = 0;

    public int stepAmt = 0;

    private void Start()
    {
        zom = new Zombie();
        currentState = null;
        health = 100;
        isAlive = true;
        lastDamageAmt = 0;

        zom_sprites = Resources.LoadAll<Sprite>("Zombie");
        sprite_renderer = GetComponent<SpriteRenderer>();

        SetState(new Attack(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }

        if(!isAlive)
        {
            Destroy(gameObject);
        }

        if (step())
        {
            anim_frame += 1;

            if (anim_frame > 2)
            {
                anim_frame = 0;
            }
        }

        animate();
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

    public void animate()
    {
        Vector3 pos = transform.position;
        Vector3 plr_pos = GameObject.Find("player").transform.position;
        Vector3 dir = (pos - plr_pos).normalized *-1;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        

        if (angle > -25 && angle < 25) //Right
        {
            //sprite_renderer.sprite = plr_sprites[20];
            AnimateRunBaseIndex = 4;
        }
        else if (angle > 25 && angle < 75) //Right Up
        {
            //sprite_renderer.sprite = plr_sprites[14];
            AnimateRunBaseIndex = 10;
        }
        else if (angle > 75 && angle < 115) //Up
        {
            //sprite_renderer.sprite = plr_sprites[2];
            AnimateRunBaseIndex = 2;
        }
        else if (angle > 115 && angle < 165) //Left Up
        {
            //sprite_renderer.sprite = plr_sprites[11];
            AnimateRunBaseIndex = 16;
        }
        else if (angle > 165 || angle < -165) //Left
        {
            //sprite_renderer.sprite = plr_sprites[5];
            AnimateRunBaseIndex = 19;
        }
        else if (angle > -165 && angle < -115) //Left Down
        {
            //sprite_renderer.sprite = plr_sprites[8];
            AnimateRunBaseIndex = 13;
        }
        else if (angle > -115 && angle < -75) //Down
        {
            //sprite_renderer.sprite = plr_sprites[0];
            AnimateRunBaseIndex = 0;
        }
        else if (angle > -75 && angle < -25) //Right Down
        {
            //sprite_renderer.sprite = plr_sprites[17];
            AnimateRunBaseIndex = 7;
        }

        sprite_renderer.sprite = zom_sprites[AnimateRunBaseIndex + anim_frame];
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

}
