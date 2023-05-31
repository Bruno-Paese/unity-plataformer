using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float speed = 10.0f;
    public float jumpForce;
	public float maxSpeed;
    public GameObject itemFeedback;
    public GameObject enemyDeath;
    public AudioClip jumpSFX, pickupSFX;

    bool jump = false;
	float horizontal;
    bool canControlPlayer = true;
	Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioPlayer = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canControlPlayer)
        {
            return;
        }
		horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);

        if (Input.GetButton("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            jump = true;
            audioPlayer.PlayOneShot(jumpSFX);
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
            GameManager.gm.addGem();
            Destroy(collision.gameObject);
            Instantiate(itemFeedback, collision.transform.position, collision.transform.rotation);
            audioPlayer.PlayOneShot(pickupSFX);
        }

        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(PlayerDeath());
        }
    }

    public void die()
    {
        StartCoroutine(PlayerDeath());
    }

    IEnumerator PlayerDeath()
    {
        canControlPlayer = false;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
        anim.SetTrigger("PlayerDeath");
        yield return new WaitForSeconds(3.0f);
        GameManager.gm.ReloadScene();
        canControlPlayer = true;

    }

    IEnumerator RespawnEnemy(GameObject gm)
    {
        yield return new WaitForSeconds(10.0f);
        gm.SetActive(true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("RespawnEnemy"))
        {
            jump = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            Instantiate(enemyDeath, collision.transform.position, collision.transform.rotation);
            if (collision.gameObject.CompareTag("RespawnEnemy"))
                StartCoroutine(RespawnEnemy(collision.gameObject));
        }
    }
}
