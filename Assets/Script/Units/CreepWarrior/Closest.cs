using System;
using UnityEngine;

public class Closest : MonoBehaviour
{

    private LayerMask _agoLayerMask;
    private float _radiusAggr;

    private Collider[] _withinAggroColliders;
    private Transform _targenBild;
    public event Action<Transform> FindAggrUnit;
    public event Action<Transform> FindAttakUnit;

    private void FixedUpdate()
    {
        _withinAggroColliders = Physics.OverlapSphere(transform.position, _radiusAggr, _agoLayerMask);
        if (_withinAggroColliders.Length > 0)
        {
            float dist = Mathf.Infinity;
            Collider currentCollider = _withinAggroColliders[0];

            foreach (Collider col in _withinAggroColliders)
            {
                float currentDist = Vector3.Distance(transform.position, col.transform.position);
                if (currentDist < dist)
                {
                    currentCollider = col;
                    dist = currentDist;
                }
            }
            FindAggrUnit?.Invoke(currentCollider.transform);
            FindAttakUnit?.Invoke(currentCollider.transform);
        }
        else
        {
            if (_targenBild != null)
            {
                FindAggrUnit?.Invoke(_targenBild);

                FindAttakUnit?.Invoke(_targenBild);
            }
        }
    }

    public void InitializedSloset(Character character, Transform targetPoint)
    {
        _radiusAggr = character.CurrentAtributes.radiusAggr;
        _agoLayerMask = character.CurrentAtributes.agrLayerMask;
        _targenBild = targetPoint;
    }

}


