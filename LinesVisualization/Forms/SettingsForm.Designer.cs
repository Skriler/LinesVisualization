namespace LinesVisualization.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trcbrSimilarCharcAmount = new TrackBar();
            lblSimilarCharcAmount = new Label();
            lblSimilarCharcValue = new Label();
            lblMaxDeviationPercentValue = new Label();
            lblMaxDeviationPercent = new Label();
            trcbrMaxDeviationPercent = new TrackBar();
            btnSubmit = new Button();
            cmbbxSelectedGroup = new ComboBox();
            lblSelectedGroup = new Label();
            chlbxSelectedFields = new CheckedListBox();
            lblSelectedFields = new Label();
            ((System.ComponentModel.ISupportInitialize)trcbrSimilarCharcAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trcbrMaxDeviationPercent).BeginInit();
            SuspendLayout();
            // 
            // trcbrSimilarCharcAmount
            // 
            trcbrSimilarCharcAmount.Location = new Point(18, 30);
            trcbrSimilarCharcAmount.Maximum = 100;
            trcbrSimilarCharcAmount.Name = "trcbrSimilarCharcAmount";
            trcbrSimilarCharcAmount.Size = new Size(190, 45);
            trcbrSimilarCharcAmount.TabIndex = 0;
            trcbrSimilarCharcAmount.Scroll += trcbrSimilarCharcAmount_Scroll;
            // 
            // lblSimilarCharcAmount
            // 
            lblSimilarCharcAmount.AutoSize = true;
            lblSimilarCharcAmount.Location = new Point(18, 10);
            lblSimilarCharcAmount.Name = "lblSimilarCharcAmount";
            lblSimilarCharcAmount.Size = new Size(189, 15);
            lblSimilarCharcAmount.TabIndex = 1;
            lblSimilarCharcAmount.Text = "Min similar characteristics amount";
            // 
            // lblSimilarCharcValue
            // 
            lblSimilarCharcValue.AutoSize = true;
            lblSimilarCharcValue.Location = new Point(83, 70);
            lblSimilarCharcValue.Name = "lblSimilarCharcValue";
            lblSimilarCharcValue.Size = new Size(47, 15);
            lblSimilarCharcValue.TabIndex = 2;
            lblSimilarCharcValue.Text = "Value: 0";
            // 
            // lblMaxDeviationPercentValue
            // 
            lblMaxDeviationPercentValue.AutoSize = true;
            lblMaxDeviationPercentValue.Location = new Point(83, 160);
            lblMaxDeviationPercentValue.Name = "lblMaxDeviationPercentValue";
            lblMaxDeviationPercentValue.Size = new Size(47, 15);
            lblMaxDeviationPercentValue.TabIndex = 5;
            lblMaxDeviationPercentValue.Text = "Value: 0";
            // 
            // lblMaxDeviationPercent
            // 
            lblMaxDeviationPercent.AutoSize = true;
            lblMaxDeviationPercent.Location = new Point(47, 100);
            lblMaxDeviationPercent.Name = "lblMaxDeviationPercent";
            lblMaxDeviationPercent.Size = new Size(125, 15);
            lblMaxDeviationPercent.TabIndex = 4;
            lblMaxDeviationPercent.Text = "Max deviation percent";
            // 
            // trcbrMaxDeviationPercent
            // 
            trcbrMaxDeviationPercent.Location = new Point(18, 120);
            trcbrMaxDeviationPercent.Maximum = 100;
            trcbrMaxDeviationPercent.Name = "trcbrMaxDeviationPercent";
            trcbrMaxDeviationPercent.Size = new Size(190, 45);
            trcbrMaxDeviationPercent.TabIndex = 3;
            trcbrMaxDeviationPercent.Scroll += trcbrMaxDeviationPercent_Scroll;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSubmit.Location = new Point(12, 259);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(416, 50);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // cmbbxSelectedGroup
            // 
            cmbbxSelectedGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxSelectedGroup.FormattingEnabled = true;
            cmbbxSelectedGroup.Location = new Point(18, 210);
            cmbbxSelectedGroup.Name = "cmbbxSelectedGroup";
            cmbbxSelectedGroup.Size = new Size(190, 23);
            cmbbxSelectedGroup.TabIndex = 7;
            // 
            // lblSelectedGroup
            // 
            lblSelectedGroup.AutoSize = true;
            lblSelectedGroup.Location = new Point(70, 190);
            lblSelectedGroup.Name = "lblSelectedGroup";
            lblSelectedGroup.Size = new Size(86, 15);
            lblSelectedGroup.TabIndex = 8;
            lblSelectedGroup.Text = "Selected group";
            // 
            // chlbxSelectedFields
            // 
            chlbxSelectedFields.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chlbxSelectedFields.FormattingEnabled = true;
            chlbxSelectedFields.Location = new Point(240, 30);
            chlbxSelectedFields.Name = "chlbxSelectedFields";
            chlbxSelectedFields.Size = new Size(190, 202);
            chlbxSelectedFields.TabIndex = 9;
            chlbxSelectedFields.ItemCheck += chlbxSelectedFields_ItemCheck;
            // 
            // lblSelectedFields
            // 
            lblSelectedFields.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectedFields.AutoSize = true;
            lblSelectedFields.Location = new Point(280, 10);
            lblSelectedFields.Name = "lblSelectedFields";
            lblSelectedFields.Size = new Size(95, 15);
            lblSelectedFields.TabIndex = 10;
            lblSelectedFields.Text = "Selected headers";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 321);
            Controls.Add(lblSelectedFields);
            Controls.Add(chlbxSelectedFields);
            Controls.Add(lblSelectedGroup);
            Controls.Add(cmbbxSelectedGroup);
            Controls.Add(btnSubmit);
            Controls.Add(lblMaxDeviationPercentValue);
            Controls.Add(lblMaxDeviationPercent);
            Controls.Add(trcbrMaxDeviationPercent);
            Controls.Add(lblSimilarCharcValue);
            Controls.Add(lblSimilarCharcAmount);
            Controls.Add(trcbrSimilarCharcAmount);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)trcbrSimilarCharcAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)trcbrMaxDeviationPercent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trcbrSimilarCharcAmount;
        private Label lblSimilarCharcAmount;
        private Label lblSimilarCharcValue;
        private Label lblMaxDeviationPercentValue;
        private Label lblMaxDeviationPercent;
        private TrackBar trcbrMaxDeviationPercent;
        private Button btnSubmit;
        private ComboBox cmbbxSelectedGroup;
        private Label lblSelectedGroup;
        private CheckedListBox chlbxSelectedFields;
        private Label lblSelectedFields;
    }
}