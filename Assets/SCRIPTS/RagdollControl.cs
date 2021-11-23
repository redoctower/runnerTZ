using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public Rigidbody[] Rigidbodies;

    private void Awake()
    {
        Ragdoll(true);
    }

    public void Ragdoll(bool state)
    {
        foreach (var rigidbody in Rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
    }
}
