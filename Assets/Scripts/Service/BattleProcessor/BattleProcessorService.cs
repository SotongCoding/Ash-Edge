using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.DungeonExplore;
using SotongStudio.AshEdge.Esential.Unit.Enemy;
using SotongStudio.AshEdge.Service.DataLoader;
using SotongStudio.AshEdge.Service.Party;
using SotongStudio.AshEdge.Service.SceneLoader;
using UnityEngine;

namespace SotongStudio.AshEdge.Service.BattleProcessor
{
    public class BattleProcessorService
    {
        private readonly SceneLoaderService _sceneLoader;

        public EnemyBattleData CurrentEnemyData { get; private set; }
        private string _mapLayoutId;
        private string _nodeDataId;
        private readonly BattlePartyService _partyService;

        public BattleProcessorService(SceneLoaderService sceneLoaderService, BattlePartyService partyService)
        {
            _sceneLoader = sceneLoaderService;
            _partyService = partyService;
        }
    }
}
