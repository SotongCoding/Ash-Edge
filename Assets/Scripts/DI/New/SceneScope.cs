using System;
using NaughtyAttributes;
using SotongStudio.AshEdge.Gameplay.CardMechanic;
using SotongStudio.VContainer;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.AshEdge
{
    public class SceneScope : LifetimeScope
    {
        [SerializeField] private ScriptInstaller[] _additionalInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            foreach (var installer in _additionalInstaller)
            {
                installer.Install(builder);
            }
        }
    }
}
