using UnityEngine;


public class Move 
{
    private float _speed;
    private bool _isMoving;

    private Team _team;
    private Vector3 _direction;
    private Transform _thisUnit;
    private Closest _closest;

    public Move(float _speed, Character character, Transform _thisUnit, Closest closest,Rigidbody rigidbody)
    {
        this._speed = _speed;
        _team = character.CurrentAtributes.team;
        this._thisUnit = _thisUnit;
        this._closest = closest;
        this._closest.FindAggrUnit += MoveTarget;
        rigidbody.maxAngularVelocity = 0;
    }

    private void MoveTarget(Transform target)
    {
        if (_isMoving)
        {
            _thisUnit.LookAt(target.position);
            _direction = ((target.position - _thisUnit.position) * (float)_team).normalized;
            _thisUnit.Translate(_direction * _speed * Time.deltaTime);
        }
    }

    public void StopMoving() => _isMoving = false;
    
    public void StartMoving() => _isMoving = true;
    
}