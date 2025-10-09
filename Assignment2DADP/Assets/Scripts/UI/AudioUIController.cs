using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    public Slider audioSlider;

    public void AudioVolume()
    {
        AudioManager.instance.AudioVolume(audioSlider.value);
    }
}
