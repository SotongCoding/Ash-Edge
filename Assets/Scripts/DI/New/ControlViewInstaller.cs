using NaughtyAttributes;
using SotongStudio.VContainer;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace SotongStudio.AshEdge.DI
{
    public class ControlViewInstaller : ScriptInstaller
    {
        [ReadOnly]
        [SerializeField] private string _mainObjectScripting;
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _mainObject;
#endif
        [SerializeField] private MonoBehaviour _viewComponent;

        public override void Install(IContainerBuilder builder)
        {
            if (string.IsNullOrEmpty(_mainObjectScripting) || _viewComponent == null)
            {
                return;
            }

            var registeredInstance = VContainerDIInstallerUtils.RegisterInstanceWithComponents(builder, _mainObjectScripting, _viewComponent);

            builder.RegisterBuildCallback(resolver =>
            {
                resolver.Inject(registeredInstance);
            });
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) { return; }

            if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);
        }
#endif
    }
}
