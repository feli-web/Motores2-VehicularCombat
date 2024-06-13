using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float maxLife;
    public float life;
    public Animator animator;
    public SpriteRenderer sr;
    public Enemy en;
    public Collider2D col;
    public PlayerLife pl;

    public AudioSource explosionSound;
    public AudioSource damageSound;
    void Start()
    {
        animator.SetBool("Alive", true);
        life = maxLife;
    }

    
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blue Bullet"))
        {
            damageSound.Play();
            life--;
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        sr.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        if (life <= 0)
        {
            col.enabled = false;
            yield return new WaitForSeconds(0.01f);
            animator.SetBool("Alive", false);
            animator.Play("Enemy_Death");
            explosionSound.Play();
            pl.Recover();
            yield return new WaitForSeconds(1f);
            this.transform.position = new Vector2(100f,100f);
            yield return new WaitForSeconds(10);
            en.Appear();  
            col.enabled = true;
        }

    }
}
