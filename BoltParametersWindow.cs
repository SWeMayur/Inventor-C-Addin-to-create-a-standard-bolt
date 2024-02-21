using System;
using System.Windows;

namespace InvAddIn
{
    public partial class BoltParametersWindow : Window
    {
        public double BoltDiameter { get; set; }
        public double BoltLength { get; set; }
        public double BoltThreadDepth { get; set; }
        public double BoltThreadPitch { get; set; }

        public BoltParametersWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDiameter.Text, out double boltDiameter) &&
                double.TryParse(txtLength.Text, out double boltLength) &&
                double.TryParse(txtThreadDepth.Text, out double boltThreadDepth) &&
                double.TryParse(txtThreadPitch.Text, out double boltThreadPitch))
            {
                BoltDiameter = boltDiameter;
                BoltLength = boltLength;
                BoltThreadDepth = boltThreadDepth;
                BoltThreadPitch = boltThreadPitch;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.");
            }
        }
    }
}
