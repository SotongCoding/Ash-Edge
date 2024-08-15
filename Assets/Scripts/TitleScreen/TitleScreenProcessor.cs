using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Service.SceneLoader;
using UnityEngine;
using VContainer;

namespace SotongStudio.AshEdge
{
    public class TitleScreenProcessor : MonoBehaviour
    {
        private SceneLoaderService _sceneLoader;

        [Inject]
        private void CustomInject(SceneLoaderService sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void LoadDungeonExplore()
        {
            _sceneLoader.LoadSceneAsync(ConstSceneCode.DungeonExplore, default).Forget();
        }
    }
}
