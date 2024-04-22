using UnityEngine;

public class ThrowingPopcornPresenter{
    private ThrowingPopcornsManager m_Manager;
    private NoiseView m_View;

    public ThrowingPopcornPresenter(ThrowingPopcornsManager manager, NoiseView view){
        m_Manager = manager;
        m_View = view;
        m_View.SetMaxNoiseSlider(m_Manager.Noise);
    }

    public void UpdateNoise(){
        m_View.SetNoiseSlider(m_Manager.Noise);
    }
}
