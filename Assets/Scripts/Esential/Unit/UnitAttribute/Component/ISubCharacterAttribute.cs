using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Esential.Character.Attribute
{
    public interface ISubUnitAttribute
    {
        int EvasionRate { get; }
        int BlockRate { get; }
        int CriticalRate { get; }
        int CriticalDamage { get; }

    }
    public interface IModifSubCharacterAttribute
    {
        void AddEvasionRate(int value);
        void AddBlockRate(int value);
        void AddCriticalRate(int value);
        void AddCriticalDamage(int value);
    }
}
