using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socore : MonoBehaviour
{
    public float score;

    private bool isTimerWorking;

    private void Update()
    {
        if (isTimerWorking)
            score += Time.deltaTime;
    }

    public void StartTimer()
    {
        isTimerWorking = true;
    }

    public void StopTimer()
    {
        isTimerWorking = false;
    }
}
