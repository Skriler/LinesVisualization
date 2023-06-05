namespace LinesVisualization.Classes.Data
{
    public class ApplicationSettings
    {
        public const int DefaultMinSimilarCharacteristicsAmount = 40;
        public const int DefaultDeviationPercent = 10;
        public const string AllGenresSelectedCode = "All";

        public int MinSimilarCharacteristicsAmount { get; set; }
        public float DeviationPercent { get; private set; }
        public float MinPossibleCoeff { get; private set; }
        public float MaxPossibleCoeff { get; private set; }

        public string SelectedGroup { get; set; }
        public Dictionary<string, bool> SelectedFields { get; private set; }

        public string DatabaseName { get; private set; }
        public string TableName { get; private set; }

        public ApplicationSettings()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            MinSimilarCharacteristicsAmount = DefaultMinSimilarCharacteristicsAmount;
            SetDeviationPercent(DefaultDeviationPercent);

            SelectedGroup = AllGenresSelectedCode;
            SelectedFields = new Dictionary<string, bool>();

            DatabaseName = "sunflower_lines";
            TableName = "lines";
        }

        public void SetDeviationPercent(float deviationPercent)
        {
            DeviationPercent = deviationPercent;

            MinPossibleCoeff = 1 - DeviationPercent / 100;
            MaxPossibleCoeff = 1 + DeviationPercent / 100;
        }

        public void SetSelectedFields(string[] fields)
        {
            SelectedFields.Clear();
            Array.ForEach(fields, f => SelectedFields.Add(f, true));
        }

        public int GetActiveFieldsAmount() => SelectedFields.Count(f => f.Value == true);
    }
}
