using System;
using System.Collections.Generic;
using Game.Scripts.Systems.Data.Items;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.Data.Inventory
{
    public class Inventory : IInitializable
    {
        public List<string> items;
        
        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
