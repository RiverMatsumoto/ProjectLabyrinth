using Game.Scripts.Systems.Data;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests.EditMode
{
    [TestFixture]
    public class BattleEntityTests
    {
        private BattleEntity _battleEntity;

        [SetUp]
        public void SetUp()
        {
            BattleEntityData data = ScriptableObject.CreateInstance<BattleEntityData>();
            data.name = "Johnny";
            data.strength = 10;
            data.intelligence = 11;
            data.vitality = 12;
            data.wisdom = 13;
            data.luck = 14;
            _battleEntity = new BattleEntity(data);
        }
        
        [Test]
        public void TestStats()
        {
            Assert.AreEqual("Johnny", _battleEntity.name);
            Assert.AreEqual(10, _battleEntity.stats.strength);
            Assert.AreEqual(11, _battleEntity.stats.intelligence);
            Assert.AreEqual(12, _battleEntity.stats.vitality);
            Assert.AreEqual(13, _battleEntity.stats.wisdom);
            Assert.AreEqual(14, _battleEntity.stats.luck);
        }
    }
}
