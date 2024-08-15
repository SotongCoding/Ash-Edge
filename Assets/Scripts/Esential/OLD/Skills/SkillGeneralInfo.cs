using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Esential.Skill
{
    [System.Serializable]
    public struct SkillGeneralInfo 
    {
       public string SkillName;
       [TextArea]
       public string SkillDescription;
       public Sprite SkillIcon;
    }
}
