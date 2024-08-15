using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Service.SceneLoader;
using SotongStudio.AshEdge.Shared.GameData.Battle.Provider;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI.Extensions;
using VContainer;

namespace SotongStudio.AshEdge.DungeonExplore.LayoutGenerator
{
    public class DungeonNodeObjectItemLogic : IDisposable
    {
        public RectTransform NodeTransform => (RectTransform)_view.transform;

        private IBattleDataProviderSetup _battleProviderSetup;
        private SceneLoaderService _sceneLoader;
        private readonly ObjectPool<UILineConnector> _uiLinePool;
        private readonly DungeonNodeObjectItemView _view;
        private bool disposedValue;
        private NodeConfig _currentHoldConfig;

        public DungeonNodeObjectItemLogic(DungeonNodeObjectItemView view)
        {
            _view = view;
            _uiLinePool = new(CreatateLineConnector);

            _view.OnClickNode.AddListener(ReactOnClickNode);
        }

        [Inject]
        private void Inject(IBattleDataProviderSetup battleProviderSetup,
                            SceneLoaderService sceneLoader)
        {
            _battleProviderSetup = battleProviderSetup;
            _sceneLoader = sceneLoader;
        }
        public void SetupNode(NodeVisualData currentNode, IEnumerable<DungeonNodeObjectItemLogic> connectedNodes, NodeConfig config)
        {
            _currentHoldConfig = config;

            _view.SetupObject(currentNode.NodePosition);
            foreach (var node in connectedNodes)
            {
                var uiLineConnector = _uiLinePool.Get();
                SetupLineConnector(uiLineConnector, node.NodeTransform);
                node.SetActive(true);
            }
            if (currentNode.AsStartNode)
            {
                SetActive(true);
            }

            _view.SetNodeIcon(currentNode.NodeSprite);
        }

        public void SetActive(bool actived)
        {
            _view.gameObject.SetActive(actived);

        }

        private void SetupLineConnector(UILineConnector lineConnector, RectTransform nextNode)
        {
            lineConnector.transforms = new RectTransform[]
            {
                    NodeTransform,
                    nextNode
            };
        }
        private UILineConnector CreatateLineConnector()
        {
            var lineObject = UnityEngine.Object.Instantiate(_view.LineConnector);

            lineObject.transform.SetParent(_view.transform.parent.parent);

            lineObject.transform.localScale = Vector3.one;
            lineObject.transform.localPosition = Vector3.zero;
            lineObject.gameObject.SetActive(true);
            var result = lineObject.gameObject.AddComponent<UILineConnector>();

            return result;
        }

        private void ReactOnClickNode()
        {
            _battleProviderSetup.SetBattleWaveId(_currentHoldConfig.WaveData.MasterId);
            _sceneLoader.LoadSceneAsync(ConstSceneCode.Battle, default).Forget();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _view.OnClickNode.RemoveListener(ReactOnClickNode);
                }


                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
