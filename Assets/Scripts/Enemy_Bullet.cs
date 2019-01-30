using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] private float Bullet_speed = -4f;
    private float TimeTillDeactiveateTimer = 0f;
    [SerializeField] private float DeactivationNumber = 2.5f;
    private Rigidbody2D rigid2D;
    [SerializeField] private float Damage = 20f;

    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        rigid2D.velocity = MathUtility.DegreeToVector2(transform.eulerAngles.z) * Bullet_speed;
    }

    private void Update()
    {
        // Debug.Log("DeactiveTimer = " + TimeTillDeactiveateTimer);

        if (TimeTillDeactiveateTimer >= DeactivationNumber)
        {
            TimeTillDeactiveateTimer = 0f;
            Deactivate();
        }

        TimeTillDeactiveateTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.name == "Wall" || col.gameObject.tag == "Player_Bullet")
        {
            if (col.GetComponentInChildren<HealthBar>() != null)
            {
                col.GetComponentInChildren<HealthBar>().CurrentHealth -= Damage;
            }

            Deactivate();
        }
    }

    private void Active()
    {
        this.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        TimeTillDeactiveateTimer = 0f;
        this.gameObject.SetActive(false);
    }
}