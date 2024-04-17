using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInterfase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _armor;
    [SerializeField] private TextMeshProUGUI _hitPoint;
    [SerializeField] private TextMeshProUGUI _damage;

    private float _coin;

    [SerializeField] private TextMeshProUGUI _coinVy;

    private void OnEnable()
    {
        Character.BuffStat += UpdateStatInterfase;
    }
    private void UpdateStatInterfase(Character character)
    {

        _armor.text = "Armor: " + character.CurrentAtributes.armor.ToString();
        _hitPoint.text = "Hit point: " + character.CurrentAtributes.hitPoint.ToString();
        _damage.text = "Damage: " + character.CurrentAtributes.damage.ToString();
    }
    private void OnDisable()
    {
        Character.BuffStat -= UpdateStatInterfase;
    }


}
