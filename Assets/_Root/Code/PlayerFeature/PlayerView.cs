using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public SpriteRenderer Head { get; private set; }
        [field: SerializeField] public SpriteRenderer Body { get; private set; }
        [field: SerializeField] public SpriteRenderer LeftArm { get; private set; }
        [field: SerializeField] public SpriteRenderer LeftElbow { get; private set; }
        [field: SerializeField] public SpriteRenderer RightArm { get; private set; }
        [field: SerializeField] public SpriteRenderer RightElbow { get; private set; }
        [field: SerializeField] public SpriteRenderer RightLeg { get; private set; }
        [field: SerializeField] public SpriteRenderer LeftLeg { get; private set; }
        public PlayerPresenter PlayerPresenter { get; private set; }
        public void Initialize(PlayerPresenter playerPresenter)
        {
            PlayerPresenter = playerPresenter;
        }
    }
}