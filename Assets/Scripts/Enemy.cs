using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Animator animator;
    public GameObject bullet;
    public Transform[] shootPoints;
    public float bulletSpeed;

    [SerializeField] private float bulletTimer = 0.5f;
    private float bulletTime;


    public EnemyLife el;
    

    float posX;
    float posY;
    bool hunting;
    public float huntingDistance;

    public GameObject redPlanet;
    bool alert;

    public float patrolSpeed;
    public float huntSpeed;

    public AudioSource shootSound;
   

    void Start()
    {
        alert = false;
        Appear();
        RandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);
        float alertdistance = Vector2.Distance(player.transform.position, redPlanet.transform.position);

        if (alertdistance <= 10)
        {
            alert = true;
        }
        if (alertdistance > 10)
        {
            alert = false;
        }

        if (alert == false)
        {
            if (distance <= huntingDistance)
            {
                hunting = true;
            }
            if (distance > huntingDistance)
            {
                hunting = false;
            }
        }
        if (alert == true)
        {
            hunting = true;
        }
        

        
        if (hunting == false || player == null) 
        {
            agent.SetDestination(new Vector3(posX, posY, transform.position.z));
            if (this.transform.position == new Vector3(posX, posY, transform.position.z))
            {
                RandomDirection();
            }
            agent.stoppingDistance = 0;
        }
        if (hunting == true)
        {
           
            agent.SetDestination(player.transform.position);
            Shoot();
            agent.stoppingDistance = 3;
            agent.speed = huntSpeed;
        }
        
        


       
        if (agent.velocity.magnitude > 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
       
        
    }
    

    public void Shoot()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;
        bulletTime = bulletTimer; 
        if (agent.remainingDistance <= 6 && Time.timeScale == 1f)
        {
            shootSound.Play();
            var a = Instantiate(bullet, shootPoints[0].position, bullet.transform.rotation);
            a.GetComponent<Rigidbody2D>().velocity = shootPoints[0].up * bulletSpeed * agent.speed * Time.deltaTime;
            var b = Instantiate(bullet, shootPoints[1].position, bullet.transform.rotation);
            b.GetComponent<Rigidbody2D>().velocity = shootPoints[1].up * bulletSpeed * agent.speed * Time.deltaTime;
        }
            
    }
    public void Appear()
    {
        el.life = el.maxLife;
        this.transform.parent = null;
        float x = Random.Range(4f, 31f);
        float y = Random.Range(4f, 31f);
        this.transform.position = new Vector2((float)x, (float)y);
        animator.SetBool("Alive", true);
    }
    public void RandomDirection()
    {
        agent.speed = patrolSpeed;
        posX = Random.Range(-31f, 31f);
        posY = Random.Range(-31f, 31f);
        if (posX > -5 && posX < 5)
        {
            posX = 5;
        }if (posY > -5 && posY < 5)
        {
            posY = 5;
        }
    }
    public void Alerting()
    {
        alert = true;
    }
    public void Disalerting()
    {
        alert = false;
    }
}
