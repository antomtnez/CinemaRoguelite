using System;
using System.Collections;
using UnityEngine;

public class StartCountdown : MonoBehaviour{
    [SerializeField] int m_TimeLeft = 3;
    public float timeBtwSeconds = 1.5f;
    public event Action onCountdownFinished;

    public void Init(){
        m_TimeLeft = 3;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown(){
        while(m_TimeLeft > 0){
            yield return new WaitForSeconds(timeBtwSeconds);
            m_TimeLeft--;
        }

        onCountdownFinished?.Invoke();
    }
}
