namespace _Root.Code.SaveFeature
{
    public interface ISaveable
    {
        public string Key { get; }
        object Save();
        
        void Load(object data);
    }
}