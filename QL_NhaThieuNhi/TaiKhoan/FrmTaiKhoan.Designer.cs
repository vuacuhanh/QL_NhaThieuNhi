namespace QL_NhaThieuNhi
{
    partial class FrmTaiKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cb_SortBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_SoLuongTK = new System.Windows.Forms.Label();
            this.btn_delete = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btn_print = new Guna.UI2.WinForms.Guna2Button();
            this.btn_edit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btn_delete);
            this.guna2Panel1.Controls.Add(this.btn_addNhanVien);
            this.guna2Panel1.Controls.Add(this.lb_SoLuongTK);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btn_print);
            this.guna2Panel1.Controls.Add(this.btn_edit);
            this.guna2Panel1.Controls.Add(this.cb_SortBy);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1536, 89);
            this.guna2Panel1.TabIndex = 0;
            // 
            // cb_SortBy
            // 
            this.cb_SortBy.BackColor = System.Drawing.Color.Transparent;
            this.cb_SortBy.BorderColor = System.Drawing.Color.Black;
            this.cb_SortBy.BorderRadius = 10;
            this.cb_SortBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_SortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SortBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_SortBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_SortBy.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.cb_SortBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cb_SortBy.ItemHeight = 30;
            this.cb_SortBy.Location = new System.Drawing.Point(266, 28);
            this.cb_SortBy.Name = "cb_SortBy";
            this.cb_SortBy.Size = new System.Drawing.Size(329, 36);
            this.cb_SortBy.TabIndex = 2;
            this.cb_SortBy.SelectedIndexChanged += new System.EventHandler(this.cb_SortBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sort By:";
            // 
            // lb_SoLuongTK
            // 
            this.lb_SoLuongTK.AutoSize = true;
            this.lb_SoLuongTK.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoLuongTK.Location = new System.Drawing.Point(29, 9);
            this.lb_SoLuongTK.Name = "lb_SoLuongTK";
            this.lb_SoLuongTK.Size = new System.Drawing.Size(87, 67);
            this.lb_SoLuongTK.TabIndex = 7;
            this.lb_SoLuongTK.Text = "40";
            // 
            // btn_delete
            // 
            this.btn_delete.BorderRadius = 20;
            this.btn_delete.BorderThickness = 1;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_delete.FillColor = System.Drawing.Color.Transparent;
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.Indigo;
            this.btn_delete.Image = global::QL_NhaThieuNhi.Properties.Resources.trash;
            this.btn_delete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_delete.ImageSize = new System.Drawing.Size(23, 23);
            this.btn_delete.Location = new System.Drawing.Point(1218, 19);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(147, 45);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_addNhanVien
            // 
            this.btn_addNhanVien.BorderRadius = 20;
            this.btn_addNhanVien.BorderThickness = 1;
            this.btn_addNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_addNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_addNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_addNhanVien.FillColor = System.Drawing.Color.Transparent;
            this.btn_addNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_addNhanVien.ForeColor = System.Drawing.Color.Indigo;
            this.btn_addNhanVien.Image = global::QL_NhaThieuNhi.Properties.Resources.add;
            this.btn_addNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_addNhanVien.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_addNhanVien.Location = new System.Drawing.Point(1087, 19);
            this.btn_addNhanVien.Name = "btn_addNhanVien";
            this.btn_addNhanVien.Size = new System.Drawing.Size(112, 45);
            this.btn_addNhanVien.TabIndex = 6;
            this.btn_addNhanVien.Text = "Add";
            this.btn_addNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_print
            // 
            this.btn_print.BorderRadius = 10;
            this.btn_print.BorderThickness = 1;
            this.btn_print.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_print.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_print.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_print.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_print.FillColor = System.Drawing.Color.Transparent;
            this.btn_print.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_print.ForeColor = System.Drawing.Color.Black;
            this.btn_print.Image = global::QL_NhaThieuNhi.Properties.Resources.printing;
            this.btn_print.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_print.Location = new System.Drawing.Point(842, 19);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(62, 45);
            this.btn_print.TabIndex = 5;
            // 
            // btn_edit
            // 
            this.btn_edit.BorderRadius = 20;
            this.btn_edit.BorderThickness = 1;
            this.btn_edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_edit.FillColor = System.Drawing.Color.Transparent;
            this.btn_edit.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.Indigo;
            this.btn_edit.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_edit.Location = new System.Drawing.Point(929, 19);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(139, 45);
            this.btn_edit.TabIndex = 4;
            this.btn_edit.Text = "EDIT";
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(191)))), ((int)(((byte)(231)))));
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.MaTaiKhoan,
            this.TenDangNhap,
            this.MatKhau,
            this.MaQuyen});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(212)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(111)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.White;
            this.guna2DataGridView1.Location = new System.Drawing.Point(12, 109);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1512, 626);
            this.guna2DataGridView1.TabIndex = 9;
            this.guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Purple;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(191)))), ((int)(((byte)(231)))));
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 20;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(212)))), ((int)(((byte)(239)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(111)))), ((int)(((byte)(202)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // MaTaiKhoan
            // 
            this.MaTaiKhoan.DataPropertyName = "MaTaiKhoan";
            this.MaTaiKhoan.HeaderText = "Account ID";
            this.MaTaiKhoan.MinimumWidth = 6;
            this.MaTaiKhoan.Name = "MaTaiKhoan";
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.DataPropertyName = "TenDangNhap";
            this.TenDangNhap.HeaderText = "User Name";
            this.TenDangNhap.MinimumWidth = 6;
            this.TenDangNhap.Name = "TenDangNhap";
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Password";
            this.MatKhau.MinimumWidth = 6;
            this.MatKhau.Name = "MatKhau";
            // 
            // MaQuyen
            // 
            this.MaQuyen.DataPropertyName = "MaQuyen";
            this.MaQuyen.HeaderText = "Role ID";
            this.MaQuyen.MinimumWidth = 6;
            this.MaQuyen.Name = "MaQuyen";
            this.MaQuyen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FrmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 798);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaiKhoan";
            this.Text = "FrmTaiKhoan";
            this.Load += new System.EventHandler(this.FrmTaiKhoan_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cb_SortBy;
        private Guna.UI2.WinForms.Guna2Button btn_print;
        private Guna.UI2.WinForms.Guna2Button btn_edit;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private System.Windows.Forms.Label lb_SoLuongTK;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_delete;
        private Guna.UI2.WinForms.Guna2Button btn_addNhanVien;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQuyen;
    }
}