using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SotongStudio.AshEdge.Gameplay.Unit;

namespace SotongStudio.AshEdge.Gameplay.UI.CharacterStatus
{
    public class CharacterStatusInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _characterName;
        [SerializeField] private TMP_Text _healthRemainingText;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Image _playerIcon;

        public void Setup(string name, Sprite playerIcon, int baseHealth, int currentHealth)
        {
            _characterName.text = name;
            _playerIcon.sprite = playerIcon;
            UpdateHealthBar(baseHealth, currentHealth);
        }
        public void UpdateHealthBar(int baseHealth, int currentHealth)
        {
            _healthBar.fillAmount = (float)((float)currentHealth / baseHealth);
            _healthRemainingText.text = string.Format("{0} / {1}", currentHealth, baseHealth);
        }

        public void Setup(CharacterUnit character)
        {
            _playerIcon.sprite = character.VisualData.CharcterIcon;
            UpdateHealthBar(character.BaseAttribute.Health, character.Attribute.Health);
        }
    }
}
