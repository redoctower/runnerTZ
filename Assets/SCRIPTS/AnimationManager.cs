using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetStatus()
    {
        _animator.SetBool("runing", PlayerManager.isRuning);
        _animator.SetBool("shooting", PlayerManager.isShooting);
    }
}
