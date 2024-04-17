using System;
using System.Collections;
using UnityEngine;

public class StartCountdown : MonoBehaviour{
    [SerializeField] int m_TimeLeft = 3;
    public int TimeLeft => m_TimeLeft;
    public float timeBtwSeconds = 1.5f;
    public event Action onCountdownFinished;

    private CountdownPresenter m_CountdownPresenter;

    public void Init(){
        m_CountdownPresenter = new CountdownPresenter(this, FindObjectOfType<CountdownView>());
        m_TimeLeft = 3;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown(){
        while(m_TimeLeft > 0){
            yield return new WaitForSeconds(timeBtwSeconds);
            m_TimeLeft--;
            m_CountdownPresenter.UpdateCountdown();
        }

        onCountdownFinished?.Invoke();
    }
}
