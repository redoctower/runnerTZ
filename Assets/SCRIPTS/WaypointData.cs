using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointData : MonoBehaviour 
{
    [SerializeField] private Transform spawnZone;
    [SerializeField] List<Enemy> Mobs;
    [SerializeField]private List<Enemy> _enemies;
    [SerializeField] private float count;
    public float health;

    private void Start()
    {
        health = count;
        for (int i = 0; i < count; i++)
        {
            GameObject mob = Instantiate(Mobs[Random.Range(0, Mobs.Count - 1)].gameObject, spawnZone.transform); // 1 типа моба т.к на другом не настроен RagDoll
            Vector3 randPos = spawnZone.position;
            randPos.x += Random.Range(-3, 3);
            randPos.z += Random.Range(-3, 3);
            mob.transform.position = randPos;
            mob.transform.eulerAngles = new Vector3(mob.transform.eulerAngles.x, Random.Range(0, 360), mob.transform.eulerAngles.z);
            var enemy = mob.gameObject.GetComponent<Enemy>();
            _enemies.Add(enemy);
        }
        
    }
    public void GenerateMobs()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Restart();
        }
        health = count;
    }
    public void LevelStatus()
    {
        if(health == 0)
        {
            PlayerManager.isShooting = false;
        }
    }
}
