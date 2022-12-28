using System;
using System.Collections.Generic;
using Game.Scripts.Systems.SkillCommands;
using Game.Scripts.Systems.SkillCommands.Factories;
using GitHub.Unity;
using Michsky.MUIP;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    [CreateAssetMenu(fileName = "NewStoryEventData", menuName = "GameData/Dialogue/StoryEventData")]
    public class StoryEventData : SerializedScriptableObject
    {
        [BoxGroup("Dialogue")]
        public DialogueNode start;

        public SkillCommandProvider skillCommandProvider;




#if UNITY_EDITOR
        
        [Button]
        public void CreateDecisionNode()
        {
            // create event nodes for each option
        }
        [TabGroup("DecisionNode")] public string Option1;
        [TabGroup("DecisionNode")] public string Option2;
        [TabGroup("DecisionNode")] public string Option3;
        [TabGroup("DecisionNode")] public string Option4;

        public void OnGUI()
        {
            UnityEngine.Debug.Log("Hello");
        }
#endif
    }
}