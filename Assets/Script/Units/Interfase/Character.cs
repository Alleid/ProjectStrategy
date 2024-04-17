using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine.Events;

public class Character : IBuffadle
{

    public Attributes BaseAtributs { get; }
    public Attributes CurrentAtributes { get; private set; }
    
    public static Action<Character> BuffStat;

    public Character(WarriorInfo warriorInfo)
    {
        BaseAtributs = new Attributes
        {
            team = warriorInfo.Team,
            agrLayerMask = warriorInfo.LayerMask,
            hitPoint = warriorInfo.HitPoint,
            armor = warriorInfo.Armor,
            damage = warriorInfo.Damage,
            atackSpeed = warriorInfo.AtackSpeed,
            distanseAtak = warriorInfo.DistanseAtak,
            speed = warriorInfo.Speed,
            radiusAggr = warriorInfo.RadiusAggr,
            
        };
        CurrentAtributes = BaseAtributs;
    }

    public void Update()
    {
        BuffStat?.Invoke(this);

    }
    public void AddBuff(IBuff buff)
    {
        CurrentAtributes = buff.ApplyBuff(CurrentAtributes);
        BuffStat?.Invoke(this);
}
    public void ResetCharacter()
    {
        CurrentAtributes = BaseAtributs;
    }
}

