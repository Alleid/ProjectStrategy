using System;
using UnityEngine;
using UnityEngine.Events;


public class UnitInitialization : MonoBehaviour
{
    [SerializeField] private CreepWarrior _prefab;
    [SerializeField] private Transform _targetUnit;
    [SerializeField] private WarriorInfo warriorInfo;

    private Character _character;

    private void Awake()
    {
        _character = new Character(warriorInfo);
    }

    private void OnEnable()
    {
        if (_character.CurrentAtributes.team == Team.Blue)
        {
            EventManagerStat.BuffStat += _character.AddBuff;
        }
    }

    public CreepWarrior WarriorInitialization()
    {
        CreepWarrior objects = Instantiate(_prefab);
        objects.Initialized(_character, _targetUnit);
        _character.Update();
        return objects;
    }

    private void OnDisable()
    {
        EventManagerStat.BuffStat -= _character.AddBuff;
    }
}
