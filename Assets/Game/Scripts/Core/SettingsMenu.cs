using Michsky.MUIP;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Core
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private CustomDropdown _resolutionDropdown;
        [SerializeField] private Slider _volumeSlider;
        // Consider having a list of actions where it calls every "Set<Setting>" function
        
        #region Settings Properties

        public string Resolution { get; set; }
        public FullScreenMode FullScreenMode { get; set; }
        public float Volume { get; set; }

        #endregion

        private void Start()
        {
            LoadSettings();
            ApplySettings();
        }

        
        public void LoadSettings()
        {
            Resolution = PlayerPrefs.GetString("Resolution");
            FullScreenMode = Screen.fullScreenMode;
            Volume = PlayerPrefs.GetFloat("Volume");
        }
        
        public void SaveSettings()
        {
            PlayerPrefs.SetString("Resolution", Resolution);
            PlayerPrefs.SetFloat("Volume", Volume);
        }

        public void ApplySettings()
        {
            // go through set every setting and set it
            SetResolution();
            SetVolume();
            
            SaveSettings();
        }


        #region Applying Settings Functions
        
        public void SetResolution()
        {
            switch (Resolution)
            {
                case "1920x1080":
                    Screen.SetResolution(1920, 1080, FullScreenMode);
                    break;
                case "1280x720":
                    Screen.SetResolution(1280, 720, FullScreenMode);
                    break;
                case "960x540":
                    Screen.SetResolution(960, 540, FullScreenMode);
                    break;
                default:
                    Screen.SetResolution(1920, 1080, FullScreenMode);
                    break;
            }
        }

        public void SetVolume()
        {
            
        }

        #endregion

    }
}