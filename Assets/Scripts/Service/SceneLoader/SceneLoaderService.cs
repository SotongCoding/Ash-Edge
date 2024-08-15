using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SotongStudio.AshEdge.Service.SceneLoader
{
    public class SceneLoaderService
    {
        private List<string> AlwaysOnScene = new()
        {
            ConstSceneCode.VisualNovel
        };
        private List<string> OneEachLoad = new()
        {
            ConstSceneCode.DungeonExplore,
            ConstSceneCode.Battle
        };
        private string _currentLoadedScene = string.Empty;

        public UniTask LoadSceneAsync(string sceneName, CancellationToken cancellationToken)
        {
            var isAON = AlwaysOnScene.Contains(sceneName);
            if (isAON)
            {
                // ProcessAONScene(sceneName);
                return UniTask.CompletedTask;
            }
            else
            {
                return ProcessOnceLoadSceneAsync(sceneName, cancellationToken);
            }
        }
        private void ProcessAONScene(string sceneName)
        {
            var selectedScene = SceneManager.GetSceneByName(sceneName);
            var isLoaded = selectedScene.isLoaded;
            if (isLoaded)
            {
                UnityEngine.Debug.LogWarning("Scene Already Loaded !");
                return;
            }
            SceneManager.LoadSceneAsync(selectedScene.buildIndex, LoadSceneMode.Additive);
        }
        private async UniTask ProcessOnceLoadSceneAsync(string sceneName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentLoadedScene))
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single)
                .ToUniTask(cancellationToken: cancellationToken);

                _currentLoadedScene = sceneName;
            }
            else
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single)
                .ToUniTask(cancellationToken: cancellationToken);

                await SceneManager.UnloadSceneAsync(_currentLoadedScene)
                .ToUniTask(cancellationToken: cancellationToken);
            }
        }
    }

    public class ConstSceneCode
    {
        public const string TitleScreen = nameof(TitleScreen);
        public const string DungeonExplore = nameof(DungeonExplore);
        public const string Battle = nameof(Battle);
        public const string VisualNovel = nameof(VisualNovel);
    }
}
