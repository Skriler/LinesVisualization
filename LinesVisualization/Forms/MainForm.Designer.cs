namespace LinesVisualization.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dgvTableData = new DataGridView();
            graphViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            graphToolStripMenuItem = new ToolStripMenuItem();
            buildToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvTableData).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTableData
            // 
            dgvTableData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTableData.Location = new Point(12, 28);
            dgvTableData.MinimumSize = new Size(640, 520);
            dgvTableData.Name = "dgvTableData";
            dgvTableData.RowTemplate.Height = 25;
            dgvTableData.Size = new Size(640, 520);
            dgvTableData.TabIndex = 1;
            // 
            // graphViewer
            // 
            graphViewer.ArrowheadLength = 10D;
            graphViewer.AsyncLayout = false;
            graphViewer.AutoScroll = true;
            graphViewer.AutoSize = true;
            graphViewer.BackwardEnabled = false;
            graphViewer.BuildHitTree = true;
            graphViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.MDS;
            graphViewer.EdgeInsertButtonVisible = true;
            graphViewer.FileName = "";
            graphViewer.ForwardEnabled = false;
            graphViewer.Graph = null;
            graphViewer.IncrementalDraggingModeAlways = false;
            graphViewer.InsertingEdge = false;
            graphViewer.LayoutAlgorithmSettingsButtonVisible = true;
            graphViewer.LayoutEditingEnabled = true;
            graphViewer.Location = new Point(12, 28);
            graphViewer.LooseOffsetForRouting = 0.25D;
            graphViewer.MinimumSize = new Size(640, 520);
            graphViewer.MouseHitDistance = 0.05D;
            graphViewer.Name = "graphViewer";
            graphViewer.NavigationVisible = true;
            graphViewer.NeedToCalculateLayout = true;
            graphViewer.OffsetForRelaxingInRouting = 0.6D;
            graphViewer.PaddingForEdgeRouting = 8D;
            graphViewer.PanButtonPressed = false;
            graphViewer.SaveAsImageEnabled = true;
            graphViewer.SaveAsMsaglEnabled = true;
            graphViewer.SaveButtonVisible = true;
            graphViewer.SaveGraphButtonVisible = true;
            graphViewer.SaveInVectorFormatEnabled = true;
            graphViewer.Size = new Size(640, 520);
            graphViewer.TabIndex = 3;
            graphViewer.TightOffsetForRouting = 0.125D;
            graphViewer.ToolBarIsVisible = true;
            graphViewer.Transform = (Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)resources.GetObject("graphViewer.Transform");
            graphViewer.UndoRedoButtonsVisible = true;
            graphViewer.WindowZoomButtonPressed = false;
            graphViewer.ZoomF = 1D;
            graphViewer.ZoomWindowThreshold = 0.05D;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, graphToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(664, 24);
            menuStrip.TabIndex = 4;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, showToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(43, 20);
            fileToolStripMenuItem.Text = "Data";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(103, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(103, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // graphToolStripMenuItem
            // 
            graphToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { buildToolStripMenuItem, settingsToolStripMenuItem });
            graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            graphToolStripMenuItem.Size = new Size(51, 20);
            graphToolStripMenuItem.Text = "Graph";
            // 
            // buildToolStripMenuItem
            // 
            buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            buildToolStripMenuItem.Size = new Size(116, 22);
            buildToolStripMenuItem.Text = "Build";
            buildToolStripMenuItem.Click += buildToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "excelFile";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(664, 561);
            Controls.Add(menuStrip);
            Controls.Add(graphViewer);
            Controls.Add(dgvTableData);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(680, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lines visualization";
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvTableData).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvTableData;
        private Microsoft.Msagl.GraphViewerGdi.GViewer graphViewer;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem graphToolStripMenuItem;
        private ToolStripMenuItem buildToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
    }
}