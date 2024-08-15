using SotongStudio.AshEdge.GameData.Card;
using SotongStudio.AshEdge.GameData.Character;
using SotongStudio.AshEdge.GameData.Enemy;

namespace SotongStudio.AshEdge.Service.ContentCollection
{
    public interface IContentLoaderService
    {
        MasterCharacterData GetCharaterMasterData(string characterMasterId);
        MasterEnemyWaveData GetEnemyWaveMasterData(string waveId);
        MasterCardData GetMasterCardData(string masterCardId);
    }
}
