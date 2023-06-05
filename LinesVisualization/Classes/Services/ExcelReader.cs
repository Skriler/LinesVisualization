using System.Data;
using System.Text;
using ExcelDataReader;
using LinesVisualization.Classes.Data;

namespace LinesVisualization.Classes.Services
{
    public class ExcelReader
    {
        public short RowHeadersIndex { get; private set; }

        public ExcelReader(short rowHeadersIndex = 2)
        {
            RowHeadersIndex = rowHeadersIndex;
        }

        public NodeObjectsList? GetExcelData(string fileName, string fileDirectory)
        {
            NodeObjectsList nodes = null;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string filepath = Path.Combine(fileDirectory, fileName);

            using (var streamval = File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(streamval))
                {
                    var configuration = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = false
                        }
                    };
                    var dataSet = reader.AsDataSet(configuration);

                    if (dataSet.Tables.Count > 0)
                    {
                        nodes = ParseTableData(dataSet.Tables[0]);
                    }
                }
            }

            return nodes;
        }

        private NodeObjectsList ParseTableData(DataTable dataTable)
        {
            NodeObjectsList nodes = new NodeObjectsList(dataTable.Columns.Count);

            DataRow[] rows = dataTable.Select();
            DataRow currentRow;
            string temp;

            for (short i = 0; i < dataTable.Columns.Count; ++i)
            {
                nodes.ColumnNames[i] = rows[RowHeadersIndex].ItemArray.ElementAt(i)?.ToString();
            }

            NodeObject nodeObject;

            for (short i = 0; i < dataTable.Rows.Count - RowHeadersIndex - 1; ++i)
            {
                currentRow = rows[i + RowHeadersIndex + 1];
                nodeObject = new NodeObject();

                for (short j = 0; j < dataTable.Columns.Count; ++j)
                {
                    temp = currentRow.ItemArray.ElementAt(j)?.ToString();

                    nodeObject.AddValue(nodes.ColumnNames[j], temp);
                }

                nodes.NodeObjects.Add(nodeObject);
            }

            return nodes;
        }
    }
}
