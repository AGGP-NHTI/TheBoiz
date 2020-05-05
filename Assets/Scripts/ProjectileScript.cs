using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float velocity;
    public float damage;
    public Rigidbody2D body;
    public AudioClip impact;
    public AudioClip impact_flesh;
    public GameObject audio_player;

    public GameObject owner;

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

                Destroy(gameObject);
            }
        }
        else if(collision.transform.GetComponentInParent<ZombieStateMachine>())
        {
            if (owner.GetComponent<CultistStateMachine>())
            {

            }
            else
            {
                ZombieStateMachine zsm = collision.transform.GetComponentInParent<ZombieStateMachine>();
                zsm.lastDamageAmt = damage;
                zsm.SetState(new TakeDamage(zsm));

                GameObject aud = Instantiate(audio_player, transform.position, Quaternion.identity);
                aud.GetComponent<AudioSource>().volume = .5f;
                aud.GetComponent<AudioSource>().PlayOneShot(impact_flesh);

                Destroy(gameObject);
            }
            
        }
        else if (collision.transform.GetComponentInParent<BlemmeyStateMachine>())
        {
            if (owner.GetComponent<CultistStateMachine>())
            {

            }
            else
            {
                BlemmeyStateMachine bsm = collision.transform.GetComponentInParent<BlemmeyStateMachine>();
                bsm.lastDamageAmt = damage;
                bsm.SetState(new TakeDamage(bsm));

                GameObject aud = Instantiate(audio_player, transform.position, Quaternion.identity);
                aud.GetComponent<AudioSource>().volume = .5f;
                aud.GetComponent<AudioSource>().PlayOneShot(impact_flesh);

                Destroy(gameObject);
            }
            
        }
        else if(collision.transform.GetComponentInParent<CultistStateMachine>())
        {
            if (owner.GetComponent<CultistStateMachine>())
            {

            }
            else
            {
                CultistStateMachine csm = collision.transform.GetComponentInParent<CultistStateMachine>();
                csm.lastDamageAmt = damage;
                csm.SetState(new TakeDamage(csm));

                GameObject aud = Instantiate(audio_player, transform.position, Quaternion.identity);
                aud.GetComponent<AudioSource>().volume = .5f;
                aud.GetComponent<AudioSource>().PlayOneShot(impact_flesh);

                Destroy(gameObject);
            }
        }
        else if (collision.transform.GetComponentInParent<PrideStateMachine>())
        {
            if (owner.GetComponent<PrideStateMachine>())
            {

            }
            else
            {
                PrideStateMachine psm = collision.transform.GetComponentInParent<PrideStateMachine>();
                psm.lastDamageAmt = damage;
                psm.SetState(new TakeDamage(psm));

                GameObject aud = Instantiate(audio_player, transform.position, Quaternion.identity);
                aud.GetComponent<AudioSource>().volume = .5f;
                aud.GetComponent<AudioSource>().PlayOneShot(impact_flesh);

                Destroy(gameObject);
            }
        }
        else if(collision.tag == "colliders" || collision.tag == "lava")
        {
            
        }
        else
        {
            GameObject aud = Instantiate(audio_player, transform.position, Quaternion.identity);
            aud.GetComponent<AudioSource>().volume = .25f;
            aud.GetComponent<AudioSource>().PlayOneShot(impact);
            Destroy(gameObject);
        }
    }
}
