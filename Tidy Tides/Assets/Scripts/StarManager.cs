using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public int score;
    public GameObject[] stars;

    private void Start()
    {
        score = ScoreTracker.instance.score;

       if(score <= 0)
        {
            print("No score, try harder!");
        }

        if (score >= 5)
        {
            print("1 star");
        }

        if (score >= 10)
        {
            print("2 stars");
        }

        if (score >= 20)
        {
            print("3 stars");
        }
    }
}
