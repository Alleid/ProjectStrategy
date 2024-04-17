using UnityEngine.UI;
using UnityEngine;

public class BoostArmor : MonoBehaviour, IBuff
{
    [SerializeField] private int _armor;
    [SerializeField] private int _price;
    [SerializeField] private Text _textCount;

    private void OnEnable()
    {
        _textCount.text = _price.ToString();
    }
    public Attributes ApplyBuff(Attributes attributes)
    {
        var newStats = attributes;
        newStats.armor = Mathf.Max(newStats.armor + _armor, 0);
        _price += 3;
        _textCount.text = _price.ToString();
        return newStats;
    }

    public int PriceBuff()
    {
        return _price;
    }
}
