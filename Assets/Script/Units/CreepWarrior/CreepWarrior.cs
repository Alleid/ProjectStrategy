using System;
using UnityEngine;

[RequireComponent(typeof(Closest))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Rigidbody))]

public class CreepWarrior : MonoBehaviour , ICreepWarrior
{
    
    [SerializeField] private HealthBar _healthBar;

    private Character _myCharacter;

    private float _hitPoint;
    private float _armor;

    private Closest _slosest;
    private Attack _attack;
    private Move _move;
    private Rigidbody _rigidbody;

    public Action <CreepWarrior> UnitDead;

    public Transform targetPoint { get; private set; }

    private void Awake()
    {
        _slosest = GetComponent<Closest>();
        _rigidbody = GetComponent<Rigidbody>();
        _attack = GetComponent<Attack>();
    }

    public void Initialized(Character character, Transform tergetBild)
    {
        _myCharacter = character;
        targetPoint = tergetBild;
        _move = new Move(character.CurrentAtributes.speed,_myCharacter,this.transform, _slosest, _rigidbody);
        InitializedComponent(_myCharacter);
    }

    private void Start()
    {   
        _healthBar.SetMaxHealth((int)_myCharacter.CurrentAtributes.hitPoint);
    }

    private void Update()
    {
        if (_hitPoint <= 0)
        {
            Dead();
        }
    }

    public void TakeDamage(float damage, out bool isDontLive)
    {
        if (_hitPoint > 0)
        {
            _hitPoint -= (float)(damage - (((double)damage / 100) * _armor));
            _healthBar.SetHealth((int)_hitPoint);
            isDontLive = false;
        }
        else
        {
            isDontLive = true;
        }
    }

    public void BaffUnits(IBuff buff)
    {
        _myCharacter.AddBuff(buff);
    }

    public void Dead()
    {
        UnitDead?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void ResetUnit()
    {
        _hitPoint = _myCharacter.CurrentAtributes.hitPoint;
        _attack.BuffDamage(_myCharacter);
        _armor = _myCharacter.CurrentAtributes.armor;
        _healthBar.SetMaxHealth((int)_myCharacter.CurrentAtributes.hitPoint);
        gameObject.SetActive(true);
    }

    private void InitializedComponent(Character character)
    {
        _slosest.InitializedSloset(character, targetPoint);
        _attack.InitializedAttack(character,_move );
    }
}