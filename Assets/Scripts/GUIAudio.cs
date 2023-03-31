using UnityEngine;

public class GUIAudio : MonoBehaviour
{
    public float volume = 0.5f;
    public float minVolume;
    public float maxVolume = 1.0f;

    private AudioSource audio;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        audio = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        audio.volume = volume;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(150, 0, 100, 30), "Volume");
        volume = GUI.HorizontalSlider(new Rect(150,30,100,30), volume, minVolume, maxVolume);
    }
}
