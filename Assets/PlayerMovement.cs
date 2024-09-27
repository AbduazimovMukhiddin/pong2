using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    private Rigidbody2D rb;
    private Vector2 playermMove;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playermMove = new Vector2(0,Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        if(ball.transform.position.y > transform.position.y + 0.5f)
        {
            playermMove = new Vector2(0, 1);
        }
        else if(ball.transform.position.y < transform.position.y - 0.5f)
        {
            playermMove = new Vector2(0, -1);
        }
        else
        {
            playermMove = new Vector2(0, 0);
        }
    }
    
    private void FixedUpdate()
    {
        rb.velocity = playermMove * movementSpeed;
    }
}
