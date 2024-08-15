using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Esential.Skill
{
    [CreateAssetMenu(fileName = "SKL-000", menuName = "Data/SkillData", order = 0)]
    public class SkillData : ScriptableObject 
    {
        public string SkillId;
        public SkillGeneralInfo GeneralInfo;    
    }
}
