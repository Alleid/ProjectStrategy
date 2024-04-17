using System;
using UnityEngine;

public class Сastle : MonoBehaviour, IUnit
{
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private float _hitPoint;
    [SerializeField] private float _armor;
    [SerializeField] private float _hitPointUnit;

    public Action UnitDeat;
    public bool isLive { get; private set; }

    private void Update()
    {
        if (_hitPoint <= 0)
        {
            Dead();
        }
    }
    public void TakeDamage(float damage, out bool thisUnitDeat)
    {
        if (_hitPoint > 0)
        {
            _hitPoint -= (float)(damage - ((double)damage / 100) * _armor);
            _healthBar.SetHealth((int)_hitPoint);
            thisUnitDeat = false;
        }
        else
        {
            thisUnitDeat = true;
        }
    }

    public void Dead()
    {
        isLive = false;
        gameObject.SetActive(false);
    }

    public void ResetUnit()
    {
        //_hitPoint = _myCharacter.CurrentAtributes.hitPoint;
        //_healthBar.SetMaxHealth((int)_myCharacter.CurrentAtributes.hitPoint);
        //isLive = true;
        //gameObject.SetActive(true);
    }
}
