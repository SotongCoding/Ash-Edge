using System.Collections.Generic;
using SotongStudio.AshEdge.BaseData.ContentCollection;
using SotongStudio.AshEdge.GameData;
using SotongStudio.AshEdge.GameData.Card;
using SotongStudio.AshEdge.GameData.Character;
using SotongStudio.AshEdge.GameData.Enemy;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.AshEdge.Service.ContentCollection
{
    [CreateAssetMenu(fileName = "Content Collections Service", menuName = "Content/Collection/CollectionService", order = 0)]
    [RegisterAs(typeof(IContentLoaderService))]
    public class ContentLoaderService : ScriptableObject, IContentLoaderService
    {
        [SerializeField]
        private List<ContentDataCollection> _collections;
        public MasterCardData GetMasterCardData(string masterId) => GetCollectionItem<MasterCardData>(masterId);
        public MasterCharacterData GetCharaterMasterData(string masterId)=> GetCollectionItem<MasterCharacterData>(masterId);
        public MasterEnemyWaveData GetEnemyWaveMasterData(string waveId) => GetCollectionItem<MasterEnemyWaveData>(waveId);

        private T GetCollectionItem<T>(string masterId) where T : ContentCollectionItem
        {
            var collection = _collections.Find(asset => asset is IContenDataCollection<T>) as IContenDataCollection<T>;

            return collection.AllAssets[masterId];
        }

    }
}
