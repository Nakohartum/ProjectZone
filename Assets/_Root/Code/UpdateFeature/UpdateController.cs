using System.Collections.Generic;
using _Root.Code.EnemyFeature;
using _Root.Code.InputFeature;
using _Root.Code.InventoryFeature;
using _Root.Code.ShootingFeature.Aiming;
using Game.Code.PlayerFeature;

namespace _Root.Code.UpdateFeature
{
    public class UpdateController : IUpdatable, IFixedUpdatable, ILateUpdatable
    {
        private static UpdateController _instance;
        private static List<IUpdatable> _updatables = new List<IUpdatable>();
        private static List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();
        private static List<ILateUpdatable> _lateUpdatables = new List<ILateUpdatable>();

        public static UpdateController Instance => _instance ?? new UpdateController();

        private UpdateController()
        {
            
        }
        
        public void Update(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.Update(deltaTime);
            }
        }

        public void AddUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void AddFixedUpdatable(IFixedUpdatable updatable)
        {
            _fixedUpdatables.Add(updatable);
        }

        public void FixedUpdate()
        {
            foreach (var updatable in _fixedUpdatables)
            {
                updatable.FixedUpdate();
            }
        }

        public void AddLateUpdatable(ILateUpdatable lateUpdatable)
        {
            _lateUpdatables.Add(lateUpdatable);
        }

        public void LateUpdate()
        {
            foreach (var updatable in _lateUpdatables)
            {
                updatable.LateUpdate();
            }
        }

        public void RemoveUpdatable(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }

        public void RemoveFixedUpdatable(IFixedUpdatable f)
        {
            _fixedUpdatables.Remove(f);
        }
    }
}