using SotongStudio.AshEdge.Esential.Party;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.AshEdge
{
    public class MainUnitInfoView : MonoBehaviour
    {
        [SerializeField] private Image _potraitIcon;
        [SerializeField] private TMP_Text _characterNameText;

        [SerializeField] private Image _healthBarFill;
        [SerializeField] private TMP_Text _healthText;

        public void SetVisual(PartyUnitData unitData)
        {
            _potraitIcon.sprite = unitData.GeneralInfo.UnityPotraitIcon;
            _characterNameText.text = unitData.GeneralInfo.Name;
        }

        public void SetHealth(PartyUnitData unitData)
        {
            _healthBarFill.fillAmount = (float)unitData.ModifiedStatus.Health / (float)unitData.BaseAttribute.Health;
            _healthText.text = string.Format("{0} / {1}", unitData.ModifiedStatus.Health, unitData.BaseAttribute.Health.ToString());
        }
    }
}
