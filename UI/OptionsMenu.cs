using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider ambientVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    private void OnEnable()
    {
        var audioManager = AudioManager.instance;
        masterVolumeSlider.value = audioManager.MasterVolume;
        ambientVolumeSlider.value = audioManager.AmbientVolume;
        musicVolumeSlider.value = audioManager.MusicVolume;

        Menu.MenuStack.Push(gameObject);
    }

    private void OnDisable()
    {
        Menu.MenuStack.Pop();
    }
}
