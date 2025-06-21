using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpringTimer : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] UnityEvent onTimeOver;

    private float currentTime;
    private bool tick;
    private void Start()
    {
        currentTime = maxTime;
        tick = true;
    }

    private void Update()
    {
        if(tick)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Reset();
                onTimeOver.Invoke();
            }
        }
    }
    private void Reset()
    {
        currentTime = 0;
        tick = false;
    }

    public void Restart()
    {
        tick = true;
        currentTime = maxTime;
    }

}
