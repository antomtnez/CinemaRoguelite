public class CountdownPresenter{
    private StartCountdown m_Countdown;
    private CountdownView m_CountdownView;

    public CountdownPresenter(StartCountdown startCountdown, CountdownView countdownView) {
        m_Countdown = startCountdown;
        m_CountdownView = countdownView;
    }

    public void UpdateCountdown(){
        m_CountdownView.SetCountdownText(m_Countdown.TimeLeft.ToString());
    }
}