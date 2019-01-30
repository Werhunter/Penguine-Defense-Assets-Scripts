using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker instance { get; private set; }

    public int score;

    public void Awake()
    {
        instance = this;
    }
}