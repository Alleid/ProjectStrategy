using System.Collections.Generic;

public class PoolUnit
{
    private int _size;

    private UnitInitialization unitInitialization;
    private Queue<CreepWarrior> _poolUnit;
    private List<UnitHandler> _poolUnitHandler;

    public IEnumerable<CreepWarrior> PoolUnits => _poolUnit;

    public PoolUnit(int _size,UnitInitialization unitInitialization)
    {
        this._size = _size;
        this.unitInitialization = unitInitialization;
        _poolUnit = new Queue<CreepWarrior>();
        _poolUnitHandler = new List<UnitHandler>();
    }

    public CreepWarrior GetUnits()
    {
        if (_poolUnit.Count == 0 && _size > _poolUnit.Count)
        {
            var warrior = unitInitialization.WarriorInitialization();
            _poolUnitHandler.Add(new UnitHandler(this, warrior));
            return warrior;
        }
        var units = _poolUnit.Dequeue();
        return units;
    }

    public void PutObject(CreepWarrior unit)
    {
        _poolUnit.Enqueue(unit);
    }

    public void Reset()
    {
        _poolUnit.Clear();
        foreach(var handler in _poolUnitHandler)
        {
            handler.Remuve();
        }
    }

}





















//2
//public class PoolUnit : MonoBehaviour
//{
//    [SerializeField] private Warrior _prefab;
//    [SerializeField] private int _size;

//    [SerializeField] private Transform _spawnPosition;
//    [SerializeField] private float _radius;

//    [SerializeField] private Transform _targetUnit;
//    [SerializeField] private WarriorInfo warriorInfo;


//    EventManagerStat eventManager;

//    private RandomSpawnPosition _randomSpawn;

//    private Character _character;

//    private Queue<Warrior> _poolUnit;

//    public List<UnitHandler> _poolUnitHandler;
//    public IEnumerable<Warrior> PoolUnits => _poolUnit;
//    private void Awake()
//    {
//        _poolUnit = new Queue<Warrior>();
//        _character = new Character(warriorInfo);
//        _poolUnitHandler = new List<UnitHandler>();
//        _randomSpawn = new RandomSpawnPosition(transform, _radius);
//        eventManager = EventManagerStat.GetEventManagerStat();
//    }
//    private void Start()
//    {

//        if (_character.CurrentAtributes.team == Team.Blue)
//        {
//            EventManagerStat.BuffStat += _character.AddBuff;

//        }
//    }

//    public Warrior GetUnits()
//    {
//        if (_poolUnit.Count == 0 && _size > _poolUnit.Count)
//        {
//            Warrior objects = Instantiate(_prefab);

//            objects.Initialized(_character, _targetUnit);



//            _poolUnitHandler.Add(new UnitHandler(this, objects));
//            objects.transform.position = _randomSpawn.GetRandomPosition();

//            return objects;
//        }
//        var units = _poolUnit.Dequeue();
//        units.transform.position = _spawnPosition.position;
//        return units;
//    }

//    public void PutObject(Warrior unit)
//    {
//        _poolUnit.Enqueue(unit);
//    }

//    public void Reset()
//    {
//        _poolUnit.Clear();
//    }
//    private void OnDisable()
//    {
//        EventManagerStat.BuffStat -= _character.AddBuff;
//    }
//}





















//1
//public class PoolUnit : MonoBehaviour
//{
//    [SerializeField] private Warrior _prefab;//
//    [SerializeField] private int _size;

//    [SerializeField] private Transform _spawnPosition;
//    [SerializeField] private float _radius;

//    [SerializeField] private Transform _targetUnit;//
//    [SerializeField] private WarriorInfo warriorInfo;//

//    private RandomSpawnPosition _randomSpawn;

//    private Character _character;//

//    private Queue<Warrior> _poolUnit;

//    public List<UnitHandler> _poolUnitHandler;
//    public IEnumerable<Warrior> PoolUnits => _poolUnit;
//    //private int IDs;
//    private void Awake()
//    {
//        _poolUnit = new Queue<Warrior>();
//        _character = new Character(warriorInfo);
//        _poolUnitHandler = new List<UnitHandler>();
//        _randomSpawn = new RandomSpawnPosition(transform, _radius);
//    }

//    public Warrior GetUnits()
//    {
//        if (_poolUnit.Count == 0 && _size > _poolUnit.Count)
//        {
//            Warrior objects = Instantiate(_prefab);

//            objects.Initialized(_character, _targetUnit);
//            _poolUnitHandler.Add(new UnitHandler(this, objects));
//            objects.transform.position = _randomSpawn.GetRandomPosition();

//            return objects;
//        }
//        var units = _poolUnit.Dequeue();
//        units.transform.position = _spawnPosition.position;
//        return units;
//    }

//    public Character GetCharacter()
//    {
//        return _character;
//    }
//    public void PutObject(Warrior unit)
//    {
//        _poolUnit.Enqueue(unit);
//    }

//    public void Reset()
//    {
//        _poolUnit.Clear();
//        //foreach(var unit in _poolUnitHandler)
//        //{
//        //    unit.Remuve();
//        //}
//    }
//}

