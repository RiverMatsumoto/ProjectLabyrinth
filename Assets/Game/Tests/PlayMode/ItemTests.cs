using System.Collections;
using System.Transactions;
using Game.Scripts.Systems.Data.Items;
using UnityEngine.TestTools;
using Zenject;

namespace Game.Tests.PlayMode
{
    public class ItemTests : ZenjectIntegrationTestFixture
    {
        

        [UnityTest]
        public IEnumerator RunTest1()
        {
            PreInstall();
            
            
            
            PostInstall();

            // Add test assertions for expected state
            // Using Container.Resolve or [Inject] fields
            yield break;
        }
    }
}