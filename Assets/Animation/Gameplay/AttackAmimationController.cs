using UnityEngine;

public class AttackAmimationController
{
    private Animator _animator;
    public AttackAmimationController(Animator animator)
    {
        this._animator = animator;
    }

    public void IsAttack(bool isAttack)
    {
        _animator.SetBool("triger_attack", isAttack);
    }
}

