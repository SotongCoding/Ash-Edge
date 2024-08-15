using SotongStudio.AshEdge.Service.SceneLoader;
using SotongStudio.AshEdge.Shared.GameData.Battle.Provider;
using SotongStudio.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.AshEdge
{
    public class LifetimeRoot : LifetimeScope
    {
        [SerializeField] private ScriptableObject[] _registerdScriptableObjects;
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var data in _registerdScriptableObjects)
            {
                VContainerDIInstallerUtils.RegisterScriptable(builder, data);
            }

            builder.Register<BattleDataProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SceneLoaderService>(Lifetime.Singleton);
        }
    }
}
