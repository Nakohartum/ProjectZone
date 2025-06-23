using _Root.Code.ShootingFeature.Weapon;
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
        SpriteRenderer LeftAfterElbow { get; }
        SpriteRenderer RightArm { get; }
        SpriteRenderer RightElbow { get; }
        SpriteRenderer RightAfterElbow { get; }
        SpriteRenderer RightLeg { get; }
        SpriteRenderer LeftLeg { get; }
        Transform WeaponHolder { get; }
        PlayerPresenter PlayerPresenter { get; }
        GameObject GameObject { get; }
        WeaponView WeaponView { get; }
        
        void Initialize(PlayerPresenter playerPresenter);
    }
}