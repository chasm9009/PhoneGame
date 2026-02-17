using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float spawnRateSeconds = 2;
    [SerializeField]
    private inputSystem _inputsystem;
    [SerializeField]
    private TextMeshProUGUI scoreText;


    public int score = 0;

    private bool gameStarted = false;

    private IEnumerator coroutine;

    private Stack<int> _avalibleEnemies;
    private List<Enemy> _activeEnemies;

    private List<Enemy> _inactiveEnemies;
    DodgerAttributes dodgerAttributes;

    public void Start()
    {
        dodgerAttributes = DodgerAttributes.GetInstance();
        for (int i = 0; i < 10; i++)
        {
            //enemyPool.AddFirst(Instantiate(enemy, spawnPos, Quaternion.identity));
        }
    }

    public void Update()
    {
        if (!gameStarted && _inputsystem.IsPressing(out _))
        {
            gameStarted = true;
            coroutine = EnemySpawnerRoutine();
            StartCoroutine(coroutine);
        }


    }

    private WaitForSeconds wait;

    public IEnumerator EnemySpawnerRoutine()
    {
        wait = new WaitForSeconds(spawnRateSeconds);
        while (true)
        {
            var randomScreenPos = Random.Range(0f, 1f);

            var viewportPos = new Vector2(randomScreenPos, 1);
            Vector2 spawnPos = Camera.main.ViewportToWorldPoint(viewportPos);
            _ = Instantiate(enemy, spawnPos, Quaternion.identity);
            dodgerAttributes.UpdateScore(1);

            scoreText.text = dodgerAttributes._currentScore.ToString();
            yield return wait;
        }
    }

    private void dissableEnemy(GameObject gameObject)
    {
        if (!(gameObject is Enemy))
        {
            return;
        }
        Enemy enemy = (Enemy)gameObject;
    }
}
