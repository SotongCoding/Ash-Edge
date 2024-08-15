using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Card;
using UnityEngine;

namespace SotongStudio.AshEdge.Service.AssetLoader
{
    public interface IAssetLoader 
    {
        public void LoadCardImage(string cardOwnerName, CardType type, AssetScope assetScope);
    }
}
