using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _full;
    [SerializeField] private Billboard _billboard;
    public void SetHealth(int health)
    {
        _slider.value = health;
        _full.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
        _full.color = _gradient.Evaluate(1f);
    }

}
