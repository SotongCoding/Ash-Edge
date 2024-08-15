using SotongStudio.AshEdge.DungeonExplore;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.AshEdge.DI.DungeonExplore
{
    public class DungeonExploreScope : LifetimeScope
    {
        [SerializeField] private Object[] TempRegisterObjects;
        [SerializeField] private DirectInstaller[] _directDIInstallers;
        [SerializeField] private ControlViewInstaller[] _controlViewDIInstallers;
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _directDIInstallers)
            {
                installer.Install(builder);
            }
            foreach (var installer in _controlViewDIInstallers)
            {
                installer.Install(builder);
            }


            foreach (var obj in TempRegisterObjects)
            {
                var type = obj.GetType();
                builder.RegisterInstance(obj).As(type);
            }
        }
    }
}
