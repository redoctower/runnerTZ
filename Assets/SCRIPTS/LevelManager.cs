using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<WaypointData> waypoints;
    [SerializeField] private PlayerManager player;
    private int curpoint;
    public Coroutine checkRoutine;

    private void Awake()
    {
        SpawnPlayer();
        PlayerManager.isRuning = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !PlayerManager.isShooting)
        {
            MoveNext();
        }
    }
    
    public void Restart()
    {
        curpoint = 0;
        MoveNext();
        foreach (var point in waypoints)
        {
            point.GenerateMobs();
        }
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        player.transform.position = waypoints[0].transform.position;
    }
    public void MoveNext()
    {
        if (PlayerManager.isRuning || PlayerManager.isShooting) return;
        curpoint++;
        if(checkRoutine != null)
            StopCoroutine(checkRoutine);
        if (curpoint < waypoints.Count)
            transform.position = waypoints[curpoint].transform.position;
        else
        {
            Restart();
        }
        checkRoutine = StartCoroutine(CheckDistance());
    }
    private IEnumerator CheckDistance()
    {
        PlayerManager.isRuning = true;
        PlayerManager.isShooting = false;
        player.SetAnimation();
        while (Vector3.Distance(player.movePosition.position, player.transform.position) > 1f) 
        {
            yield return null;
        }
        checkRoutine = null;
        PlayerManager.isRuning = false;
        PlayerManager.isShooting = true;
        player.SetAnimation();
    }
}
