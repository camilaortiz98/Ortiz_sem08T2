using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private const int RUN = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-3, rb.velocity.y);
        changeAnimation(RUN);
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
