﻿using System;
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
					UpdateBigEndianHexBox(inputValue, numberOfBytesUsed);
					UpdateLittleEndianHexBox(inputValue, numberOfBytesUsed);
					break;

				case NumericBase.Decimal:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateBigEndianHexBox(inputValue, numberOfBytesUsed);
					UpdateLittleEndianHexBox(inputValue, numberOfBytesUsed);
					break;

				case NumericBase.BigEndianHex:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateDecimalBox(inputValue);
					UpdateLittleEndianHexBox(inputValue, numberOfBytesUsed);
					break;

				case NumericBase.LittleEndianHex:
					UpdateBinaryBox(inputValue, numberOfBytesUsed);
					UpdateDecimalBox(inputValue);
					UpdateBigEndianHexBox(inputValue, numberOfBytesUsed);
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

		private void UpdateBigEndianHexBox(long outputValue, int numberOfBytes)
		{
			txtBigEndianHex.Text = outputValue.ToString("X" + (2 * numberOfBytes));
		}

		private void UpdateLittleEndianHexBox(long outputValue, int numberOfBytes)
		{
			txtLittleEndianHex.Text = BitConverter.ToString(BitConverter.GetBytes(outputValue)).Replace("-", "").Substring(0, numberOfBytes * 2);
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

		private enum NumericBase
		{
			Binary,
			Decimal,
			BigEndianHex,
			LittleEndianHex
		}

		private void txtBigEndianHex_KeyUp(object sender, KeyEventArgs e)
		{
			if (Regex.IsMatch(txtBigEndianHex.Text, @"^[\dA-Fa-f]*$"))
			{
				if (txtBigEndianHex.Text.Length > 0)
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
			if (Regex.IsMatch(txtLittleEndianHex.Text, @"^[\dA-Fa-f]*$"))
			{
				if (txtLittleEndianHex.Text.Length > 0)
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
}