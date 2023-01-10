using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    private Rigidbody _rigidbody;
    public float jumpForce = 10;
    private bool isOnTheGround = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
       
    }

    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        
    }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;

        }
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}
