namespace QL_NhaThieuNhi.LichHoc
{
    partial class FrmLichHoc
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.time = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_present = new Guna.UI2.WinForms.Guna2Button();
            this.btn_back = new Guna.UI2.WinForms.Guna2Button();
            this.btn_next = new Guna.UI2.WinForms.Guna2Button();
            this.TableLayout_LichHoc = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1596, 78);
            this.guna2Panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(665, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "LỊCH HỌC ";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.time);
            this.guna2Panel2.Controls.Add(this.btn_present);
            this.guna2Panel2.Controls.Add(this.btn_back);
            this.guna2Panel2.Controls.Add(this.btn_next);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 78);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1596, 79);
            this.guna2Panel2.TabIndex = 2;
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.Color.Transparent;
            this.time.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.time.BorderRadius = 10;
            this.time.BorderThickness = 1;
            this.time.Checked = true;
            this.time.FillColor = System.Drawing.Color.White;
            this.time.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.time.Location = new System.Drawing.Point(701, 22);
            this.time.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.time.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(317, 36);
            this.time.TabIndex = 3;
            this.time.UseTransparentBackground = true;
            this.time.Value = new System.DateTime(2024, 11, 4, 14, 46, 55, 764);
            // 
            // btn_present
            // 
            this.btn_present.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_present.BorderRadius = 10;
            this.btn_present.BorderThickness = 1;
            this.btn_present.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_present.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_present.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_present.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_present.FillColor = System.Drawing.Color.White;
            this.btn_present.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_present.ForeColor = System.Drawing.Color.Black;
            this.btn_present.Location = new System.Drawing.Point(1079, 18);
            this.btn_present.Name = "btn_present";
            this.btn_present.Size = new System.Drawing.Size(143, 40);
            this.btn_present.TabIndex = 2;
            this.btn_present.Text = "Hiện tại";
            this.btn_present.Click += new System.EventHandler(this.btn_present_Click);
            // 
            // btn_back
            // 
            this.btn_back.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_back.BorderRadius = 10;
            this.btn_back.BorderThickness = 1;
            this.btn_back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_back.FillColor = System.Drawing.Color.White;
            this.btn_back.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.Black;
            this.btn_back.Location = new System.Drawing.Point(1251, 18);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(132, 40);
            this.btn_back.TabIndex = 1;
            this.btn_back.Text = "Trở về";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_next
            // 
            this.btn_next.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_next.BorderRadius = 10;
            this.btn_next.BorderThickness = 1;
            this.btn_next.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_next.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_next.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_next.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_next.FillColor = System.Drawing.Color.White;
            this.btn_next.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.Black;
            this.btn_next.Location = new System.Drawing.Point(1403, 18);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(123, 40);
            this.btn_next.TabIndex = 0;
            this.btn_next.Text = "Tiếp";
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // TableLayout_LichHoc
            // 
            this.TableLayout_LichHoc.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TableLayout_LichHoc.ColumnCount = 8;
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.411215F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            this.TableLayout_LichHoc.Location = new System.Drawing.Point(12, 163);
            this.TableLayout_LichHoc.Name = "TableLayout_LichHoc";
            this.TableLayout_LichHoc.RowCount = 4;
            this.TableLayout_LichHoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.907121F));
            this.TableLayout_LichHoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.66254F));
            this.TableLayout_LichHoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.TableLayout_LichHoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.TableLayout_LichHoc.Size = new System.Drawing.Size(1572, 647);
            this.TableLayout_LichHoc.TabIndex = 3;
            // 
            // FrmLichHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 822);
            this.Controls.Add(this.TableLayout_LichHoc);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLichHoc";
            this.Text = "FrmLichHoc";
            this.Load += new System.EventHandler(this.FrmLichHoc_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker time;
        private Guna.UI2.WinForms.Guna2Button btn_present;
        private Guna.UI2.WinForms.Guna2Button btn_back;
        private Guna.UI2.WinForms.Guna2Button btn_next;
        private System.Windows.Forms.TableLayoutPanel TableLayout_LichHoc;
    }
}