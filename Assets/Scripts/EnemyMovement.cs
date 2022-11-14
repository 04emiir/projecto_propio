using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    // Start is called before the first frame update
    Rigidbody2D enemy;
    SpriteRenderer enemy_sprite;
    Animator animator;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy_sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        InvokeRepeating("enemyMoving", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((enemy.position.x <= 29 && enemy.velocity.x < 0f) || (enemy.position.x >= 40 && enemy.velocity.x > 0f)) {
            enemy.velocity *= new Vector2(-0.6f, 1);
        }

        if (enemy.velocity.x > 0f) {
            enemy_sprite.flipX = true;
            animator.SetBool("running", true);
        } else if (enemy.velocity.x < 0f) {
            enemy_sprite.flipX = false;
            animator.SetBool("running", true);
        } else {
            animator.SetBool("running", false);
        }
    }

    public void enemyMoving() {
        enemy.velocity = new Vector2(Random.Range(-10.0f, 10.0f), enemy.velocity.y);
    }
}
