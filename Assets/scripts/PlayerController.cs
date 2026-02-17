using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody2D _playerBody;

    [SerializeField]
    private inputSystem _inputSystem;

    private DodgerAttributes dodgerAttributes;
    [SerializeField]
    private EnemySpawner enemySpawner;

    void Start()
    {
        dodgerAttributes = DodgerAttributes.GetInstance();
    }

    void FixedUpdate()
    {
        int moveDir = 0;
        Vector2 screenPos;

        if (_inputSystem.IsPressing(out screenPos))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(screenPos);

            if (touchPos.x < 0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;
            }
        }

        Vector2 viewportPos = Camera.main.WorldToViewportPoint(_playerBody.position);

        if ((viewportPos.x <= 0f && moveDir < 0f) || (viewportPos.x >= 1 && moveDir > 0))
        {
            moveDir = 0;
        }

        _playerBody.linearVelocityX = moveDir * _speed;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            dodgerAttributes.UpdateHealth(-1);
            Destroy(collision.gameObject);

            if(dodgerAttributes._currentHealth<=0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
