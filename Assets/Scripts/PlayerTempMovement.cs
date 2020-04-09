using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTempMovement : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;
    public float speed;

    public Rigidbody2D plr_body;
    private Vector2 movement;
    public SpriteRenderer sprite_renderer;
    public Sprite[] plr_sprites;

    private int stepAmt = 0;
    private int AnimateRunBaseIndex;
    private int anim_frame = 0;

    private void Awake()
    {
        plr_sprites = Resources.LoadAll<Sprite>("player");
    }

    void Start()
    {

    }


    void Update()
    {
        step();

        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical = Input.GetAxis("Vertical") * speed;

        movement = new Vector2(moveHorizontal, moveVertical);
        plr_body.velocity = movement * speed;

        spriteAngle();
    }

    void step()
    {
        stepAmt += 1;


        if(stepAmt >= 60)
        {
            stepAmt = 0;
        }
    }

    IEnumerator AnimateRun()
    {
        anim_frame = 0;
        while (anim_frame < 2)
        {
            sprite_renderer.sprite = plr_sprites[AnimateRunBaseIndex + anim_frame];
            yield return new WaitForSeconds(1f);
            anim_frame++;
            //yield return 0;
        }
        
        StartCoroutine(AnimateRun());
    }

    void spriteAngle()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
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
        else if(angle > 75 && angle < 115) //Up
        {
            //sprite_renderer.sprite = plr_sprites[2];
            AnimateRunBaseIndex = 12;
        }
        else if(angle > 115 && angle < 165) //Left Up
        {
            //sprite_renderer.sprite = plr_sprites[11];
            AnimateRunBaseIndex = 9;
        }
        else if(angle > 165 || angle < -165) //Left
        {
            //sprite_renderer.sprite = plr_sprites[5];
            AnimateRunBaseIndex = 3;
        }
        else if(angle > -165 && angle < -115) //Left Down
        {
            //sprite_renderer.sprite = plr_sprites[8];
            AnimateRunBaseIndex = 6;
        }
        else if(angle > -115 && angle < -75) //Down
        {
            //sprite_renderer.sprite = plr_sprites[0];
            AnimateRunBaseIndex = 0;
        }
        else if(angle > -75 && angle < -25) //Right Down
        {
            //sprite_renderer.sprite = plr_sprites[17];
            AnimateRunBaseIndex = 18;
        }

        sprite_renderer.sprite = plr_sprites[AnimateRunBaseIndex + 1];

        if (moveVertical != 0 || moveHorizontal != 0)
        {

        }
        else
        {
            StopAllCoroutines();
        }
    }
}
