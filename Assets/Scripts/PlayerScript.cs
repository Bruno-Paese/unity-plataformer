using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float speed = 10.0f;
	public float maxSpeed;
	float horizontal;
	Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horizontal, 0);
    }
}
