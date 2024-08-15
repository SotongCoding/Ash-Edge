using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Card;
using UnityEngine;

namespace SotongStudio.AshEdge.BaseData.ContentCollection.MasterCard
{
    [CreateAssetMenu(fileName = "Master Card Contents", menuName = "Content/Collection/Data/Master Cards", order = 0)]
    public class MasterCardContentCollection : ContentDataCollection, IContenDataCollection<MasterCardData>
    {
        private Dictionary<string, MasterCardData> _chacedAsset;
        public Dictionary<string, MasterCardData> AllAssets => GetAssets(ref _chacedAsset);
    }
}
