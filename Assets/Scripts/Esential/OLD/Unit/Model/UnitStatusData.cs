
using UnityEngine;

namespace SotongStudio.AshEdge.ModelData.Unit.Status
{
    [System.Serializable]
    public class UnitStatusData : IBaseAttribute, IModifyBaseAttribute
    {
        //TODO : Delete when party Data is Ready
        [UnityEngine.SerializeField] private int _health;
        [UnityEngine.SerializeField] private int _power;
        [UnityEngine.SerializeField] private int _defense;

        public int Health => _health;
        public int Power => _power;
        public int Defense => _defense;

        public UnitStatusData(int health, int power, int defense)
        {
            _health = health;
            _power = power;
            _defense = defense;
        }
        public UnitStatusData(UnitStatusData unitStatus)
        {
            _health = unitStatus.Health;
            _power = unitStatus.Power;
            _defense = unitStatus.Defense;
        }

        public void OverrideStatus(UnitStatusData overrideData)
        {
            _health = overrideData.Health;
            _power = overrideData.Power;
            _defense = overrideData.Defense;
        }
        public void OverrideHealth(int health)
        {
            _health = health;
        }


        public void ModifHealth(int value)
        {
            _health += value;
        }

        public void ModifPower(int value)
        {
            _power += value;
        }

        public void ModifDefense(int value)
        {
            _defense += value;
        }

        public void AddGrowth(int health, int power, int defense)
        {
            ModifHealth(health);
            ModifDefense(defense);
            ModifPower(power);
        }
    }
}
