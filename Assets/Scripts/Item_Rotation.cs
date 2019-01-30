using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Rotation : MonoBehaviour
{
    [SerializeField] private float RotateSpeed_X;
    [SerializeField] private float RotateSpeed_Y;
    [SerializeField] private float RotateSpeed_Z;

    [SerializeField] private bool IsSneeuwvlok;

    private void Start()
    {
        if (IsSneeuwvlok == true)
        {
            RotateSpeed_X = Random.Range(25, 50);
            RotateSpeed_Y = Random.Range(25, 50);
            RotateSpeed_Z = Random.Range(25, 50);
        }
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.Rotate(RotateSpeed_X * Time.fixedDeltaTime, RotateSpeed_Y * Time.fixedDeltaTime, RotateSpeed_Z * Time.fixedDeltaTime, 0);
    }
}