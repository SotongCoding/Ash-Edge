using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mono.Cecil;
using NaughtyAttributes;
using SotongStudio.AshEdge.GameData;
using UnityEditor;
using UnityEngine;

namespace SotongStudio.AshEdge.BaseData.ContentCollection
{
    public interface IContenDataCollection<T> where T : ContentCollectionItem
    {
        Dictionary<string, T> AllAssets { get; }
    }
    public abstract class ContentDataCollection : ScriptableObject
    {
        #region Setup
        //[ReadOnly]
        //[SerializeField]
        private ContentDataCollection _self;


        [ReadOnly]
        [SerializeField] private string _typeReferenceString;
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _typeReference;
#endif
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) { return; }
            if (_typeReference != null)
            {
                var scriptClass = _typeReference.GetClass();
                if (scriptClass == null) return;
                _typeReferenceString = scriptClass.AssemblyQualifiedName;
            }
            if (_self == null)
            {
                _self = this;
            }
        }
#endif
        #endregion

        #region Helper Editor Action
        [Button]
        private void SearchItems()
        {
#if UNITY_EDITOR
            var fileType = System.Type.GetType(_typeReferenceString);
            var rawFilePath = AssetDatabase.GetAssetPath(_self).Split('/');
            string filePath = string.Empty;

            for (int i = 0; i < rawFilePath.Length - 1; i++)
            {
                filePath += rawFilePath[i] + "/";
            }

            string[] files = Directory.GetFiles(filePath, "*.asset", SearchOption.TopDirectoryOnly);

            _allAsset.Clear();
            foreach (var file in files)
            {
                var asset = AssetDatabase.LoadAssetAtPath(file, fileType);

                if (asset != null)
                    _allAsset.Add(asset as ContentCollectionItem);

#endif
            }
        }
        #endregion

        [SerializeField] private List<ContentCollectionItem> _allAsset;

        protected Dictionary<string, T> GetAssets<T>(ref Dictionary<string, T> cachedAsset) where T : ContentCollectionItem
        {
            if (cachedAsset == null)
            {
                cachedAsset = new();
                foreach (ContentCollectionItem asset in _allAsset)
                {
                    cachedAsset.TryAdd(asset.MasterId, asset as T);
                }
            }

            return cachedAsset;
        }
    }
}
