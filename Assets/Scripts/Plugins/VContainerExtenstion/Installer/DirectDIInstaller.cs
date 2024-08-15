using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using VContainer;

namespace SotongStudio.VContainer
{
    public class DirectDIInstaller : VContainerInstallerObject
    {
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _mainObject;
#endif
        [ReadOnly]
        [SerializeField] private string _mainObjectScripting;
#if UNITY_EDITOR
        [SerializeField] private List<UnityEditor.MonoScript> _additionalObjects;
#endif
        [ReadOnly]
        [SerializeField] private List<string> _additionalObjectScripting = new();
        [SerializeField] private List<MonoBehaviour> _objectComponents;




        public override void Install(IContainerBuilder builder)
        {
            VContainerDIInstallerUtils.RegisterComponent(builder, _mainObjectScripting);
            VContainerDIInstallerUtils.RegisterComponents(builder, _additionalObjectScripting);
            VContainerDIInstallerUtils.RegisterComponents(builder, _objectComponents);
        }

        public override void OnAfterDeserialize()
        {

        }
        public override void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);
            if (_additionalObjects != null) VContainerDIInstallerUtils.RevalidateScripts(_additionalObjects, ref _additionalObjectScripting);
#endif
        }
    }
}
