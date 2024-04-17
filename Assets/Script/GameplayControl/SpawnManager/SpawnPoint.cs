using System.Collections;
using UnityEngine;


[RequireComponent(typeof(UnitInitialization))]

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _unitCounts;
    [SerializeField] private int _sizePool;
    [SerializeField] private float _radius;

    private PoolUnit _pool;
    private UnitInitialization unitInitialization;
    private RandomSpawnPosition _randomSpawn;

    private void Awake()
    {
        _timer.SetTimer(_delay);
        unitInitialization = GetComponent<UnitInitialization>();
        _pool = new PoolUnit(_sizePool, unitInitialization);
        _randomSpawn = new RandomSpawnPosition(transform, _radius);
    }

    private IEnumerator SpawnerUnit()
    {
        var wait = new WaitForSeconds(_delay);
        while (enabled)
        {
            for (int i = 0; i < _unitCounts; i++)
            {
                Spawn();
            }
            yield return wait;
        }
    }

    public void SartSpawnUnit() => StartCoroutine(nameof(SpawnerUnit));

    public void StopSpawnUnit()
    {
        StopCoroutine(nameof(SpawnerUnit));
        _pool.Reset();
    }

    private void Spawn()
    {
        var creep = _pool.GetUnits();
        creep.transform.position = _randomSpawn.GetRandomPosition();
        creep.ResetUnit();
        _timer.ResetTimer(_delay);
    }

}
















//2
//public class SpawnUnit : MonoBehaviour
//{
//    [SerializeField] private float _delay;
//    [SerializeField] private Timer _timer;
//    [SerializeField] private int _unitCounts;

//    private PoolUnit _pool;
//    private Warrior _warrior;

//    private void Awake()
//    {
//        _timer.SetTimer(_delay);

//        _pool = GetComponent<PoolUnit>();
//    }
//    private IEnumerator SpawnerUnit()
//    {
//        var wait = new WaitForSeconds(_delay);
//        while (enabled)
//        {
//            for (int i = 0; i < _unitCounts; i++)
//            {
//                Spawn();
//            }
//            yield return wait;
//        }
//    }

//    public void SartSpawnUnit() => StartCoroutine(nameof(SpawnerUnit));


//    public void StopSpawnUnit()
//    {
//        StopCoroutine(nameof(SpawnerUnit));
//        _pool.Reset();
//    }

//    private void Spawn()
//    {

//        _warrior = _pool.GetUnits();
//        _warrior.ResetUnit();
//        _timer.ResetTimer(_delay);
//    }

//}
