using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public Transform movePosition;
    private NavMeshAgent navMeshAgent;
    public static bool isRuning;
    public static bool isShooting;
    [SerializeField] private AnimationManager animationManager;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        navMeshAgent.destination = movePosition.position;
    }
    public void SetAnimation()
    {
        animationManager.SetStatus();
    }
}
