using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameObject ControllButtons;

    public void StartGame_OnButtonClick()
    {
        ControllButtons.SetActive(true);
        this.gameObject.SetActive(false);
    }
}