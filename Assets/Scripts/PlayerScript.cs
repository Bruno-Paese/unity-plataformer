using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float speed = 10.0f;
    public float jumpForce;
	public float maxSpeed;
    public GameObject itemFeedback;

    bool jump = false;
	float horizontal;
	Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);

        if (Input.GetButton("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            jump = true;
        }

        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        anim.SetFloat("SpeedY", rb.velocity.y);

        if (horizontal > 0)
        {
            sr.flipX = false;
        } else if(horizontal < 0)
        {
            sr.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            
            Destroy(collision.gameObject);
            Instantiate(itemFeedback, collision.transform.position, collision.transform.rotation);
        }
    }
}
