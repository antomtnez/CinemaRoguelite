using System;
using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour{
    [SerializeField] int m_TimeLeft = 3;
    public int TimeLeft => m_TimeLeft;
    public float timeBtwSeconds = 1.5f;

    public event Action OnCountdownDecreased;
    public event Action OnCountdownFinished;

    public void Init(){
        m_TimeLeft = 3;
        StartCoroutine(DelayedCountdown());
    }

    IEnumerator DelayedCountdown(){
        while(m_TimeLeft > 0){
            yield return new WaitForSeconds(timeBtwSeconds);
            m_TimeLeft--;
            OnCountdownDecreased?.Invoke();
        }

        OnCountdownFinished?.Invoke();
    }
}
