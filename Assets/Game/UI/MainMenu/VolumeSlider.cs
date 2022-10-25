using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private SettingsData _settingsData;
    [SerializeField] private Slider _slider;

    public void SetVolume()
    {
        _settingsData.SetVolume(_slider.value);
    }
}
