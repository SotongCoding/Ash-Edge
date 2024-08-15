using NaughtyAttributes;
using SotongStudio.VContainer;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace SotongStudio.AshEdge
{
    public class SubScope : ScriptInstaller
    {
        [ReadOnly]
        [SerializeField] private string _mainObjectScripting;
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _mainObject;
#endif
        [SerializeField] private AdditionalComponent[] _additionalComponents;

        [SerializeField] private ScriptInstaller[] _additionalInstaller;
        public override void Install(IContainerBuilder builder)
        {
            VContainerDIInstallerUtils.RegisterComponent(builder, _mainObjectScripting);
            foreach (var component in _additionalComponents)
            {
                VContainerDIInstallerUtils.RegisterComponent(builder, component.MainObjectScripting);
            }
            foreach (var installer in _additionalInstaller)
            {
                installer.Install(builder);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) { return; }

            if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);

            foreach (var component in _additionalComponents)
            {
                component.OnValidate();
            }
        }
#endif  
        [System.Serializable]
        private class AdditionalComponent
        {
            [ReadOnly] [AllowNesting]
            [SerializeField] private string _mainObjectScripting;
            public string MainObjectScripting => _mainObjectScripting;
#if UNITY_EDITOR
            [SerializeField] private UnityEditor.MonoScript _mainObject;
#endif

#if UNITY_EDITOR
            public void OnValidate()
            {
                if (EditorApplication.isPlayingOrWillChangePlaymode) { return; }

                if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);
            }
#endif  
        }
    }
}