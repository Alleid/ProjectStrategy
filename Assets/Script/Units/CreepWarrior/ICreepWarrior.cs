using UnityEngine;

public interface ICreepWarrior : IUnit
{
    public void Initialized(Character character, Transform tergetBild);

    public void BaffUnits(IBuff buff);
}


