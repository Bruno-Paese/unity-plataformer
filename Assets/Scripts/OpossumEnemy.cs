using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumEnemy : MonoBehaviour
{
    public float speed = 5;
    public GameObject edgeCheck;
    public float rayDistance = 1;

    RaycastHit2D groundDetector;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        groundDetector = Physics2D.Raycast(edgeCheck.transform.position, Vector2.down, rayDistance);

        if (groundDetector.collider == false)
        {
            speed = speed * -1;

            Vector3 tempScale = transform.localScale;
            tempScale.x = -tempScale.x;
            transform.localScale = tempScale;
        }
    }
}
