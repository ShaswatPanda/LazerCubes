using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float runEvery;
    public bool runOnAwake = false;
    public bool loop = true;
    public UnityEvent onTimerEnd;

    private void OnEnable()
    {
        if(runOnAwake)
        {
            Invoke("execute", 0);
        }

        if(loop)
        {
            InvokeRepeating("execute", runEvery, runEvery);
        }
        else
        {
            Invoke("execute", runEvery);
        }

    }
    public void execute()
    {
        onTimerEnd.Invoke();
    }
}
