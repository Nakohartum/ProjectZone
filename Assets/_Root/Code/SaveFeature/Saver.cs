using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace _Root.Code.SaveFeature
{
    public static class Wrapper
    {
        public static List<ISaveable> Saveables = new List<ISaveable>();
        public static string FilePath = Path.Combine(Application.persistentDataPath, "save.json");

        public static void Save()
        {
            var worldState = new Dictionary<string, object>();
            foreach (var sav in Saveables)
            {
                worldState[sav.Key] = sav.Save();
            }

            var wrapper = new SerializationWrapper(worldState);
            string json = JsonUtility.ToJson(wrapper, true);

            File.WriteAllText(FilePath, json);
            Debug.Log("Saved to " + FilePath);
        }
        
        public static void Load()
        {
            if (!File.Exists(FilePath))
            {
                Debug.LogWarning("No save file at " + FilePath);
                return;
            }

            string json = File.ReadAllText(FilePath);
            var wrapper = JsonUtility.FromJson<SerializationWrapper>(json);
            var worldState = wrapper.ToDictionary();

            foreach (var sav in Saveables)
            {
                if (worldState.TryGetValue(sav.Key, out var state))
                    sav.Load(state);
            }
            Debug.Log("Loaded from " + FilePath);
        }
    }
    
    
    [System.Serializable]
    public class SerializationWrapper
    {
        public List<string> keys   = new List<string>();
        public List<string> values = new List<string>();

        public SerializationWrapper(Dictionary<string, object> dict)
        {
            foreach (var kv in dict)
            {
                keys.Add(kv.Key);
                values.Add(JsonUtility.ToJson(kv.Value));
            }
        }

        public Dictionary<string, object> ToDictionary()
        {
            var result = new Dictionary<string, object>();
            for (int i = 0; i < keys.Count; i++)
            {
                result[keys[i]] = values[i];
            }
            return result;
        }
    }
}