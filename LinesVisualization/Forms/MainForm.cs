using System.Data;
using LinesVisualization.Classes.Data;
using LinesVisualization.Classes.Services;

namespace LinesVisualization.Forms
{
    public partial class MainForm : Form
    {
        private string filterPattern = "Excel Workbook(*.xlsx)|*.xlsx|Excel 97- Excel 2003 Workbook(*.xls)|*.xls";
        private string filesDirectory = "..\\..\\..\\Files";

        private ApplicationSettings settings;

        private NodeObjectsList nodes;

        private ExcelReader excelReader;
        private DatabaseRepository dbManager;
        private DataComparer dataComparer;
        private GraphCreator graphCreator;

        public MainForm()
        {
            InitializeComponent();

            settings = new ApplicationSettings();

            dbManager = new DatabaseRepository(settings.DatabaseName);
            excelReader = new ExcelReader();
            dataComparer = new DataComparer(settings);
            graphCreator = new GraphCreator(settings);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeComponentsParameters();

            try
            {
                nodes = TryGetDataFromDatabase();


                if (nodes != null)
                {
                    nodes.SetKeyCharacteristicsToNodes();
                    settings.SetSelectedFields(nodes.ColumnNames);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void InitializeComponentsParameters()
        {
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = filterPattern;
            openFileDialog.RestoreDirectory = true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(filesDirectory, fileName);

            try
            {
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                    dbManager.DropTable(settings.TableName);
                    settings.SetDefaultValues();

                    MessageBox.Show("Previous data deleted!", "Info");
                }

                File.Copy(filePath, destinationPath);

                nodes = excelReader.GetExcelData(fileName, filesDirectory);
                dbManager.CreateDatabase();
                dbManager.CreateTable(settings.TableName, nodes);
                dbManager.InsertDataIntoTable(settings.TableName, nodes);

                MessageBox.Show("Data read successfully!", "Success");

                nodes.SetKeyCharacteristicsToNodes();
                settings.SetSelectedFields(nodes.ColumnNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dbManager.IsDatabaseExist() || !dbManager.IsTableExist(settings.TableName))
                {
                    MessageBox.Show($"Nothing to show", "Info");
                    return;
                }

                DataSet dataSet = dbManager.GetAllTableData(settings.TableName);

                if (dataSet != null)
                {
                    graphViewer.Visible = false;
                    dgvTableData.Visible = true;
                    dgvTableData.DataSource = dataSet.Tables[settings.TableName]?.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nodes == null)
            {
                MessageBox.Show($"No data to visualize", "Info");
                return;
            }

            dgvTableData.Visible = false;
            graphViewer.Visible = true;

            try
            {
                List<NodeObject> selectedObjects;
                if (settings.SelectedGroup != ApplicationSettings.AllGenresSelectedCode)
                {
                    selectedObjects = nodes.NodeObjects.Where(n => n.Group == settings.SelectedGroup).ToList();
                }
                else
                {
                    selectedObjects = nodes.NodeObjects;
                }

                var similarObjects = dataComparer.GetSimilarObjects(nodes.ColumnNames, selectedObjects);
                graphViewer.Graph = graphCreator.CreateGraph(similarObjects);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nodes == null)
            {
                MessageBox.Show($"No data to configure", "Info");
                return;
            }

            SettingsForm settingsForm = new SettingsForm(settings, nodes);
            settingsForm.ShowDialog();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            graphViewer.Width = dgvTableData.Width;
            graphViewer.Height = dgvTableData.Height;
        }

        private NodeObjectsList? TryGetDataFromDatabase()
        {
            NodeObjectsList nodes = null;

            if (!dbManager.IsDatabaseExist() || !dbManager.IsTableExist(settings.TableName))
                return nodes;

            DataSet dataSet = dbManager.GetAllTableData(settings.TableName);
            string[] columnNames = dbManager.GetTableColumnNames(settings.TableName);

            if (dataSet == null || columnNames == null)
                return nodes;

            DataTable dataTable = dataSet.Tables[settings.TableName];

            if (dataTable == null)
                return nodes;

            int rowsAmount = dataTable.Rows.Count;
            int columnsAmount = dataTable.Columns.Count;

            nodes = new NodeObjectsList(columnsAmount - 1);
            nodes.SetColumnNames(columnNames.Skip(1).ToArray());

            var dataRows = dataTable.Rows;
            NodeObject nodeObject;

            for (int i = 0; i < rowsAmount; ++i)
            {
                nodeObject = new NodeObject();

                for (int j = 1; j < columnsAmount; ++j)
                {
                    nodeObject.AddValue(
                        columnNames[j],
                        dataRows[i][j]?.ToString()
                        );
                }

                nodes.NodeObjects.Add(nodeObject);
            }

            return nodes;
        }
    }
}