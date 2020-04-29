using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float velocity;
    public int damage;
    public Rigidbody2D body;
    public AudioClip impact;
    public GameObject audio_player;

    public GameObject owner;

    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.GetComponentInParent<PlayerStateMachine>())
        {
            if (owner.GetComponent<PlayerStateMachine>())
            {

            }
            else
            {
                PlayerStateMachine psm = collision.transform.GetComponentInParent<PlayerStateMachine>();
                psm.lastDamageAmt = damage;
                psm.SetState(new TakeDamage(psm));
            }
        }
        else if(collision.transform.GetComponentInParent<ZombieStateMachine>())
        {
            ZombieStateMachine zsm = collision.transform.GetComponentInParent<ZombieStateMachine>();
            zsm.lastDamageAmt = damage;
            zsm.SetState(new TakeDamage(zsm));
            Destroy(gameObject);
        }
        else if(collision.tag == "colliders" || collision.tag == "lava")
        {
            
        }
        else
        {
            GameObject aud = Instantiate(audio_player, transform.position, Quaternion.identity);
            aud.GetComponent<AudioSource>().PlayOneShot(impact);
            Destroy(gameObject);
        }
    }
}
