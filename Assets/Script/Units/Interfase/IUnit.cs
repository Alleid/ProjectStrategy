using UnityEngine;

public interface IUnit
{

    public void TakeDamage(float damage, out bool thisUnitDeat);

    public void Dead();

    public void ResetUnit();

}

