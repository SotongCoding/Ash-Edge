
using System.Collections.Generic;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.DungeonExplore.LayoutGenerator
{
    public interface ILayoutGeneratorController
    {
        public void GenerateMap(DungeonMap mapData);
    }
    [RegisterAs(typeof(ILayoutGeneratorController))]
    public class LayoutGeneratorController : ILayoutGeneratorController
    {
        private readonly IReadOnlyList<DungeonNodeObjectItemLogic> _availableNodes;

        public LayoutGeneratorController(IReadOnlyList<DungeonNodeObjectItemLogic> availableNodes)
        {
            _availableNodes = availableNodes;
        }

        public void GenerateMap(DungeonMap mapData)
        {
            foreach (var node in _availableNodes)
            {
                node.SetActive(false);
            }
            foreach (var node in mapData.NodeDatas)
            {
                var visualData = node.VisualData;
                var currentNodeObject = GetNode(visualData.NodeIndex);
                var connectedNode = GetNodes(visualData.ConnectedNodeIds);

                currentNodeObject.SetupNode(visualData, connectedNode, node.Config);
            }
        }

        private DungeonNodeObjectItemLogic GetNode(int nodeId)
        {
            return _availableNodes[nodeId];
        }

        private IEnumerable<DungeonNodeObjectItemLogic> GetNodes(int[] nodeIds)
        {
            List<DungeonNodeObjectItemLogic> collected = new();
            foreach (var nodeId in nodeIds)
            {
                collected.Add(_availableNodes[nodeId]);
            }
            return collected;
        }

    }
}
