using System.Collections.Generic;
using SotongStudio.AshEdge.GameData;
using SotongStudio.AshEdge.GameData.Enemy;
using UnityEngine;

namespace SotongStudio.AshEdge.DungeonExplore
{
    [CreateAssetMenu(menuName = "Game Data/Dungeon Map", fileName = "DMP-XXX-Name")]
    public class DungeonMap : ContentCollectionItem
    {
        public string MapId;
        public List<NodeData> NodeDatas;

        public override string MasterId => MapId;
    }

    [System.Serializable]
    public struct NodeData
    {
        public NodeVisualData VisualData;
        public NodeConfig Config;
    }

    [System.Serializable]
    public struct NodeVisualData
    {
        public int NodeIndex;
        public bool AsStartNode;
        public Vector2 NodePosition;
        public int[] ConnectedNodeIds;
        public Sprite NodeSprite;
    }

    [System.Serializable]
    public struct NodeConfig
    {
        public MasterEnemyWaveData WaveData;
    }
}
