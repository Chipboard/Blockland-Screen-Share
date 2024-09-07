namespace BLSS
{
    partial class CaptureForm
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
            CaptureList = new ListBox();
            label1 = new Label();
            AddCaptureButton = new Button();
            RemoveCaptureButton = new Button();
            SettingsGroup = new GroupBox();
            DebugOutput = new TextBox();
            SuspendLayout();
            // 
            // CaptureList
            // 
            CaptureList.FormattingEnabled = true;
            CaptureList.Location = new Point(12, 32);
            CaptureList.Name = "CaptureList";
            CaptureList.Size = new Size(194, 364);
            CaptureList.TabIndex = 0;
            CaptureList.SelectedIndexChanged += CaptureList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Captures";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddCaptureButton
            // 
            AddCaptureButton.Location = new Point(12, 409);
            AddCaptureButton.Name = "AddCaptureButton";
            AddCaptureButton.Size = new Size(94, 29);
            AddCaptureButton.TabIndex = 2;
            AddCaptureButton.Text = "Add";
            AddCaptureButton.UseVisualStyleBackColor = true;
            AddCaptureButton.Click += AddCaptureButton_Click;
            // 
            // RemoveCaptureButton
            // 
            RemoveCaptureButton.Location = new Point(112, 409);
            RemoveCaptureButton.Name = "RemoveCaptureButton";
            RemoveCaptureButton.Size = new Size(94, 29);
            RemoveCaptureButton.TabIndex = 3;
            RemoveCaptureButton.Text = "Remove";
            RemoveCaptureButton.UseVisualStyleBackColor = true;
            RemoveCaptureButton.Click += RemoveCaptureButton_Click;
            // 
            // SettingsGroup
            // 
            SettingsGroup.Location = new Point(220, 32);
            SettingsGroup.Name = "SettingsGroup";
            SettingsGroup.Size = new Size(250, 364);
            SettingsGroup.TabIndex = 4;
            SettingsGroup.TabStop = false;
            // 
            // DebugOutput
            // 
            DebugOutput.ImeMode = ImeMode.NoControl;
            DebugOutput.Location = new Point(12, 444);
            DebugOutput.Multiline = true;
            DebugOutput.Name = "DebugOutput";
            DebugOutput.ScrollBars = ScrollBars.Both;
            DebugOutput.Size = new Size(458, 147);
            DebugOutput.TabIndex = 5;
            DebugOutput.TextChanged += DebugOutput_TextChanged;
            // 
            // CaptureForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 603);
            Controls.Add(DebugOutput);
            Controls.Add(SettingsGroup);
            Controls.Add(RemoveCaptureButton);
            Controls.Add(AddCaptureButton);
            Controls.Add(label1);
            Controls.Add(CaptureList);
            Name = "CaptureForm";
            Text = "Blockland Screen Share";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox CaptureList;
        private Label label1;
        private Button AddCaptureButton;
        private Button RemoveCaptureButton;
        private GroupBox SettingsGroup;
        public TextBox DebugOutput;
    }
}
