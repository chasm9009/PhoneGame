using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public int id;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;

    protected float gravityScale { get; set; }

    public void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        UpdateGravityScale();
    }

    public virtual void UpdateGravityScale()
    {
        rb.gravityScale = gravityScale;
    }
    void Update()
    {
        Vector2 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y < -0.1f)
        {
            Destroy(gameObject);
        }
    }

}