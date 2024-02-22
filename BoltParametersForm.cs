using System;
using System.Drawing;
using System.Windows.Forms;


namespace InvAddIn
{
    internal class BoltParametersForm : Form
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

        private Label lblDiameter;
        private Label lblLength;
        private Label lblThreadDepth;
        private Label lblThreadPitch;

        private TextBox txtDiameter;
        private TextBox txtLength;
        private TextBox txtThreadDepth;
        private TextBox txtThreadPitch;

        private Button btnOk;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoltParametersForm"/> class.
        /// </summary>
        public BoltParametersForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            lblDiameter = new Label
            {
                Text = "Bolt Diameter:",
                Location = new Point(10, 10)
            };
            lblLength = new Label
            {
                Text = "Bolt Length:",
                Location = new Point(10, 40)
            };
            lblThreadDepth = new Label
            {
                Text = "Thread Depth:",
                Location = new Point(10, 70)
            };
            lblThreadPitch = new Label
            {
                Text = "Thread Pitch:",
                Location = new Point(10, 100)
            };
            txtDiameter = new TextBox
            {
                Location = new Point(120, 10)
            };

            txtLength = new TextBox
            {
                Location = new Point(120, 40)
            };

            txtThreadDepth = new TextBox
            {
                Location = new Point(120, 70)
            };

            txtThreadPitch = new TextBox
            {
                Location = new Point(120, 100)
            };

            btnOk = new Button
            {
                Text = "OK",
                Location = new Point(150, 130)
            };
            btnOk.Click += BtnOk_Click;

            Controls.AddRange(new Control[] { lblDiameter, lblLength, lblThreadDepth, lblThreadPitch, txtDiameter, txtLength, txtThreadDepth, txtThreadPitch, btnOk });

            ClientSize = new Size(250, 170);
            Text = "Enter Dimensions";
        }
        /// <summary>
        /// Event handler for the "OK" button click.
        /// Attempts to parse the input values, sets bolt parameters if successful, and sets the dialog result.
        /// Displays a message box for invalid input.
        /// </summary>
        private void BtnOk_Click(object sender, EventArgs e)
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
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.");
            }
        }
    }
}
