namespace LinesVisualization.Classes.Data
{
    public class NodeObjectsList
    {
        public string[] ColumnNames { get; private set; }

        public List<NodeObject> NodeObjects { get; private set; }

        public NodeObjectsList(int columnsAmount)
        {
            ColumnNames = new string[columnsAmount];
            NodeObjects = new List<NodeObject>();
        }

        public List<string> GetAllGroups()
        {
            List<string> groups = new List<string>();

            foreach (NodeObject nodeObject in NodeObjects)
            {
                if (groups.Contains(nodeObject.Group) || nodeObject.Group == string.Empty)
                    continue;

                groups.Add(nodeObject.Group);
            }

            return groups;
        }

        public void SetKeyCharacteristicsToNodes()
        {
            foreach (NodeObject nodeObject in NodeObjects)
            {
                nodeObject.SetKeyCharacteristics();
            }
        }

        public void SetColumnNames(string[] columnNames)
        {
            if (columnNames == null || columnNames.Length != ColumnNames.Length)
                return;

            ColumnNames = columnNames;
        }
    }
}
