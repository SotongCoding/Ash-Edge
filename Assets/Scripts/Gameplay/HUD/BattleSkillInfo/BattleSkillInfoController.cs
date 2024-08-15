using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Skill;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.UI.SkillInfo
{
    public interface IBattleSkillInfoController
    {
        void SetSkillInfo(SkillGeneralInfo skillInfo, Sprite skillIcon);
    }
    
    [RegisterAs(typeof(IBattleSkillInfoController))]
    public class BattleSkillInfoController : IBattleSkillInfoController
    {
        private readonly BattleSkillInfoView _view;

        public BattleSkillInfoController(BattleSkillInfoView view)
        {
            _view = view;
        }

        public void SetSkillInfo(SkillGeneralInfo skillInfo, Sprite skillIcon)
        {
            _view.SetIcon(skillIcon);
            _view.SetInfo(skillInfo.SkillName, skillInfo.SkillDescription);
        }
    }
}
