using NaughtyAttributes;
using SotongStudio.VContainer;
using System;
using UnityEngine;
using VContainer;

namespace SotongStudio.AshEdge.DI
{
    [System.Serializable]
    public class DirectInstaller : BaseScriptInstaller, ISerializationCallbackReceiver
    {
        [ReadOnly]
        [SerializeField] private string _mainObjectScripting;
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _mainObject;
#endif
        public override void Install(IContainerBuilder builder)
        {
            VContainerDIInstallerUtils.RegisterComponent(builder, _mainObjectScripting);

            builder.RegisterBuildCallback(resolver =>
            {
                var obj = resolver.Resolve(Type.GetType(_mainObjectScripting));
                resolver.Inject(obj);
            });
        }

        public void OnAfterDeserialize()
        {

        }
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);
#endif
        }
    }
}
