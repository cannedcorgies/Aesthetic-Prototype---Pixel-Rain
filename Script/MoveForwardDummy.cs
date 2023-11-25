using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardDummy : MonoBehaviour
{

    public float cooldown_time = 0.5f;
    public float cooldown_time_backwards = 1.2f;
    public float cooldown_currTime;
    public float cooldown_nextTime = 0f;
    public bool particle_available = true;

    public ParticleSystem particleSystem;

    [SerializeField] private Rigidbody rb;
    public float speed = 15f;
    public float maxSpeed = 10f;
    public float slowdown = 5f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

        Debug.Log(cooldown_currTime + " - " + cooldown_nextTime);
        cooldown_currTime = Time.time;

        if (cooldown_currTime > cooldown_nextTime) {
            
            if (!particle_available) {Debug.Log("I'M BACK!");}
            particle_available = true;

        }

            
        if (Input.GetKey(KeyCode.W))            // moving forward
        {
            rb.AddForce(transform.right * speed);

            if (particle_available) {

                particle_available = false;
                cooldown_nextTime = Time.time + cooldown_time;
                particleSystem.Play();

            }

        } else if (Input.GetKey(KeyCode.S)) {   // moving backwards

            rb.AddForce(transform.right * -speed * 0.2f);

            if (particle_available) {

                particle_available = false;
                cooldown_nextTime = Time.time + cooldown_time_backwards;
                particleSystem.Play();
                
            }

        } else {

            rb.velocity = rb.velocity.normalized * slowdown;

        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.Rotate(0, -45, 0);
            particleSystem.Play();

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            transform.Rotate(0, 45, 0);
            particleSystem.Play();

        }

        if (rb.velocity.magnitude > maxSpeed) {

            rb.velocity = rb.velocity.normalized * maxSpeed;

        }
    }
    
}
