using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera main;

    [SerializeField] private float CameraMovementSpeed = 30;

    [SerializeField] private float BoundaryLength_Left = -10;
    [SerializeField] private float BoundaryLength_Right = 10;

    private void Update()
    {
        if (Input.mousePosition.x <= 50 || Input.GetKey(KeyCode.Q))
        {
            main.transform.position = new Vector3(main.transform.position.x - CameraMovementSpeed * Time.deltaTime, main.transform.position.y, main.transform.position.z);

            if (main.transform.position.x < BoundaryLength_Left)
            {
                main.transform.position = new Vector3(BoundaryLength_Left, main.transform.position.y, main.transform.position.z);
            }
        }
        if (Input.mousePosition.x >= Screen.width - 50 || Input.GetKey(KeyCode.E))
        {
            main.transform.position = new Vector3(main.transform.position.x + CameraMovementSpeed * Time.deltaTime, main.transform.position.y, main.transform.position.z);

            if (main.transform.position.x > BoundaryLength_Right)
            {
                main.transform.position = new Vector3(BoundaryLength_Right, main.transform.position.y, main.transform.position.z);
            }
        }
    }
}