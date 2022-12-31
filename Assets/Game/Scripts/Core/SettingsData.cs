using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    [CreateAssetMenu(menuName = "GameData/SettingsData", fileName = "SettingsData")]
    public class SettingsData : SerializedScriptableObject
    {
        public BoolReactiveProperty showFps;
        public enum TextScrollSpeed { SLOW, MEDIUM, FAST, INSTANT }

        public TextScrollSpeed textScrollSpeed;
        
    }
}