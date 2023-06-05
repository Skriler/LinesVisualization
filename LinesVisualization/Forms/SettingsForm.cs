using LinesVisualization.Classes.Data;

namespace LinesVisualization.Forms
{
    public partial class SettingsForm : Form
    {
        private const int TrackBarMinValue = 0;
        private const int TrackBarStep = 1;
        private const int TrackBarMaxDeviationPercent = 100;

        private NodeObjectsList nodes;
        private ApplicationSettings settings;

        public SettingsForm(ApplicationSettings settings, NodeObjectsList nodes)
        {
            InitializeComponent();

            this.settings = settings;
            this.nodes = nodes;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            InititalizeComboBoxSelectedGroup();
            InititalizeCheckedListBoxSelectedFields();

            InititalizeTrackBar(
                trcbrSimilarCharcAmount,
                settings.MinSimilarCharacteristicsAmount,
                TrackBarMinValue,
                chlbxSelectedFields.CheckedItems.Count,
                TrackBarStep);

            InititalizeTrackBar(
                trcbrMaxDeviationPercent,
                (int)settings.DeviationPercent,
                TrackBarMinValue,
                TrackBarMaxDeviationPercent,
                TrackBarStep);

            lblSimilarCharcValue.Text = "Value: " + trcbrSimilarCharcAmount.Value.ToString();
            lblMaxDeviationPercentValue.Text = "Value: " + trcbrMaxDeviationPercent.Value.ToString();
        }

        private void InititalizeComboBoxSelectedGroup()
        {
            cmbbxSelectedGroup.Items.Clear();
            cmbbxSelectedGroup.Items.Add(ApplicationSettings.AllGenresSelectedCode);

            var groups = nodes.GetAllGroups();
            if (groups != null && groups.Count > 0)
            {
                cmbbxSelectedGroup.Items.AddRange(groups.ToArray());
            }

            cmbbxSelectedGroup.SelectedItem = settings.SelectedGroup;
        }

        private void InititalizeCheckedListBoxSelectedFields()
        {
            chlbxSelectedFields.Items.AddRange(nodes.ColumnNames);

            int fieldIndex;
            foreach (var field in settings.SelectedFields)
            {
                if (!field.Value)
                    continue;

                fieldIndex = chlbxSelectedFields.Items.IndexOf(field.Key);
                chlbxSelectedFields.SetItemCheckState(fieldIndex, CheckState.Checked);
            }
        }

        private void InititalizeTrackBar(TrackBar trackBar, int value, int minValue, int maxValue, int step)
        {
            trackBar.Minimum = minValue;
            trackBar.Maximum = maxValue;
            trackBar.TickFrequency = step;
            trackBar.Value = value > maxValue ? maxValue : value;
        }

        private void trcbrSimilarCharcAmount_Scroll(object sender, EventArgs e)
        {
            lblSimilarCharcValue.Text = "Value: " + trcbrSimilarCharcAmount.Value.ToString();
        }

        private void trcbrMaxDeviationPercent_Scroll(object sender, EventArgs e)
        {
            lblMaxDeviationPercentValue.Text = "Value: " + trcbrMaxDeviationPercent.Value.ToString();
        }

        private void chlbxSelectedFields_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(
                (MethodInvoker)
                (() => SetSimilarCharcAmountMaxValue(chlbxSelectedFields.CheckedItems.Count)
                ));
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            settings.MinSimilarCharacteristicsAmount = trcbrSimilarCharcAmount.Value;
            settings.SetDeviationPercent(trcbrMaxDeviationPercent.Value);
            settings.SelectedGroup = cmbbxSelectedGroup.Text;

            int fieldIndex;
            foreach (var field in settings.SelectedFields)
            {
                fieldIndex = chlbxSelectedFields.Items.IndexOf(field.Key);

                settings.SelectedFields[field.Key] =
                    chlbxSelectedFields.GetItemChecked(fieldIndex);
            }

            this.Close();
        }

        private void SetSimilarCharcAmountMaxValue(int maxValue)
        {
            trcbrSimilarCharcAmount.Maximum = maxValue;
            trcbrSimilarCharcAmount.Value =
                trcbrSimilarCharcAmount.Value > maxValue ?
                maxValue :
                trcbrSimilarCharcAmount.Value;

            lblSimilarCharcValue.Text = "Value: " + trcbrSimilarCharcAmount.Value.ToString();
        }
    }
}
