using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    private float moveSpeed = 100f;
    float horizontalMove;
    float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal"); 
        verticalMove = Input.GetAxisRaw("Vertical");
        playerAnimator.SetFloat("horizontalMove", horizontalMove);
        playerAnimator.SetFloat("verticalMove", verticalMove);
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalMove * moveSpeed * Time.fixedDeltaTime, verticalMove * moveSpeed * Time.fixedDeltaTime);
        playerRigidbody2D.velocity = movement;
    }
}
