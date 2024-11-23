using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    [SerializeField] float speed;
    private Soundmanager soundManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<Soundmanager>(); // SoundManager referansýný al
    }

    private void Update()
    {
        MovePlayer();
        UpdateAnimation();
        HandleWalkingSound();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void UpdateAnimation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

    private void HandleWalkingSound()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0) // Karakter hareket ediyorsa
        {
            soundManager.PlayWalkSound();
        }
        else // Karakter duruyorsa
        {
            soundManager.StopWalkSound();
        }
    }
}
