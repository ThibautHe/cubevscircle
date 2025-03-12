using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float duration = 10f; // Total time in seconds
    public bool loop = false; // Whether the timer should restart after reaching zero
    public Image uiFillImage; // Reference to UI Image fill

    private float remainingTime;

    public event Action OnTimerEnd; // Event triggered when timer reaches 0

    void Start()
    {
        StartTimer(duration);
    }

    public void StartTimer(float time)
    {
        remainingTime = time;
        StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    public void ResetTimer()
    {
        StopTimer();
        StartTimer(duration);
    }

    private IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateUI();
            yield return null;
        }

        if (remainingTime <= 0)
        {
            OnTimerEnd?.Invoke();

            if (loop)
            {
                StartTimer(duration);
            }
        }
    }

    private void UpdateUI()
    {
        if (uiFillImage != null)
        {
            uiFillImage.fillAmount = Mathf.Clamp01(remainingTime / duration);
        }
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(0, remainingTime);
    }
}
