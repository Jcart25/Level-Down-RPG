using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    private float Vmove;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        Vmove = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(speed * Vmove, rb.velocity.y);
        rb.velocity = new Vector2(speed * move, rb.velocity.x);
    }
}
