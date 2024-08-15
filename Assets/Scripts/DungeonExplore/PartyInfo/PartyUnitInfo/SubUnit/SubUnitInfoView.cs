using System;
using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.Esential.Party;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio.AshEdge.DungeonExplore.PartyInfo
{
    public class SubUnitInfoView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _potraitIcon;
        [SerializeField] private Image _healthBarFill;
        [SerializeField] private Button _clickButton;

        public UnityEvent OnClickEvent { get; private set; } = new();

        private void Awake()
        {
            _clickButton.onClick.AddListener(OnClickEvent.Invoke);
        }
        public void SetVisual(PartyUnitData unitData)
        {
            _potraitIcon.sprite = unitData.GeneralInfo.UnityPotraitIcon;
        }

        public void SetHealth(PartyUnitData unitData)
        {
            _healthBarFill.fillAmount = (float)unitData.ModifiedStatus.Health / (float)unitData.BaseAttribute.Health;
        }

        internal void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive ? true : false;
            _canvasGroup.blocksRaycasts = isActive ? true : false;
        }
    }
}
