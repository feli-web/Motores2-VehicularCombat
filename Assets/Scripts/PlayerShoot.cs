using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject center;
    public GameObject bullet;
    public Transform[] shootpoints; 
    public float bulletSpeed;

    public AudioSource shootSound;
    public AudioSource clickSound;
    void Start()
    {
        center.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1f)
        {
            var a = Instantiate(bullet, shootpoints[0].position, shootpoints[0].rotation);
            var b = Instantiate(bullet, shootpoints[1].position, shootpoints[1].rotation);
            a.GetComponent<Rigidbody2D>().velocity = shootpoints[0].up * bulletSpeed * 4 * Time.deltaTime;
            b.GetComponent<Rigidbody2D>().velocity = shootpoints[1].up * bulletSpeed * 4 * Time.deltaTime;
            shootSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.M) && Time.timeScale == 1f)
        {
            bool isActive = center.activeSelf;

            center.SetActive(!isActive);

            clickSound.Play();
        }
    }
}
