

using UnityEngine;

[CreateAssetMenu(fileName = "WarriorInfo", menuName = "Gameplay/ New WarriorInfo")]
public class WarriorInfo : ScriptableObject
{
    [SerializeField] Team _team;
    [SerializeField] private LayerMask agrLayerMask;
    [SerializeField] private float _hitPoint;
    [SerializeField] private float _armor;
    //Attack
    [SerializeField] private float _damage;
    [SerializeField] private float _atackSpeed;
    [SerializeField] private float _distanseAtak;
    //Move
    [SerializeField] private float _speed;
    //Slosest
    [SerializeField] private float _radiusAggr;

    public Team Team => this._team;
    public LayerMask LayerMask => this.agrLayerMask;
    public float HitPoint => this._hitPoint;
    public float Armor => this._armor;
    public float Damage => this._damage;
    public float AtackSpeed => this._atackSpeed;
    public float DistanseAtak => this._distanseAtak;
    public float Speed => this._speed;
    public float RadiusAggr => this._radiusAggr;

}
