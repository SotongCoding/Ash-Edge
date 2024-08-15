using UnityEngine;

namespace SotongStudio.AshEdge.GameData
{
    public abstract class ContentCollectionItem : ScriptableObject
    {
        public abstract string MasterId { get; }
    }
}
