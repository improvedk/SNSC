using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SNSC
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private int CalculateNumberOfBytes(long value)
		{
			return (int)Math.Floor(Math.Log(value, 2) / 8) + 1;
		}

		private void ConvertValue(long inputValue, NumericBase numericBase)
		{
			var numberOfBytesUsed = CalculateNumberOfBytes(inputValue);

			switch (numericBase)
			{
				case NumericBase.Binary:
					UpdateDecimalBox(inputValue);
					UpdateHexBox(inputValue, numberOfBytesUsed);
					break;
				case NumericBase.Decimal:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateHexBox(inputValue, numberOfBytesUsed);
					break;
				case NumericBase.Hex:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateDecimalBox(inputValue);
					break;
			}
		}

		private void UpdateBinaryBox(long outputValue, int numberOfBytes)
		{
			var binString = Convert.ToString(outputValue, 2);

			txtBinary.Text = binString.PadLeft(8 * numberOfBytes, '0');
		}

		private void UpdateDecimalBox(long outputValue)
		{
			txtDecimal.Text = outputValue.ToString();
		}

		private void UpdateHexBox(long outputValue, int numberOfBytes)
		{
			txtHex.Text = outputValue.ToString("X" + (2 * numberOfBytes));
		}

		private void txtBinary_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtBinary.Text, @"^[01]*$"))
			{
				if (txtBinary.Text.Length > 0)
				{
					try
					{
						ConvertValue(Convert.ToInt64(txtBinary.Text, 2), NumericBase.Binary);
					}
					catch (OverflowException)
					{ }
				}
			}
		}

		private void txtDecimal_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtDecimal.Text, @"^\d*$"))
			{
				if (txtDecimal.Text.Length > 0)
				{
					try
					{
						var inputValue = Convert.ToInt64(txtDecimal.Text);

						ConvertValue(inputValue, NumericBase.Decimal);
					}
					catch (OverflowException)
					{ }
				}
			}
		}

		private void txtHex_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtHex.Text, @"^[\dA-Fa-f]*$"))
			{
				if (txtHex.Text.Length > 0)
				{
					try
					{
						var inputValue = Convert.ToInt64(txtHex.Text, 16);

						ConvertValue(inputValue, NumericBase.Hex);
					}
					catch (OverflowException)
					{ }
				}
			}
		}

		#region Nested type: NumericBase

		private enum NumericBase
		{
			Binary,
			Octet,
			Decimal,
			Hex
		}

		#endregion
	}
}