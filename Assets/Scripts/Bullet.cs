using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life;
    
    void Start()
    {
        Invoke("Kill", life );
        
        this.transform.rotation = Quaternion.Euler( 0, 0, 0 );
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Kill()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Kill();
        }
    }
}
