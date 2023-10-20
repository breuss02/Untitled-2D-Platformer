using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1f;

    private bool isGrounded;

    private Rigidbody2D Rigid;

    float dirX;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        Rigid.gravityScale = 0.6f;

        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);

        if (isGrounded && SwipeManager.tap)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.D))
        {
            Right();
        }

        if (Input.GetKey(KeyCode.A))
        {
            Left();
        }

    }

    private void FixedUpdate()
    {
        Rigid.velocity = new Vector2(dirX, Rigid.velocity.y);
    }

    private void Jump()
    {
        Rigid.velocity = new Vector2(Rigid.velocity.x, jumpForce);
    }

    private void Right()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void Left()
    {
        transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            PlayerManager.gameOver = true;
            Debug.Log("Hit");
        }
    }

}
