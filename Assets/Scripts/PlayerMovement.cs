using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask ground;
    Animator animation;
    public Rigidbody2D player;
    float speed = 5f;
    float jump = 15f;
    public SpriteRenderer sprite;
    public BoxCollider2D player_collider;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.DrawRay(transform.position, Vector2.down*2, Color.green);
        float direction = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(speed * direction, player.velocity.y);

        if (direction > 0f) {
            sprite.flipX = false;
            animation.SetBool("running", true);
        } else if (direction < 0f) {
            sprite.flipX = true;
            animation.SetBool("running", true);
        } else {
            animation.SetBool("running", false);
        }

        if (Input.GetKeyDown("space") && IsGrounded())
            player.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        //animation.SetInteger("velocity_x", (int)player.velocity.x);
        animation.SetInteger("velocity_y", (int)player.velocity.y);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, ground);
        if (hit.collider != null) {
            return true;
        }
        return false;

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemies") {
            Vector2 kb = new Vector2(10f, 5f);
        
            player.AddForce(kb, ForceMode2D.Impulse);
            animation.SetTrigger("is_hit");
            
        }
    }
}
