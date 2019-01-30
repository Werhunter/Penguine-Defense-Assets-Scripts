using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Controlls : MonoBehaviour
{
    [SerializeField] private GameObject ControllButtons;

    public void OpenControlls_OnButtonClick()
    {
        ControllButtons.SetActive(true);
    }
}