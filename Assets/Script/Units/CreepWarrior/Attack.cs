using UnityEngine;



public class Attack : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private float _damage;
    private float _atackSpeed;
    private float _distanseAtak;

    private Closest _closest;
    private Move _move;

    private IUnit _unit;

    private AttackAmimationController _attackAmimationController;

    private bool _unitTargetIsDead;

    private void OnEnable()
    {
        _closest = GetComponent<Closest>();
        _closest.FindAttakUnit += ChasePlayer;
        _attackAmimationController = new AttackAmimationController(_animator);
    }


    private void ChasePlayer(Transform gameObject)
    {
        var unitTarget = gameObject;

        if ((Vector3.Distance(transform.position, unitTarget.transform.position) <= _distanseAtak) && (gameObject != null))
        {
            _move.StopMoving();
            _attackAmimationController.IsAttack(true);
            if (!IsInvoking(nameof(AttackEnemy)))
            {
                _unit = unitTarget.GetComponent<IUnit>();
                gameObject.transform.LookAt(unitTarget.transform);
                InvokeRepeating(nameof(AttackEnemy), .5f, _atackSpeed);
            }
        }
        else
        {
            _attackAmimationController.IsAttack(false);
            _move.StartMoving();
            _unit = null;   
            StopAttack();
        }
    }

    private void AttackEnemy()
    {
        if (!_unitTargetIsDead)
        {
            _unit.TakeDamage(_damage, out _unitTargetIsDead);
        }
        else
        {
            StopAttack();
        }

    }
    public void InitializedAttack(Character character, Move move)
    {
        _damage = character.CurrentAtributes.damage;
        _distanseAtak = character.CurrentAtributes.distanseAtak;
        _atackSpeed = character.CurrentAtributes.atackSpeed;
        _move = move;
    }
    public void BuffDamage(Character character)
    {
        _damage = character.CurrentAtributes.damage;
    }

    private void StopAttack()
    {
        CancelInvoke(nameof(AttackEnemy));
        _unitTargetIsDead = false;
    }

    private void OnDisable()
    {
        _closest.FindAttakUnit -= ChasePlayer;
        StopAttack();
    }
}