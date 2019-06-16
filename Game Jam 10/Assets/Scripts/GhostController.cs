using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostController : MonoBehaviour
{
    private AIPath aiPath;
    private Animator animator;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = aiPath.desiredVelocity.x;
        Debug.Log("" + velocity);
        //animator.SetFloat("horizontalMove", velocity.x);
        //animator.SetFloat("verticalMove", velocity.y);
    }
}
