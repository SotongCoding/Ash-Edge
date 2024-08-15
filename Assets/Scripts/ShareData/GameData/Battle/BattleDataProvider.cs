using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using CardType = SotongStudio.AshEdge.GameData.Card.CardType;

namespace SotongStudio.AshEdge.Shared.GameData.Battle.Provider
{
    public interface IBattleDataProviderSetup
    {
        void SetBattleCharacter(string characterId);
        void SetBattleWaveId(string waveId);
    }
    public interface IBattleDataProvider
    {
        string GetCurrentWaveDataId();
        string GetPlayedCharacterId();

        BattleDeckData GetUsedDeckData();
    }
    public class BattleDataProvider : IBattleDataProviderSetup, IBattleDataProvider
    {
        private string _currentWaveId;
        private string _currentPlayedCharacterId = "CHR-001";
        private BattleDeckData _currentUsedDeck;

        public string GetCurrentWaveDataId()
        {
            return _currentWaveId;
        }

        public string GetPlayedCharacterId()
        {
            return _currentPlayedCharacterId;
        }

        public BattleDeckData GetUsedDeckData()
        {
            if (_currentUsedDeck == null)
            {
                _currentUsedDeck = new(
                new BattleCard[]
                {
                    new(1,CardType.Strike),
                    new(1,CardType.Magic),
                    new(1,CardType.Action),
                    new(1,CardType.Ace),

                    new(2,CardType.Strike),
                    new(2,CardType.Magic),
                    new(2,CardType.Action),
                    new(2,CardType.Ace),

                    new(3,CardType.Strike),
                    new(3,CardType.Magic),
                    new(3,CardType.Action),
                    new(3,CardType.Ace),

                    new(4,CardType.Strike),
                    new(4,CardType.Magic),
                    new(4,CardType.Action),
                    new(4,CardType.Ace),

                    new(5,CardType.Strike),
                    new(5,CardType.Magic),
                    new(5,CardType.Action),
                    new(5,CardType.Ace)
                });
            }
            return _currentUsedDeck;
        }

        public void SetBattleCharacter(string characterId)
        {
            // _currentPlayedCharacterId = characterId;
            _currentPlayedCharacterId = "CHR-001";
        }

        public void SetBattleWaveId(string waveId)
        {
            _currentWaveId = waveId;
        }
    }
}
