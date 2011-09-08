using System;
using System.Windows.Forms;

namespace SNSC
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		
		private void updateValues(long value, string origin)
		{
			if(origin != "binary")
				txtBinary.Text = Convert.ToString(value, 2);

			if(origin != "decimal")
				txtDecimal.Text = value.ToString();

			if(origin != "hex")
				txtHex.Text = Convert.ToString(value, 16).ToUpper();
		}

		private void txtHex_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				updateValues(Convert.ToInt64(txtHex.Text, 16), "hex");
			}
			catch
			{ }
		}

		private void txtDecimal_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				updateValues(Convert.ToInt64(txtDecimal.Text), "decimal");
			}
			catch
			{ }
		}

		private void txtBinary_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				updateValues(Convert.ToInt64(txtBinary.Text, 2), "binary");
			}
			catch
			{ }
		}
	}
}