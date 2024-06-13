using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Yes", 0.0f);
            Invoke("No", 0.1f);
        }
    }
    public void Yes()
    {
        sr.enabled = true;
    }
    public void No()
    {
        sr.enabled = false;
    }
}
