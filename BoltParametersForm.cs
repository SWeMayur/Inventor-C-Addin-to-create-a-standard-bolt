using System;
using System.Drawing;
using System.Windows.Forms;


namespace InvAddIn
{
    internal class BoltParametersForm : Form
    {
        public double BoltDiameter { get; set; }
        public double BoltLength { get; set; }
        public double BoltThreadDepth { get; set; }
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
