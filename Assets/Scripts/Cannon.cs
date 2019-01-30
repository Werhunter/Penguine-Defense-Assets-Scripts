using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_Prefab;
    [SerializeField] private GameObject Bullet_Spawn_Location;
    [SerializeField] private float TurnSpeed = 1;
    [SerializeField] private ParticleSystem Cannon_Blast;

    private float GunCanFire_Timer = 0f;
    private bool GunCanFire = true;
    [SerializeField] private float FireRate = 0.5f;
    private bool CheatIsActive = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton(0))
        {
            if (GunCanFire == true)
            {
                Cannon_Blast.Clear();
                Cannon_Blast.Play();
                GameObject player_bullet = Instantiate(Bullet_Prefab, Bullet_Spawn_Location.transform.position, transform.rotation);
                GunCanFire = false;
            }
        }

        if (GunCanFire == false)
        {
            GunCanFire_Timer += Time.deltaTime;
        }

        if (GunCanFire_Timer >= FireRate)
        {
            GunCanFire = true;
            GunCanFire_Timer = 0f;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * TurnSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * TurnSpeed);
        }
    }
}