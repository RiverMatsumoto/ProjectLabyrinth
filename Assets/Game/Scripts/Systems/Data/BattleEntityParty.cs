using System;
using System.Collections.Generic;

namespace Game.Scripts.Systems.Data
{
    [Serializable]
    public class BattleEntityParty
    {
        public enum Row { Front = 0, Back = 1 }
        public enum PartyType { Player, Enemy }
        public PartyType partyType { get; }
        private BattleEntity[] _frontRow;
        private BattleEntity[] _backRow;

        public BattleEntityParty(BattleEntity[] frontRow, BattleEntity[] backRow, PartyType partyType)
        {
            if (partyType == PartyType.Player && (frontRow.Length < 1 || frontRow.Length > 3 || backRow.Length > 3))
            {
                UnityEngine.Debug.LogError("Party front row must have at least 1 entity and parties may have no more than 3 per row");
            }
            this.partyType = partyType;
            _frontRow = frontRow;
            _backRow = backRow;
        }

        public BattleEntity[] GetAllEntities()
        {
            List<BattleEntity> allBattleEntities = new List<BattleEntity>();
            foreach (var entity in _frontRow)
                allBattleEntities.Add(entity);
            foreach (var entity in _backRow)
                allBattleEntities.Add(entity);
            return allBattleEntities.ToArray();
        }

        public BattleEntity GetEntity(Row row, int index)
        {
            switch (row)
            {
                case Row.Front:
                    if (index >= 0 && _frontRow.Length > index)
                    {
                        return _frontRow[index];
                    }
                    throw new IndexOutOfRangeException();
                case Row.Back:
                    if (index >= 0 && _backRow.Length > index)
                    {
                        return _backRow[index];
                    }
                    throw new IndexOutOfRangeException();
                default:
                    return null;
            }
        }
    }
}