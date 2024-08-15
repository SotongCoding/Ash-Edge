using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.GameData.Card;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace SotongStudio.AshEdge.Service.AssetLoader
{
    public class AssetLoaderService 
    {
        #region Cached Data
        private Dictionary<AssetScope, AsyncOperationHandle> _cachedData;
        #endregion

        #region Card Asset
        private const string CardLable = "Card";
        public void LoadCardImageAsync(string cardOwnerName, CardType type, AssetScope assetScope, CancellationToken cancellationToken)
        {
            var handler = Addressables.LoadAssetsAsync<Image>(CardLable,
            (asset) =>
            {
                asset.name.Contains(cardOwnerName);
            }, false);
        }
        #endregion
    }

    public class AssetScope
    {
        public string Value { get; private set; }
        public AssetScope(string value)
        {
            Value = value;
        }

        public static AssetScope Battle => new("Battle");


    }
}
