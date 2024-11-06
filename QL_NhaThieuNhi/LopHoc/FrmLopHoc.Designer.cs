
namespace QL_NhaThieuNhi.LopHoc
{
    partial class FrmLopHoc
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
            this.btn_delete = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.lb_SoLuongTK = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_print = new Guna.UI2.WinForms.Guna2Button();
            this.btn_edit = new Guna.UI2.WinForms.Guna2Button();
            this.cb_SortBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvLopHoc = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
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
            this.guna2Panel1.Size = new System.Drawing.Size(1518, 89);
            this.guna2Panel1.TabIndex = 1;
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
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
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
            this.btn_addNhanVien.Click += new System.EventHandler(this.btn_addNhanVien_Click);
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
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
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
            // 
            // dgvLopHoc
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLopHoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLopHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLopHoc.ColumnHeadersHeight = 19;
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLopHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.MaNhanVien,
            this.TenLop,
            this.ChuyenMon,
            this.SiSo,
            this.ThoiGianBatDau,
            this.ThoiGianKetThuc,
            this.TrangThai});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLopHoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLopHoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLopHoc.Location = new System.Drawing.Point(12, 110);
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.RowHeadersVisible = false;
            this.dgvLopHoc.RowHeadersWidth = 51;
            this.dgvLopHoc.RowTemplate.Height = 24;
            this.dgvLopHoc.Size = new System.Drawing.Size(1494, 629);
            this.dgvLopHoc.TabIndex = 2;
            this.dgvLopHoc.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLopHoc.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLopHoc.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLopHoc.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLopHoc.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLopHoc.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLopHoc.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLopHoc.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLopHoc.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLopHoc.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLopHoc.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLopHoc.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLopHoc.ThemeStyle.HeaderStyle.Height = 19;
            this.dgvLopHoc.ThemeStyle.ReadOnly = false;
            this.dgvLopHoc.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLopHoc.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLopHoc.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLopHoc.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLopHoc.ThemeStyle.RowsStyle.Height = 24;
            this.dgvLopHoc.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLopHoc.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // TenLop
            // 
            this.TenLop.DataPropertyName = "TenLop";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            // 
            // ChuyenMon
            // 
            this.ChuyenMon.DataPropertyName = "ChuyenMon";
            this.ChuyenMon.HeaderText = "Chuyên Môn";
            this.ChuyenMon.MinimumWidth = 6;
            this.ChuyenMon.Name = "ChuyenMon";
            // 
            // SiSo
            // 
            this.SiSo.DataPropertyName = "SiSo";
            this.SiSo.HeaderText = "Sĩ Số";
            this.SiSo.MinimumWidth = 6;
            this.SiSo.Name = "SiSo";
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.DataPropertyName = "ThoiGianBatDau";
            this.ThoiGianBatDau.HeaderText = "Thời gian Bắt Đầu";
            this.ThoiGianBatDau.MinimumWidth = 6;
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            // 
            // ThoiGianKetThuc
            // 
            this.ThoiGianKetThuc.DataPropertyName = "ThoiGianKetThuc";
            this.ThoiGianKetThuc.HeaderText = "Thời Gian Kết Thúc";
            this.ThoiGianKetThuc.MinimumWidth = 6;
            this.ThoiGianKetThuc.Name = "ThoiGianKetThuc";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            // 
            // FrmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 751);
            this.Controls.Add(this.dgvLopHoc);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FrmLopHoc";
            this.Text = "FrmLopHoc";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btn_delete;
        private Guna.UI2.WinForms.Guna2Button btn_addNhanVien;
        private System.Windows.Forms.Label lb_SoLuongTK;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_print;
        private Guna.UI2.WinForms.Guna2Button btn_edit;
        private Guna.UI2.WinForms.Guna2ComboBox cb_SortBy;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuyenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}