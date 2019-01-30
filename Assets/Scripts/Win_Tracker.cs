using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Tracker : MonoBehaviour
{
    public static Win_Tracker instance { get; private set; }

    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject EnemySpawner;

    [SerializeField] private GameObject LostScreen;
    [SerializeField] private GameObject RetryButton;
    [SerializeField] private GameObject WinScreen;

    [SerializeField] private GameObject Background;
    [SerializeField] private Image ProgressBar;

    public float Win_Score = 1;
    public float MaxWinScore = 100; //maxhitpoint

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Win_Score = 0;
        UpdateScoreBar();
    }

    private void Update()
    {
        //print("winscore = " + Win_Score);

        if (Input.GetKey(KeyCode.J))
        {
            Win_Score += 1;
        }

        if (Wall != null && Win_Score >= 100f)
        {
            Win_Score = 100f;
            EnemySpawner.SetActive(false);
            WinScreen.SetActive(true);
        }

        if (Wall == null)
        {
            EnemySpawner.SetActive(false);
            LostScreen.SetActive(true);
        }

        UpdateScoreBar();
    }

    private void UpdateScoreBar() //dit checkt hoeveel health de speler echt heeft
    {
        // float ratio = Win_Score / MaxWinScore;

        //PlayerHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        ProgressBar.fillAmount = Win_Score / 100;
    }
}