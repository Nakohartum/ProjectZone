using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public interface IPlayerView
    {
        Rigidbody2D Rigidbody { get; }
        Animator Animator { get; }
        SpriteRenderer Head { get; }
        SpriteRenderer Body { get; }
        SpriteRenderer LeftArm { get; }
        SpriteRenderer LeftElbow { get; }
        SpriteRenderer RightArm { get; }
        SpriteRenderer RightElbow { get; }
        SpriteRenderer RightLeg { get; }
        SpriteRenderer LeftLeg { get; }
        PlayerPresenter PlayerPresenter { get; }
        
        void Initialize(PlayerPresenter playerPresenter);
    }
}