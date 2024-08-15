using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.AshEdge.Gameplay.UI.EnemyStatus
{
    public class EnemyStatusInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bossNameText;
        [SerializeField] private Image _healthBar;

        public void Setup(string name, float healthPercentage)
        {
            _bossNameText.text = name;
            _healthBar.fillAmount = healthPercentage;
        }
        public void UpdateHealthBar(float healthPercentage)
        {
            _healthBar.fillAmount = healthPercentage;
        }
    }
}
