namespace SNSC
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtBinary = new System.Windows.Forms.TextBox();
			this.txtDecimal = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBigEndianHex = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLittleEndianHex = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Binary:";
			// 
			// txtBinary
			// 
			this.txtBinary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBinary.Location = new System.Drawing.Point(15, 25);
			this.txtBinary.Name = "txtBinary";
			this.txtBinary.Size = new System.Drawing.Size(477, 33);
			this.txtBinary.TabIndex = 1;
			this.txtBinary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBinary_KeyUp);
			// 
			// txtDecimal
			// 
			this.txtDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDecimal.Location = new System.Drawing.Point(15, 82);
			this.txtDecimal.Name = "txtDecimal";
			this.txtDecimal.Size = new System.Drawing.Size(477, 33);
			this.txtDecimal.TabIndex = 2;
			this.txtDecimal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDecimal_KeyUp);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 66);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Decimal:";
			// 
			// txtBigEndianHex
			// 
			this.txtBigEndianHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBigEndianHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBigEndianHex.Location = new System.Drawing.Point(15, 139);
			this.txtBigEndianHex.Name = "txtBigEndianHex";
			this.txtBigEndianHex.Size = new System.Drawing.Size(477, 33);
			this.txtBigEndianHex.TabIndex = 3;
			this.txtBigEndianHex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBigEndianHex_KeyUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 123);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Hex (big endian):";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 180);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Hex (little endian):";
			// 
			// txtLittleEndianHex
			// 
			this.txtLittleEndianHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLittleEndianHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLittleEndianHex.Location = new System.Drawing.Point(15, 196);
			this.txtLittleEndianHex.Name = "txtLittleEndianHex";
			this.txtLittleEndianHex.Size = new System.Drawing.Size(477, 33);
			this.txtLittleEndianHex.TabIndex = 4;
			this.txtLittleEndianHex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLittleEndianHex_KeyUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 242);
			this.Controls.Add(this.txtLittleEndianHex);
			this.Controls.Add(this.txtBigEndianHex);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBinary);
			this.Controls.Add(this.txtDecimal);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1200, 280);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(520, 280);
			this.Name = "Form1";
			this.Text = "SNSC: Simple Numeral System Converter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBinary;
		private System.Windows.Forms.TextBox txtDecimal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBigEndianHex;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLittleEndianHex;
	}
}

