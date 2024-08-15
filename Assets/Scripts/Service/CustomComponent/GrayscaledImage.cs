using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.Utils.UI
{
    [RequireComponent(typeof(Image))]
    public class GrayscaledImage : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private Image _baseComponent;
        [ReadOnly]
        [SerializeField]
        private Material _baseMaterial;
        private bool _grayScaleEnable = false;

        public void EnableGrayscale(bool enable)
        {
            _baseMaterial.SetFloat("_EffectAmount", enable ? 1 : 0);
            _grayScaleEnable = enable;
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (_baseComponent == null)
            {
                _baseComponent = this.GetComponent<Image>();
                _baseMaterial = _baseComponent.material;
            }
#endif
        }
    }
}
