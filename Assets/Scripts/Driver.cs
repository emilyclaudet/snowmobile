using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float slowTime = 5.0f;
    [SerializeField] float boostSpeed = 100f;
    [SerializeField] float boostTime = 5.0f;
    [SerializeField] private AudioSource boostSoundEffect;
    [SerializeField] private AudioSource bumpSoundEffect;
    private float startSpeed;

    void Start()
    {
        startSpeed = moveSpeed;
    }

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
        Invoke("EndSpeedEffect", slowTime);
        bumpSoundEffect.Play();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost") 
        {
            moveSpeed = boostSpeed;
            Invoke("EndSpeedEffect", boostTime);
            boostSoundEffect.Play();
        }
    }

    void EndSpeedEffect() 
    {
        moveSpeed = startSpeed;
    }

}
