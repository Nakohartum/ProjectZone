using System;
using _Root.Code.ShootingFeature.Weapon;
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
        [field: SerializeField] public SpriteRenderer LeftAfterElbow { get; private set; }
        [field: SerializeField] public SpriteRenderer RightArm { get; private set; }
        [field: SerializeField] public SpriteRenderer RightElbow { get; private set; }
        [field: SerializeField] public SpriteRenderer RightAfterElbow { get; private set; }
        [field: SerializeField] public SpriteRenderer RightLeg { get; private set; }
        [field: SerializeField] public SpriteRenderer LeftLeg { get; private set; }
        [field: SerializeField] public Transform WeaponHolder { get; private set; }
        public PlayerPresenter PlayerPresenter { get; private set; }
        public GameObject GameObject => gameObject;
        [field: SerializeField] public WeaponView WeaponView { get; private set; }


        public void Initialize(PlayerPresenter playerPresenter)
        {
            PlayerPresenter = playerPresenter;
        }

        private void OnDisable()
        {
            PlayerPresenter.Dispose();
        }
    }
}