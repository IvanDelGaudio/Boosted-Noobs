using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//yagni//dry

public class MyTime
{
    float startTime;
    int startFrameCount;

    bool isRealTime;
    float currentTime => isRealTime ? Time.realtimeSinceStartup : Time.time; //=> --> get
    public MyTime(bool isRealTime = false)
    {
        this.isRealTime = isRealTime;
        Restart();
    }
    public void Restart()
    {
        startTime = currentTime;
        startFrameCount = Time.frameCount;

    }
    public float ElapsedSeconds()
    {
        return Time.time - startTime;
    }
    public int ElapsedFrames()
    {
        return Time.frameCount - startFrameCount;
    }

    public bool Every(float seconds)
    {
        if(ElapsedSeconds() >= seconds)
        {
            return true;
        }
        return false;
    }
    public bool Every(float seconds, UnityAction<float> action)
    {
        if (ElapsedSeconds() >= seconds)
        {
            action(ElapsedSeconds());
            Restart();
        }
        return false;
    }
    public float Ratio(float amount)
    {
        return Mathf.Clamp01(ElapsedSeconds()/amount);
    }
}
