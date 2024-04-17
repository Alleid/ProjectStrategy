using UnityEngine;
using UnityEngine.UI;

public class BoostHitpoint : MonoBehaviour, IBuff
{

    [SerializeField] private int _hitpoint;
    [SerializeField] private int _price;
    [SerializeField] private Text _textCount;

    private void OnEnable()
    {
        _textCount.text = _price.ToString();
    }

    public Attributes ApplyBuff(Attributes attributes)
    {
        var newStats = attributes;
        newStats.hitPoint = Mathf.Max(newStats.hitPoint + _hitpoint, 0);
        _price += 3;
        _textCount.text = _price.ToString();
        return newStats;
    }

    public int PriceBuff()
    {
        return _price;
    }
}
