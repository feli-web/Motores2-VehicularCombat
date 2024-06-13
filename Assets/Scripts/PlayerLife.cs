using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    float life;
    public float maxLife;
    public Slider lifeSlider;
    public SpriteRenderer sr;
    public Animator animator;

    public AudioSource damageSound;
    public AudioSource explosionSound;
    public WinLoseManager wlm;
    void Start()
    {
        animator.SetBool("Alive", true);
        lifeSlider.minValue = 0;
        lifeSlider.maxValue = maxLife;
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        lifeSlider.value = life;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Red Bullet"))
        {
            StartCoroutine(Damage());
            life--;
            damageSound.Play();
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Damage());
            damageSound.Play();
            life -= (maxLife * 0.1f);
        }
        if (collision.gameObject.CompareTag("Red Planet"))
        {
            StartCoroutine(Damage());
            life -= (maxLife * 0.25f);
            damageSound.Play();
            
        }
    }
    IEnumerator Damage()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        if (life <= 0)
        {
            explosionSound.Play();
            animator.SetBool("Alive", false);
            animator.Play("PlayerShip1_Death");
            yield return new WaitForSeconds(1f);
            wlm.Lose();
            Destroy(gameObject);
        }

    }
    public void Recover()
    {
        life += maxLife * 0.1f;

    }
}
