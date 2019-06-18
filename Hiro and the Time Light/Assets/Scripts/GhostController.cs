using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostController : MonoBehaviour
{
    private Rigidbody2D ghostRb2D;
    private AIPath aiPath;
    private Animator animator;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        ghostRb2D = GetComponent<Rigidbody2D>();
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = aiPath.velocity;
        Debug.Log("" + velocity);
        animator.SetFloat("horizontalMove", velocity.x);
        animator.SetFloat("verticalMove", velocity.y);
    }
}
