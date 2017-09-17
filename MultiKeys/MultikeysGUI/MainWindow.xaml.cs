﻿using MultikeysGUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultikeysGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var command = new DeadKeyCommand();
            command.Codepoints = new List<uint> { 0x1f604, 0x40 };
            command.Replacements = new Dictionary<IList<uint>, IList<uint>>
            {
                {
                    new List<uint> { 0x30, 0x31 },
                    new List<uint> { 0x1f630, 0x1f650 }
                }
            };
            Scancode01.UpdateCommand(command);
        }

        public void UpdateSummaryPanel(object sender, EventArgs e)
        {
            SummaryPanel.UpdateCommand(Scancode01.Command);
        }
    }
}