using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private WaypointData _waypointData;
    private RagdollControl _ragdollControl;
    [SerializeField] private bool alive = true;
    private Vector3 startpos;
    private Animator _animator;
    private void Awake()
    {
        _waypointData = gameObject.GetComponentInParent(typeof(WaypointData)) as WaypointData;
        alive = true;
        _ragdollControl = GetComponent<RagdollControl>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        startpos = transform.position;
    }
    public void Die()
    {
        if (!alive) return;
        alive = false;
        _waypointData.health--;
        _waypointData.LevelStatus();
        _ragdollControl.Ragdoll(false);
        _animator.enabled = false;
    }

    public void Restart()
    {
       alive = true;
       transform.position = startpos;
       _ragdollControl.Ragdoll(true);
       _animator.enabled = true;
    }
}
