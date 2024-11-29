
namespace QL_NhaThieuNhi.FChuongTrinhNangKhieu
{
    partial class FrmLocChuongTrinhNangKhieu
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
            this.cbDiaDiem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpThoiGianKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpThoiGianBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkboxLocTheoThoiGian = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.checkboxLocDiaDiem = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SuspendLayout();
            // 
            // cbDiaDiem
            // 
            this.cbDiaDiem.BackColor = System.Drawing.Color.Transparent;
            this.cbDiaDiem.BorderColor = System.Drawing.Color.Black;
            this.cbDiaDiem.BorderRadius = 10;
            this.cbDiaDiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDiaDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiaDiem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDiaDiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDiaDiem.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.cbDiaDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbDiaDiem.ItemHeight = 30;
            this.cbDiaDiem.Location = new System.Drawing.Point(177, 241);
            this.cbDiaDiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDiaDiem.Name = "cbDiaDiem";
            this.cbDiaDiem.Size = new System.Drawing.Size(253, 36);
            this.cbDiaDiem.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 48);
            this.label5.TabIndex = 58;
            this.label5.Text = "Địa Điểm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpThoiGianKetThuc
            // 
            this.dtpThoiGianKetThuc.BorderRadius = 10;
            this.dtpThoiGianKetThuc.Checked = true;
            this.dtpThoiGianKetThuc.FillColor = System.Drawing.Color.Magenta;
            this.dtpThoiGianKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGianKetThuc.ForeColor = System.Drawing.Color.White;
            this.dtpThoiGianKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGianKetThuc.Location = new System.Drawing.Point(177, 131);
            this.dtpThoiGianKetThuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpThoiGianKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpThoiGianKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpThoiGianKetThuc.Name = "dtpThoiGianKetThuc";
            this.dtpThoiGianKetThuc.Size = new System.Drawing.Size(253, 34);
            this.dtpThoiGianKetThuc.TabIndex = 57;
            this.dtpThoiGianKetThuc.Value = new System.DateTime(2024, 11, 15, 15, 44, 13, 701);
            // 
            // dtpThoiGianBatDau
            // 
            this.dtpThoiGianBatDau.BorderRadius = 10;
            this.dtpThoiGianBatDau.Checked = true;
            this.dtpThoiGianBatDau.FillColor = System.Drawing.Color.Magenta;
            this.dtpThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGianBatDau.ForeColor = System.Drawing.Color.White;
            this.dtpThoiGianBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGianBatDau.Location = new System.Drawing.Point(177, 80);
            this.dtpThoiGianBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpThoiGianBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpThoiGianBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpThoiGianBatDau.Name = "dtpThoiGianBatDau";
            this.dtpThoiGianBatDau.Size = new System.Drawing.Size(253, 34);
            this.dtpThoiGianBatDau.TabIndex = 56;
            this.dtpThoiGianBatDau.Value = new System.DateTime(2024, 11, 15, 15, 44, 13, 701);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(48, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 44);
            this.label9.TabIndex = 55;
            this.label9.Text = "Thời Gian Kết Thúc";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(48, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 44);
            this.label8.TabIndex = 54;
            this.label8.Text = "Thời Gian Bắt Đầu";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkboxLocTheoThoiGian
            // 
            this.checkboxLocTheoThoiGian.AutoSize = true;
            this.checkboxLocTheoThoiGian.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkboxLocTheoThoiGian.CheckedState.BorderRadius = 0;
            this.checkboxLocTheoThoiGian.CheckedState.BorderThickness = 0;
            this.checkboxLocTheoThoiGian.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkboxLocTheoThoiGian.Location = new System.Drawing.Point(24, 51);
            this.checkboxLocTheoThoiGian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkboxLocTheoThoiGian.Name = "checkboxLocTheoThoiGian";
            this.checkboxLocTheoThoiGian.Size = new System.Drawing.Size(121, 17);
            this.checkboxLocTheoThoiGian.TabIndex = 64;
            this.checkboxLocTheoThoiGian.Text = "Lọc Theo Thời Gian";
            this.checkboxLocTheoThoiGian.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkboxLocTheoThoiGian.UncheckedState.BorderRadius = 0;
            this.checkboxLocTheoThoiGian.UncheckedState.BorderThickness = 0;
            this.checkboxLocTheoThoiGian.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.LightGray;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Image = global::QL_NhaThieuNhi.Properties.Resources.filter;
            this.btnLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoc.Location = new System.Drawing.Point(186, 311);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 58);
            this.btnLoc.TabIndex = 66;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // checkboxLocDiaDiem
            // 
            this.checkboxLocDiaDiem.AutoSize = true;
            this.checkboxLocDiaDiem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkboxLocDiaDiem.CheckedState.BorderRadius = 0;
            this.checkboxLocDiaDiem.CheckedState.BorderThickness = 0;
            this.checkboxLocDiaDiem.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkboxLocDiaDiem.Location = new System.Drawing.Point(24, 209);
            this.checkboxLocDiaDiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkboxLocDiaDiem.Name = "checkboxLocDiaDiem";
            this.checkboxLocDiaDiem.Size = new System.Drawing.Size(118, 17);
            this.checkboxLocDiaDiem.TabIndex = 67;
            this.checkboxLocDiaDiem.Text = "Lọc Theo Địa Điẻm";
            this.checkboxLocDiaDiem.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkboxLocDiaDiem.UncheckedState.BorderRadius = 0;
            this.checkboxLocDiaDiem.UncheckedState.BorderThickness = 0;
            this.checkboxLocDiaDiem.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // FrmLocChuongTrinhNangKhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 405);
            this.Controls.Add(this.checkboxLocDiaDiem);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.checkboxLocTheoThoiGian);
            this.Controls.Add(this.cbDiaDiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpThoiGianKetThuc);
            this.Controls.Add(this.dtpThoiGianBatDau);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "FrmLocChuongTrinhNangKhieu";
            this.Text = "FrmLocChuongTrinhNangKhieu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cbDiaDiem;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThoiGianKetThuc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThoiGianBatDau;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2CheckBox checkboxLocTheoThoiGian;
        private System.Windows.Forms.Button btnLoc;
        private Guna.UI2.WinForms.Guna2CheckBox checkboxLocDiaDiem;
    }
}