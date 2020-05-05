using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlemmeyStateMachine : MonoBehaviour
{
    public float health;
    public bool isAlive;

    public float lastDamageAmt; // Value of the last amount of damage taken -- so we can pass in proper weapon damage

    public State currentState;
    public Blemmey blem;

    public SpriteRenderer sprite_renderer;
    public Sprite[] blem_sprites;
    public int AnimateRunBaseIndex;
    public int anim_frame = 0;

    public int stepAmt;

    private void Start()
    {

        blem = new Blemmey();
        currentState = null;
        health = blem.health;
        isAlive = true;
        lastDamageAmt = 0;

        blem_sprites = Resources.LoadAll<Sprite>("Blemmey");
        sprite_renderer = GetComponent<SpriteRenderer>();

        

        SetState(new Attack(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }

        if (!isAlive)
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
        Vector3 dir = (pos - plr_pos).normalized * -1;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        

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

        sprite_renderer.sprite = blem_sprites[AnimateRunBaseIndex + anim_frame];
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
