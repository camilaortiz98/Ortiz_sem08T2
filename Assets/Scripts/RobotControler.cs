using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotControler : MonoBehaviour
{
    public float velocityX = 10;
    public float jumpForce = 40;

    public GameObject rightBullet;
    public GameObject leftBullet;

    private ScoreController game;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //const
    private const int IDLE = 0;
    private const int RUN = 1;
    private const int JUMP = 2;
    private const int SLIDE = 3;
    private const int SHOOT = 4;
    private const int RUNSHOOT = 5;
    private const int DEAD = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        game = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUNSHOOT);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUNSHOOT);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            changeAnimation(SHOOT);
            //crearemos el objeto
            var bullet = sr.flipX ? leftBullet : rightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);          

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            changeAnimation(SLIDE);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            game.LoseLife();
        }

        if (collision.gameObject.CompareTag("Switch"))
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
