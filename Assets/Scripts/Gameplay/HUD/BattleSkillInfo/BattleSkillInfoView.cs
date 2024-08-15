using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.AshEdge.Gameplay.UI.SkillInfo
{

    public class BattleSkillInfoView : MonoBehaviour
    {
        [SerializeField]
        private Image _skillIcon;

        [SerializeField]
        private TMP_Text _skillName;
        [SerializeField]
        private TMP_Text _skillDescription;

        public void SetIcon(Sprite skillIcon)
        {
            _skillIcon.sprite = skillIcon;
        }

        public void SetInfo(string skillName, string skillDescription)
        {
            _skillName.text = skillName;
            _skillDescription.text = skillDescription;
        }
    }
}
