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
			return (value.ToString("X").Length + 1) / 2;
		}

		private void ConvertValue(long inputValue, NumericBase numericBase)
		{
			var numberOfBytesUsed = CalculateNumberOfBytes(inputValue);

			switch (numericBase)
			{
				case NumericBase.Binary:
					UpdateDecimalBox(inputValue);
					UpdateBigEndianHexBox(inputValue, numberOfBytesUsed, false);
					UpdateLittleEndianHexBox(inputValue, numberOfBytesUsed, false);
					break;

				case NumericBase.Decimal:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateBigEndianHexBox(inputValue, numberOfBytesUsed, false);
					UpdateLittleEndianHexBox(inputValue, numberOfBytesUsed, false);
					break;

				case NumericBase.BigEndianHex:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateDecimalBox(inputValue);
					UpdateLittleEndianHexBox(inputValue, numberOfBytesUsed, true);
					break;

				case NumericBase.LittleEndianHex:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateDecimalBox(inputValue);
					UpdateBigEndianHexBox(inputValue, numberOfBytesUsed, true);
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

		private void UpdateBigEndianHexBox(long outputValue, int numberOfBytes, bool matchByteCount)
		{
			txtBigEndianHex.Text = outputValue.ToString("X" + (2 * numberOfBytes));

			if (matchByteCount)
				txtBigEndianHex.Text = txtBigEndianHex.Text.PadLeft(txtLittleEndianHex.Text.Length, '0');
		}

		private void UpdateLittleEndianHexBox(long outputValue, int numberOfBytes, bool matchByteCount)
		{
			txtLittleEndianHex.Text = byteswap(outputValue.ToString("X" + (2 * numberOfBytes)));

			if (matchByteCount)
				txtLittleEndianHex.Text = txtLittleEndianHex.Text.PadRight(txtBigEndianHex.Text.Length, '0');
		}

		private void txtBinary_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtBinary.Text, @"^[01]+$"))
			{
				try
				{
					ConvertValue(Convert.ToInt64(txtBinary.Text, 2), NumericBase.Binary);
				}
				catch (OverflowException)
				{ }
			}
		}

		private void txtDecimal_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtDecimal.Text, @"^-?\d+$"))
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

		private enum NumericBase
		{
			Binary,
			Decimal,
			BigEndianHex,
			LittleEndianHex
		}

		private void txtBigEndianHex_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtBigEndianHex.Text, @"^[\dA-Fa-f]+$"))
			{
				try
				{
					var inputValue = Convert.ToInt64(txtBigEndianHex.Text, 16);

					ConvertValue(inputValue, NumericBase.BigEndianHex);
				}
				catch (OverflowException)
				{ }
			}
		}

		private string byteswap(string input)
		{
			char[] arr = input.ToCharArray();
			Array.Reverse(arr);

			int startIndex = arr.Length % 2 == 0 ? 0 : 1;
			
			for (int i=startIndex; i<arr.Length - 1; i+=2)
			{
				var temp = arr[i];
				arr[i] = arr[i + 1];
				arr[i + 1] = temp;
			}

			return new string(arr);
		}

		private void txtLittleEndianHex_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtLittleEndianHex.Text, @"^[\dA-Fa-f]+$"))
			{
				try
				{
					var inputValue = Convert.ToInt64(byteswap(txtLittleEndianHex.Text), 16);
						
					ConvertValue(inputValue, NumericBase.LittleEndianHex);
				}
				catch (OverflowException)
				{ }
			}
		}
	}
}