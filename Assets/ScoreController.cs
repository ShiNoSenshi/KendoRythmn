using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    private const float PERFECT = 0.5f;
    private const float GOOD = 1f;
    private int score;
    public Text uiScore;

    // Update is called once per frame
    void Update () {
        uiScore.text = "Score: " + score;
	}

    internal void WrongAttack()
    {
        score -= 500;
    }

    internal void RightAttack(Vector3 distance)
    {
        float distanceX = Math.Abs(distance.x);
        if (distanceX < PERFECT)
            score += 1000;
        else if (distanceX < GOOD)
            score += 500;
        else
            score += 100;
    }
}
