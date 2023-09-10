using System;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Scripts.Systems.Data.Items.ItemCore
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "GameData/ItemDatabase")]
    public class ItemDatabase : SerializedScriptableObject, IInitializable
    {
        public Dictionary<string, ItemObject> itemDatas;

        [Button]
        public void InitializeItemDatabase()
        {
            itemDatas = new Dictionary<string, ItemObject>();
            ItemObject[] itemObjects = Resources.LoadAll<ItemObject>("ScriptableObjects/Items");
            foreach (var itemObject in itemObjects)
            {
                itemDatas.Add(itemObject.name, itemObject);
            }
        }

        public void Initialize()
        {
            InitializeItemDatabase();
        }

        public void UseItem(string item, params object[] objects)
        {
            MethodInfo method = GetType().GetMethod("Use" + item);
            if (method != null) 
                method.Invoke(item, objects);
        }

        private void UsePotion(BattleEntity battleEntity)
        {
            
        }
    }
}