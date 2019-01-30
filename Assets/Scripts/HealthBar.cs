using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    [SerializeField] private Image PlayerHealthBar;
    [SerializeField] private Text RatioText;

    //[SerializeField] private GameObject WinTracker_canvas;
    [SerializeField] private GameObject Wall_or_Enemy; //het object dat de healthbar/health aan gekoppeld is

    [SerializeField] private GameObject Penguin_With_Cannon;
    [SerializeField] private GameObject Hit_Particle;
    [SerializeField] private bool HasCannon = false;
    [SerializeField] private float Score_Points = 1f;

    public float CurrentHealth = 100f; //hitpoint
    public float MaxHealth = 100; //maxhitpoint

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
        //Debug.Log("Player Health = " + CurrentPlayerHealth);

        UpdateHealthBar();

        if (CurrentHealth <= 0)
        {
            Debug.Log(transform.root.gameObject.tag);
            if (transform.root.gameObject.tag == "Enemy") //niet vergeten dit betekend dat de healthbar de Enemy tag moet hebben!
            {
                Win_Tracker.instance.Win_Score += Score_Points;
                Instantiate(Hit_Particle, transform.position, Quaternion.identity);
                //Debug.Log(Win_Tracker.instance.MaxWinScore);
            }

            CurrentHealth = 0;
            UpdateHealthBar();
            Destroy(Wall_or_Enemy); //of misschien later doe ik dat de player naar een scene waar game over staat wordt geteleport of zo?
            if (HasCannon == true)
            {
                Destroy(Penguin_With_Cannon);
            }
        }
    }

    private void UpdateHealthBar() //dit checkt hoeveel health de speler echt heeft
    {
        float ratio = CurrentHealth / MaxHealth;

        //PlayerHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        PlayerHealthBar.fillAmount = CurrentHealth / MaxHealth;
        RatioText.text = (ratio * 100).ToString("0");
    }
}