using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Character;
using UnityEngine;

namespace SotongStudio.AshEdge.BaseData.ContentCollection.MasterChaarcter
{
    [CreateAssetMenu(fileName = "Master Character Contents", menuName = "Content/Collection/Data/Master Characters", order = 0)]
    public class MasterCharacterContentCollection : ContentDataCollection, IContenDataCollection<MasterCharacterData>
    {
        private Dictionary<string, MasterCharacterData> _cachedAsset;
        public Dictionary<string, MasterCharacterData> AllAssets => GetAssets(ref _cachedAsset);
    }
}
