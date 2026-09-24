using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] private float speed = 5f;

    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Move();
        CheckGround();
        CheckCollision();
    }

    private void CheckGround()
    {
        Vector2 pointCheckGround;

        if (speed > 0)
        {
            pointCheckGround = new(col.bounds.max.x + 0.01f, col.bounds.min.y);
        }
        else
        {
            pointCheckGround = new(col.bounds.min.x - 0.01f, col.bounds.min.y);
        }

        Debug.DrawRay(pointCheckGround, Vector2.down * 0.05f, Color.purple);
        RaycastHit2D hit = Physics2D.Raycast(pointCheckGround, Vector2.down, 0.05f);
        if (hit.collider == null)
        {
            speed *= -1;
        }
    }

    private void CheckCollision()
    {

        Vector2 pointCheckOther;
        Vector2 direction;

        if (speed > 0)
        {
            pointCheckOther = new(col.bounds.max.x + 0.01f, col.bounds.min.y + 0.01f);
            direction = Vector2.right;
        }
        else
        {
            pointCheckOther = new(col.bounds.min.x - 0.01f, col.bounds.min.y + 0.01f);
            direction = Vector2.left;
        }

        Debug.DrawRay(pointCheckOther, direction * 0.01f, Color.cyan);
        RaycastHit2D hit = Physics2D.Raycast(pointCheckOther, direction, 0.01f);
        if (hit.collider != null)
        {
            speed *= -1;
        }
    }

    private void Move()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
    }
}
