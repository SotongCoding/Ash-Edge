using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.ModelData.Unit.Status
{
    public interface IBaseAttribute
    {
        int Health { get; }
        int Power { get; }
        int Defense { get; }
    }
    public interface IModifyBaseAttribute
    {
        void ModifHealth(int value);
        void ModifPower(int value);
        void ModifDefense(int value);
    }
}
