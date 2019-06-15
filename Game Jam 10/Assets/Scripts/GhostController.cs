using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Animator animator;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = GetComponent<Rigidbody2D>().velocity;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(velocity);
        animator.SetFloat("horizontalMove", velocity.x);
        animator.SetFloat("verticalMove", velocity.y);
    }
}
