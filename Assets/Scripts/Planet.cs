using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public WinLoseManager wlm;
    public Animator animator;
    public SpriteRenderer sr;
    public SpriteRenderer aura;
    public GameObject crack1;
    public GameObject crack2;
    public float maxLife;
    float life;
    public AudioSource damageSound;
    public AudioSource explosionSound;
    void Start()
    {
        life = maxLife;
        crack1.SetActive(false); 
        crack2.SetActive(false);
    }

    
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blue Bullet"))
        {
            life-= 0.5f;
            StartCoroutine(Damage());
            damageSound.Play();
        }
    }
    IEnumerator Damage()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.white;
        if (life <= maxLife * 0.5f && life > maxLife * 0.25f)
        {
            aura.color = Color.gray;
            crack1.SetActive(true);
        }
        if (life <= maxLife * 0.25f)
        {
            aura.color = Color.red;
            crack2.SetActive(true);
        }
        if (life <= 0)
        {
            aura.enabled = false;
            crack1.SetActive(false);
            crack2.SetActive(false);
            animator.Play("Planet");
            explosionSound.Play();
            yield return new WaitForSeconds(1f);
            wlm.Win();
            Destroy(gameObject);
        }
    }

    
}
