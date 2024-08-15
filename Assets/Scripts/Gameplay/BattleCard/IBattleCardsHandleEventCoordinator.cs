using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using UnityEngine.Events;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic
{
    public interface IBattleCardsHandlerEventCoordinator 
    {
        UnityEvent<IBattleCard> OnPlayerCardSelected {get;}
        UnityEvent<IBattleCard> OnDetermineCardSelected {get;}
        UnityEvent<IBattleCard> OnPlayedCardSelected {get;}

        UnityEvent<IEnumerable<IBattleCard>> OnCheckSelectedCards { get;  }

        UnityEvent OnPlayerDoneChooseCard {get;}
    }
}
