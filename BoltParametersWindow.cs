<<<<<<< HEAD
﻿using System;
using System.Windows;

namespace InvAddIn
{
    /// <summary>
    /// Represents a window for entering bolt parameters (WPF).
    /// </summary>
    public partial class BoltParametersWindow : Window
    {
        /// <summary>
        /// Gets or sets the bolt diameter.
        /// </summary>
        public double BoltDiameter { get; set; }
        /// <summary>
        /// Gets or sets the bolt length.
        /// </summary>
        public double BoltLength { get; set; }
        /// <summary>
        /// Gets or sets the bolt thread depth.
        /// </summary>
        public double BoltThreadDepth { get; set; }
        /// <summary>
        /// Gets or sets the bolt thread pitch.
        /// </summary>
        public double BoltThreadPitch { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoltParametersWindow"/> class.
        /// </summary>
        public BoltParametersWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the "OK" button click.
        /// Attempts to parse the input values, sets bolt parameters if successful, and sets the dialog result.
        /// Displays a message box for invalid input.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
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
=======
﻿using System;
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
>>>>>>> b375f5686de37a0302cb23ef3d441de34fae9351
