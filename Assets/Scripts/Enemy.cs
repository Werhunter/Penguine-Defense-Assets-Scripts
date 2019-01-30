using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemystate
{
    walking = 0,
    attacking = 1
};

public class Enemy : MonoBehaviour
{
    public Enemystate state;
    [SerializeField] private GameObject Enemy_Bullet;
    [SerializeField] private GameObject Enemy_Bullet_SpawnPosition;
    [SerializeField] private float MovementSpeed = 1;
    [SerializeField] private float Damage = 1;
    [SerializeField] private bool IsRangedEnemy = false;
    [SerializeField] private float attackDistance;
    private GameObject wall;

    private float EnemyCanFire_Timer;

    //private bool EnemyCanFire = true;
    [SerializeField] private float ReloadTime = 1.5f;

    private void Start()
    {
        wall = GameObject.Find("Wall");
        state = Enemystate.walking;
    }

    private void Update()
    {
        if (wall != null)
        {
            if (transform.position.x - wall.transform.position.x < attackDistance)
            {
                state = Enemystate.attacking;
            }
            else
            {
                state = Enemystate.walking;
            }
        }

        if (state == Enemystate.walking)
        {
            //play walking animation
            transform.Translate(Vector2.left * Time.deltaTime);
        }

        if (state == Enemystate.attacking)
        {
            if (EnemyCanFire_Timer >= ReloadTime)
            {
                if (IsRangedEnemy)
                {
                    GetComponent<Animator>().Play("Attacking", 0, 0f);
                    Instantiate<GameObject>(Enemy_Bullet, Enemy_Bullet_SpawnPosition.transform.position, Quaternion.identity);
                    EnemyCanFire_Timer -= ReloadTime;
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("Attack");
                }
            }
            EnemyCanFire_Timer += Time.deltaTime;
            //play attack animation
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        state = Enemystate.attacking;
        if (col.gameObject.tag == "Wall" && state == Enemystate.attacking && IsRangedEnemy == false)
        {
            col.gameObject.GetComponentInChildren<HealthBar>().CurrentHealth -= Damage;
        }

        //Debug.Log((col.gameObject.tag == "InRange") + " " + (state == Enemystate.attacking) + " " + (IsRangedEnemy == true));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        state = Enemystate.walking;
    }
}