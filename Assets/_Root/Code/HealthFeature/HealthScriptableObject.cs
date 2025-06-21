using UnityEngine;

namespace _Root.Code.HealthFeature
{
    [CreateAssetMenu(fileName = nameof(HealthScriptableObject), menuName = "Create/Health/"+nameof(HealthScriptableObject), order = 0)]
    public class HealthScriptableObject : ScriptableObject
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
    }
}