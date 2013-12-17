#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;
using System.IO;
using System.Windows.Forms;
using Dominion_War.Model;
using Dominion_War.model;
using Dominion_War.util;

#endregion

namespace Dominion_War
{
    public partial class DominionWarForm : Form
    {
        public DominionWarForm()
        {
            InitializeComponent();
        }

        private Fleet CreateFleet(Random random, string fleetFile)
        {
            Fleet fleet = new Fleet(random);
            fleet.ReadFleet(fleetFile);
            return fleet;
        }

        private void runSimulationButton_Click(object sender, EventArgs e)
        {
            battleResultTextBox.Clear();
            try
            {
                ValidateFileInput(fleet1TextBox, "fleet 1");
                ValidateFileInput(fleet2TextBox, "fleet 2");
                int seed = ValidateSeed();

                Random random = new Random(seed);

                Fleet fleet1 = CreateFleet(random, fleet1TextBox.Text);

                Fleet fleet2 = CreateFleet(random, fleet2TextBox.Text);

                SpaceBattle battle = new SpaceBattle(fleet1, fleet2);
                IBattleObserver observer = new BattleObserverImpl(battleResultTextBox);
                // add observer
                battle.Subscribe(observer);
     
                battle.CommenceBattle();
                battle.ReportBattleResults();
                // clean up, remove observer
                battle.UnSubscribe(observer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program failed with the following error" + 
                                Environment.NewLine + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateFileInput(TextBox fileInput, String fleetLabel)
        {
            if (String.IsNullOrEmpty(fileInput.Text))
            {
                throw new Exception("No file entered for " + fleetLabel);
            }
            if (!File.Exists(fleet1TextBox.Text))
            {
                throw new Exception(fileInput.Text + Environment.NewLine + "does not exist");
            }
        }

        private int ValidateSeed()
        {
            int seed = ValidationUtil.ParseStringToNumber(seedValueTextBox.Text);
            if (!ValidationUtil.ValidNumber(seed))
            {
                throw new Exception("Invalid seed value entered");
            }
            return seed;
        }


        private void openFleet1Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fleet1TextBox.Text = openFileDialog.FileName;
            }
        }

        private void openFleet2Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fleet2TextBox.Text = openFileDialog.FileName;
            }
        }
    }
}