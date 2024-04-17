using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UnitHandler
{
    private PoolUnit pool;
    private CreepWarrior _creep;

    public UnitHandler(PoolUnit poolUnit,CreepWarrior warrior)
    {
        pool = poolUnit;
        _creep = warrior;
        _creep.UnitDead += pool.PutObject;       
    }
    public void Remuve() => _creep.UnitDead -= pool.PutObject;
}

