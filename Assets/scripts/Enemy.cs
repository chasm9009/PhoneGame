using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private BoxCollider2D boxCollider2D;
    void Update()
    {
        Vector2 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y < -0.5f)
        {
            Destroy(this);
        }
    }

    public static explicit operator Enemy(GameObject v)
    {
        throw new NotImplementedException();
    }
}
