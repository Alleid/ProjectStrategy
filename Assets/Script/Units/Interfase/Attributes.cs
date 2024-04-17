using UnityEngine;

public struct Attributes
{

    public float hitPoint;
    public float armor;
    public float damage;
    public float atackSpeed;
    public float distanseAtak;
    public float speed;
    public float radiusAggr;
    public Team team;
    public LayerMask agrLayerMask;

    public Attributes(Team team, LayerMask agrLayerMask, float hitPoint, float armor, float damage, float atackSpeed, float distanseAtak, float speed, float radiusAggr)
    {
        this.team = team;
        this.agrLayerMask = agrLayerMask;
        this.hitPoint = hitPoint;
        this.armor = armor;
        this.damage = damage;
        this.atackSpeed = atackSpeed;
        this.distanseAtak = distanseAtak;
        this.speed = speed;
        this.radiusAggr = radiusAggr;
    }
}

