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
        transform.Translate(Time.deltaTime * speed * Vector2.right);

        Vector2 point;
        if (speed > 0)
        {
            point = new(col.bounds.max.x + 0.01f, col.bounds.min.y);
        }
        else
        {
            point = new(col.bounds.min.x - 0.01f, col.bounds.min.y);
        }

        Debug.DrawRay(point, Vector2.down * 0.05f, Color.purple);

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, 0.05f);
        if (hit.collider == null)
        {
            speed *= -1;
        }
    }

}
