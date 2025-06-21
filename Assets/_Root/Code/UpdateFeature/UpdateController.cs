using System.Collections.Generic;
using _Root.Code.InputFeature;
using Game.Code.PlayerFeature;

namespace _Root.Code.UpdateFeature
{
    public class UpdateController : IUpdatable, IFixedUpdatable
    {
        private static UpdateController _instance;
        private static List<IUpdatable> _updatables = new List<IUpdatable>();
        private static List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

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
    }
}