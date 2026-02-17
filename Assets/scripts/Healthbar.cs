using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private DodgerAttributes dodgerAttributes;
    [SerializeField]
    private float width, height;
    [SerializeField]
    private RectTransform _healthBar;

    public void Start()
    {
        width = _healthBar.rect.width;
        height = _healthBar.rect.height;
        dodgerAttributes = DodgerAttributes.GetInstance();
        dodgerAttributes.HealthChanged.AddListener(UpdateHealthbar);
        Debug.Log("Listener added");
    }
    public void UpdateHealthbar()
    {
        float newWIdth = (float)dodgerAttributes._currentHealth / (float)dodgerAttributes._maxHealth * width;
        Debug.Log("newWIdth " + newWIdth);
        _healthBar.sizeDelta = new Vector2(newWIdth, height);
    }
}
