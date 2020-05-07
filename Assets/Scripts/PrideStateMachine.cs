using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrideStateMachine : MonoBehaviour
{

    public float health;
    public bool isAlive;

    public float lastDamageAmt;

    public State currentState;
    public string currentStateType;

    public Pride pride;

    public SpriteRenderer sprite_renderer;
    public Sprite[] pride_sprites;
    public int AnimateRunBaseIndex = 0;
    public int anim_frame = 0;
    private int stepAmt = 0;

    void Start()
    {
        pride = new Pride();
        isAlive = true;
        health = pride.health;
        currentState = null;
        lastDamageAmt = 0;

        sprite_renderer = GetComponent<SpriteRenderer>();
        pride_sprites = Resources.LoadAll<Sprite>("boss");

        SetState(new Attack(this));
    }

    
    void Update()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }

        if (!isAlive)
        {
            SceneManager.LoadScene("Winner");
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

        if(currentStateType == "Attack")
        {
            sprite_renderer.sprite = pride_sprites[AnimateRunBaseIndex + anim_frame];
        }
        
    }

    public void SetState(State state)
    {
        if (state != null)
        {
            state.OnStateExit();
        }
        currentState = state;
        currentStateType = currentState.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    bool step()
    {
        stepAmt += 1;


        if (stepAmt > 60)
        {

            stepAmt = 0;
            return true;

        }

        return false;
    }
}
