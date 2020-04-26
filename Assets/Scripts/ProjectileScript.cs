using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float velocity;
    public float damage;
    public Rigidbody2D body;
    public AudioClip impact;
    public GameObject audio_player;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.GetComponentInParent<PlayerStateMachine>())
        {
            PlayerStateMachine psm = collision.transform.GetComponentInParent<PlayerStateMachine>();

            psm.SetState(new PlayerDamaged(psm));
        }
        else if(collision.tag == "colliders")
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
