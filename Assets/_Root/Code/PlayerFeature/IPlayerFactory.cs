using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public interface IPlayerFactory
    {
        PlayerPresenter CreatePlayer(Vector3 position);
    }
}