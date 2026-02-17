using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DodgerAttributes
{
    public int _maxHealth { get; set; }
    public int _currentHealth { get; set; }
    public int _currentScore { get; set; }

    public UnityEvent HealthChanged = new();
    private static DodgerAttributes instance;

    private DodgerAttributes(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _currentScore = 0;
    }

    public static DodgerAttributes GetInstance(int maxHealth = 10)
    {
        if (instance is not null)
        {
            Debug.Log("not null");
            return instance;
        }
        Debug.Log("null");
        return instance = new DodgerAttributes(maxHealth);
    }
    public void UpdateScore(int dif)
    {
        _currentScore += dif;
    }
    public void UpdateHealth(int dif)
    {
        _currentHealth += dif;
        HealthChanged.Invoke();
        Debug.Log("HealthChanged");
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
        _currentScore = 0;
    }
}