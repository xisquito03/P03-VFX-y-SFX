using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    private Rigidbody _rigidbody;

    public float jumpForce = 10;

    private bool isOnTheGround = true;

    private Animator _animator;

    public float gravityModifier = 1.5f;

    public ParticleSystem explosionParticle;

    public ParticleSystem dirtParticle;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
       
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
           //Destroy(otherCollider.gameObject); // Destruir el collider
           GameOver();
        
    }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();
        }
        
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", 1);

        explosionParticle.Play();
        dirtParticle.Stop();
    }
    
}
