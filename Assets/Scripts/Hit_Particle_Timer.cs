using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Particle_Timer : MonoBehaviour
{
    private float Deativation_Buttons_Timer = 0f;
    private bool Activate_Deativation_Buttons_Timer = false;

    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            Activate_Deativation_Buttons_Timer = true;
        }

        if (Activate_Deativation_Buttons_Timer == true)
        {
            Deativation_Buttons_Timer += Time.deltaTime;
        }

        if (Deativation_Buttons_Timer >= 2f)
        {
            this.gameObject.SetActive(false);
            Deativation_Buttons_Timer = 0f;
        }
    }
}