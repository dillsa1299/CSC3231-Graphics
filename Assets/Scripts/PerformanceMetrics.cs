using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;

public class PerformanceMetrics : MonoBehaviour
{
    public Text fpsDisplay;
    public Text memoryDisplay;
    float avg = 0;
    float fps;

    void Update()
    {
        // FPS code adapted from: http://answers.unity.com/answers/1271014/view.html
        avg += ((Time.unscaledDeltaTime/Time.timeScale) - avg) * 0.03f;
        float fps = (1F/avg);
        fpsDisplay.text = "Average FPS: " + (int)(fps);
        memoryDisplay.text = "Memory Usage: " + (int)((UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong())/1024) + "MB";
    }
}
