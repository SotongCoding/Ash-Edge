// using System;
// using NaughtyAttributes;
// using SotongStudio.VContainer;
// using UnityEngine;
// using VContainer;

// namespace SotongStudio.AshEdge.DI.Old
// {
//     [System.Serializable]
//     public class ControlViewInstaller : BaseScriptInstaller, ISerializationCallbackReceiver
//     {
//         [ReadOnly]
//         [SerializeField] private string _mainObjectScripting;
// #if UNITY_EDITOR
//         [SerializeField] private UnityEditor.MonoScript _mainObject;
// #endif
//         [SerializeField] private MonoBehaviour[] _components;

//         [Header("Multi Item")]
//         [SerializeField] private MultiItemInstaller _multiItemsInstaller;


//         public override void Install(IContainerBuilder builder)
//         {
//             _multiItemsInstaller.Install(builder);

//             if (string.IsNullOrEmpty(_mainObjectScripting))
//             {
//                 return;
//             }
//             VContainerDIInstallerUtils.RegisterInstanceWithComponents(builder, _mainObjectScripting, _components);

//             builder.RegisterBuildCallback(resolver =>
//             {
//                 var obj = resolver.Resolve(Type.GetType(_mainObjectScripting));
//                 resolver.Inject(obj);
//             });
//         }

//         public void OnAfterDeserialize()
//         {

//         }
//         public void OnBeforeSerialize()
//         {
// #if UNITY_EDITOR
//             if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);

//             // _multiItemsInstaller?.OnBeforeSerialize();
// #endif
//         }
//     }
// }
