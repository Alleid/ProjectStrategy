using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] private SpawnPoint spawnUnitBlue;
    [SerializeField] private SpawnPoint spawnUnitRed;

    void Start()
    {
        
    }
    public void StartGame()
    {
        spawnUnitBlue.SartSpawnUnit();
        spawnUnitRed.SartSpawnUnit();
    }

}
