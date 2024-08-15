using SotongStudio.AshEdge.DungeonExplore.LayoutGenerator;
using UnityEngine;
using VContainer;

namespace SotongStudio.AshEdge.DungeonExplore
{
    public class DungeonExploreFlowControl : MonoBehaviour
    {
        [SerializeField]
        private DungeonMap TestMapData;
        private ILayoutGeneratorController _layoutGenerator;

        [Inject]
        public void CustomInject(ILayoutGeneratorController layoutGenerator)
        {
            _layoutGenerator = layoutGenerator;
        }

        private void Start()
        {
            _layoutGenerator.GenerateMap(TestMapData);
        }


    }
}
