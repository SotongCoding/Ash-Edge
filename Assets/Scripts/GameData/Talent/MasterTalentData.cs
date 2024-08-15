using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Talent
{
    public abstract class MasterTalentData : ScriptableObject
    {
        public delegate void TalentLogic(BaseBattleUnit executor, IBattleHandledUnits handledUnits);

        public string TalentId;
        public TalentGeneralInfo GeneralInfo;

        public TalentLogic Logic => LogicProcess;
        protected abstract void LogicProcess(BaseBattleUnit executor, IBattleHandledUnits handledUnits);
    }

    [System.Serializable]
    public struct TalentGeneralInfo
    {
        public string TalentName;
        public string TalentDescription;
    }
}
