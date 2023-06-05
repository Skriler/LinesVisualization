namespace LinesVisualization.Classes.Data
{
    public class NodeObject
    {
        public string Name { get; private set; }
        public string Group { get; private set; }

        private Dictionary<string, string> characteristics;

        public string this[string key]
        {
            get => characteristics.GetValueOrDefault(key);
            set => characteristics[key] = value;
        }

        public NodeObject()
        {
            characteristics = new Dictionary<string, string>();
            Group = string.Empty;
            Name = string.Empty;
        }

        public int Count => characteristics.Count;

        public void AddValue(string key, string value)
        {
            if (key == string.Empty)
                return;

            characteristics.Add(key, value);
        }

        public void SetKeyCharacteristics(string groupByCharc = "Підгрупа", string nameByCharc = "Назва")
        {
            Group = characteristics.GetValueOrDefault(groupByCharc);
            Name = characteristics.GetValueOrDefault(nameByCharc);
        }
    }
}
