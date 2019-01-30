using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject StartGameButton;
    [SerializeField] private GameObject Melee_Enemy;
    [SerializeField] private GameObject Range_Enemy;
    [SerializeField] private GameObject Enemy_Spawn_Point;

    private float CanSpawn_Timer = 0f;
    private bool CanSpawn = true;
    private float HasSpawned = 0f;
    [SerializeField] private float SpawnRate = 1.5f;

    private void Update()
    {
        if (CanSpawn == true && StartGameButton.activeSelf == false)
        {
            Instantiate(Melee_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
            CanSpawn = false;
            //spawn enemy's en begin de game
            if (HasSpawned >= 10)
            {
                Instantiate(Melee_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
                Instantiate(Range_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
                Instantiate(Melee_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
                Instantiate(Melee_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
                Instantiate(Range_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
                Instantiate(Melee_Enemy, Enemy_Spawn_Point.transform.position, Quaternion.identity);
                HasSpawned = 0f;
            }
        }

        if (CanSpawn == false)
        {
            CanSpawn_Timer += Time.deltaTime;
        }

        if (CanSpawn_Timer >= SpawnRate)
        {
            CanSpawn = true;
            CanSpawn_Timer = 0f;
            HasSpawned += 1f;
        }
    }
}