namespace Dominion_War
{
    partial class DominionWarForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.battleResultTextBox = new System.Windows.Forms.TextBox();
            this.fleet2TextBox = new System.Windows.Forms.TextBox();
            this.fleet1TextBox = new System.Windows.Forms.TextBox();
            this.seedValueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFleet2Button = new System.Windows.Forms.Button();
            this.openFleet1Button = new System.Windows.Forms.Button();
            this.runSimulationButton = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.battleResultTextBox);
            this.panel1.Controls.Add(this.fleet2TextBox);
            this.panel1.Controls.Add(this.fleet1TextBox);
            this.panel1.Controls.Add(this.seedValueTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.openFleet2Button);
            this.panel1.Controls.Add(this.openFleet1Button);
            this.panel1.Controls.Add(this.runSimulationButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 424);
            this.panel1.TabIndex = 0;
            // 
            // battleResultTextBox
            // 
            this.battleResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.battleResultTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.battleResultTextBox.Location = new System.Drawing.Point(3, 137);
            this.battleResultTextBox.Multiline = true;
            this.battleResultTextBox.Name = "battleResultTextBox";
            this.battleResultTextBox.ReadOnly = true;
            this.battleResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.battleResultTextBox.Size = new System.Drawing.Size(502, 287);
            this.battleResultTextBox.TabIndex = 7;
            // 
            // fleet2TextBox
            // 
            this.fleet2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fleet2TextBox.Location = new System.Drawing.Point(131, 55);
            this.fleet2TextBox.Name = "fleet2TextBox";
            this.fleet2TextBox.Size = new System.Drawing.Size(350, 20);
            this.fleet2TextBox.TabIndex = 6;
            // 
            // fleet1TextBox
            // 
            this.fleet1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fleet1TextBox.HideSelection = false;
            this.fleet1TextBox.Location = new System.Drawing.Point(131, 23);
            this.fleet1TextBox.Name = "fleet1TextBox";
            this.fleet1TextBox.Size = new System.Drawing.Size(350, 20);
            this.fleet1TextBox.TabIndex = 5;
            // 
            // seedValueTextBox
            // 
            this.seedValueTextBox.Location = new System.Drawing.Point(131, 96);
            this.seedValueTextBox.Name = "seedValueTextBox";
            this.seedValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.seedValueTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seed value";
            // 
            // openFleet2Button
            // 
            this.openFleet2Button.Location = new System.Drawing.Point(25, 52);
            this.openFleet2Button.Name = "openFleet2Button";
            this.openFleet2Button.Size = new System.Drawing.Size(75, 23);
            this.openFleet2Button.TabIndex = 2;
            this.openFleet2Button.Text = "Fleet 2";
            this.openFleet2Button.UseVisualStyleBackColor = true;
            this.openFleet2Button.Click += new System.EventHandler(this.openFleet2Button_Click);
            // 
            // openFleet1Button
            // 
            this.openFleet1Button.Location = new System.Drawing.Point(25, 23);
            this.openFleet1Button.Name = "openFleet1Button";
            this.openFleet1Button.Size = new System.Drawing.Size(75, 23);
            this.openFleet1Button.TabIndex = 1;
            this.openFleet1Button.Text = "Fleet 1";
            this.openFleet1Button.UseVisualStyleBackColor = true;
            this.openFleet1Button.Click += new System.EventHandler(this.openFleet1Button_Click);
            // 
            // runSimulationButton
            // 
            this.runSimulationButton.Location = new System.Drawing.Point(262, 98);
            this.runSimulationButton.Name = "runSimulationButton";
            this.runSimulationButton.Size = new System.Drawing.Size(186, 23);
            this.runSimulationButton.TabIndex = 0;
            this.runSimulationButton.Text = "Run Simulation";
            this.runSimulationButton.UseVisualStyleBackColor = true;
            this.runSimulationButton.Click += new System.EventHandler(this.runSimulationButton_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Open";
            // 
            // DominionWarForm
            // 
            this.ClientSize = new System.Drawing.Size(505, 424);
            this.Controls.Add(this.panel1);
            this.Name = "DominionWarForm";
            this.Text = "Dominion War by Jeremy Yuille";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox fleet2TextBox;
        private System.Windows.Forms.TextBox fleet1TextBox;
        private System.Windows.Forms.TextBox seedValueTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openFleet2Button;
        private System.Windows.Forms.Button openFleet1Button;
        private System.Windows.Forms.Button runSimulationButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox battleResultTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}

