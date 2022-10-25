using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    [CreateAssetMenu(menuName = "GameData/SettingsData", fileName = "SettingsData")]
    public class SettingsData : SerializedScriptableObject, IInitializable, IDisposable
    {
        public string resolution;
        public float volume;

        public void Initialize()
        {
            resolution = PlayerPrefs.GetString("Resolution");
            volume = PlayerPrefs.GetFloat("Volume");
        }

        public void Dispose()
        {
            PlayerPrefs.Save();
        }

        public void SetDefaultSettings()
        {
            PlayerPrefs.SetString("Resolution", "1920x1080");
            PlayerPrefs.SetFloat("Volume", 100);
        }

        public void SetResolution(string resolution)
        {
            bool fullscreen = Screen.fullScreen;
            switch (resolution)
            {
                case "1920x1080":
                {
                    Screen.SetResolution(1920, 1080, fullscreen);
                    break;
                }
                case "1280x720":
                {
                    Screen.SetResolution(1280, 720, fullscreen);
                    break;
                }
                case "800x600":
                {
                    Screen.SetResolution(800, 600, fullscreen);
                    break;
                }
                default:
                    Screen.SetResolution(1920, 1080, fullscreen);
                    break;
            }

            this.resolution = resolution;
        }

        public void SetFullscreen(bool fullscreen)
        {
            Screen.SetResolution(Screen.currentResolution.height,
                Screen.currentResolution.width,
                fullscreen);
        }

        public void SetVolume(float volume)
        {
            this.volume = volume;
        }

        public void SaveSettings()
        {
        }

        [Button]
        public void SetDefaults()
        {
            resolution = "1920x1080";
            volume = 100;
        }
    }
}