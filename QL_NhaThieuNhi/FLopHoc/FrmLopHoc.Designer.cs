
namespace QL_NhaThieuNhi.FLopHoc
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
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiemLopHoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExportFileExcel = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_SoLuongTK = new System.Windows.Forms.Label();
            this.btn_print = new Guna.UI2.WinForms.Guna2Button();
            this.cbLocTheoChuyenMon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dtpKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.nbSiSo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrangThai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChuyenMon = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenLop = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnXoaLopHoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemLopHoc = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSuaLopHoc = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaLop = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSiSo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLopHoc
            // 
            this.dgvLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLopHoc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.MaNhanVien,
            this.TenLop,
            this.ChuyenMon,
            this.SiSo,
            this.ThoiGianBatDau,
            this.ThoiGianKetThuc,
            this.TrangThai});
            this.dgvLopHoc.Location = new System.Drawing.Point(590, 109);
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.RowHeadersWidth = 51;
            this.dgvLopHoc.RowTemplate.Height = 24;
            this.dgvLopHoc.Size = new System.Drawing.Size(934, 626);
            this.dgvLopHoc.TabIndex = 0;
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.FillWeight = 115F;
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            this.MaLop.ReadOnly = true;
            this.MaLop.Width = 115;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.ReadOnly = true;
            this.MaNhanVien.Width = 130;
            // 
            // TenLop
            // 
            this.TenLop.DataPropertyName = "TenLop";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.ReadOnly = true;
            this.TenLop.Width = 170;
            // 
            // ChuyenMon
            // 
            this.ChuyenMon.DataPropertyName = "ChuyenMon";
            this.ChuyenMon.HeaderText = "Chuyên Môn";
            this.ChuyenMon.MinimumWidth = 6;
            this.ChuyenMon.Name = "ChuyenMon";
            this.ChuyenMon.ReadOnly = true;
            this.ChuyenMon.Width = 150;
            // 
            // SiSo
            // 
            this.SiSo.DataPropertyName = "SiSo";
            this.SiSo.HeaderText = "Sĩ Số";
            this.SiSo.MinimumWidth = 6;
            this.SiSo.Name = "SiSo";
            this.SiSo.ReadOnly = true;
            this.SiSo.Width = 125;
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.DataPropertyName = "ThoiGianBatDau";
            this.ThoiGianBatDau.HeaderText = "Thời Gian Bắt Đầu";
            this.ThoiGianBatDau.MinimumWidth = 6;
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            this.ThoiGianBatDau.ReadOnly = true;
            this.ThoiGianBatDau.Width = 160;
            // 
            // ThoiGianKetThuc
            // 
            this.ThoiGianKetThuc.DataPropertyName = "ThoiGianKetThuc";
            this.ThoiGianKetThuc.HeaderText = "Thời Gian Kết Thúc";
            this.ThoiGianKetThuc.MinimumWidth = 6;
            this.ThoiGianKetThuc.Name = "ThoiGianKetThuc";
            this.ThoiGianKetThuc.ReadOnly = true;
            this.ThoiGianKetThuc.Width = 160;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 125;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 1;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.txtTimKiemLopHoc);
            this.guna2Panel1.Controls.Add(this.btnExportFileExcel);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.lb_SoLuongTK);
            this.guna2Panel1.Controls.Add(this.btn_print);
            this.guna2Panel1.Controls.Add(this.cbLocTheoChuyenMon);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1518, 89);
            this.guna2Panel1.TabIndex = 1;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Indigo;
            this.guna2Button1.Image = global::QL_NhaThieuNhi.Properties.Resources.search;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(23, 23);
            this.guna2Button1.Location = new System.Drawing.Point(395, 21);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(70, 54);
            this.guna2Button1.TabIndex = 26;
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTimKiemLopHoc
            // 
            this.txtTimKiemLopHoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtTimKiemLopHoc.BorderRadius = 10;
            this.txtTimKiemLopHoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemLopHoc.DefaultText = "";
            this.txtTimKiemLopHoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemLopHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemLopHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemLopHoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemLopHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemLopHoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemLopHoc.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiemLopHoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemLopHoc.Location = new System.Drawing.Point(472, 30);
            this.txtTimKiemLopHoc.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTimKiemLopHoc.Name = "txtTimKiemLopHoc";
            this.txtTimKiemLopHoc.PasswordChar = '\0';
            this.txtTimKiemLopHoc.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiemLopHoc.PlaceholderText = "";
            this.txtTimKiemLopHoc.SelectedText = "";
            this.txtTimKiemLopHoc.Size = new System.Drawing.Size(408, 39);
            this.txtTimKiemLopHoc.TabIndex = 26;
            // 
            // btnExportFileExcel
            // 
            this.btnExportFileExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportFileExcel.BorderRadius = 10;
            this.btnExportFileExcel.BorderThickness = 1;
            this.btnExportFileExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportFileExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportFileExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportFileExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportFileExcel.FillColor = System.Drawing.Color.Transparent;
            this.btnExportFileExcel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnExportFileExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportFileExcel.Image = global::QL_NhaThieuNhi.Properties.Resources.import;
            this.btnExportFileExcel.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExportFileExcel.Location = new System.Drawing.Point(1432, 21);
            this.btnExportFileExcel.Name = "btnExportFileExcel";
            this.btnExportFileExcel.Size = new System.Drawing.Size(62, 45);
            this.btnExportFileExcel.TabIndex = 8;
            this.btnExportFileExcel.Click += new System.EventHandler(this.btnExportFileExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(934, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sắp Xếp:";
            // 
            // lb_SoLuongTK
            // 
            this.lb_SoLuongTK.AutoSize = true;
            this.lb_SoLuongTK.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoLuongTK.Image = global::QL_NhaThieuNhi.Properties.Resources.login2;
            this.lb_SoLuongTK.Location = new System.Drawing.Point(20, 21);
            this.lb_SoLuongTK.Name = "lb_SoLuongTK";
            this.lb_SoLuongTK.Size = new System.Drawing.Size(314, 51);
            this.lb_SoLuongTK.TabIndex = 7;
            this.lb_SoLuongTK.Text = "Quản Lí Lớp Học";
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btn_print.Location = new System.Drawing.Point(1348, 21);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(62, 45);
            this.btn_print.TabIndex = 5;
            // 
            // cbLocTheoChuyenMon
            // 
            this.cbLocTheoChuyenMon.BackColor = System.Drawing.Color.Transparent;
            this.cbLocTheoChuyenMon.BorderColor = System.Drawing.Color.Black;
            this.cbLocTheoChuyenMon.BorderRadius = 10;
            this.cbLocTheoChuyenMon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocTheoChuyenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocTheoChuyenMon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLocTheoChuyenMon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLocTheoChuyenMon.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.cbLocTheoChuyenMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbLocTheoChuyenMon.ItemHeight = 30;
            this.cbLocTheoChuyenMon.Location = new System.Drawing.Point(1048, 30);
            this.cbLocTheoChuyenMon.Name = "cbLocTheoChuyenMon";
            this.cbLocTheoChuyenMon.Size = new System.Drawing.Size(269, 36);
            this.cbLocTheoChuyenMon.TabIndex = 2;
            this.cbLocTheoChuyenMon.SelectedIndexChanged += new System.EventHandler(this.cbLocTheoChuyenMon_SelectedIndexChanged);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2GroupBox1.BackColor = System.Drawing.Color.White;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.btnReset);
            this.guna2GroupBox1.Controls.Add(this.dtpKetThuc);
            this.guna2GroupBox1.Controls.Add(this.dtpBatDau);
            this.guna2GroupBox1.Controls.Add(this.nbSiSo);
            this.guna2GroupBox1.Controls.Add(this.label9);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.txtTrangThai);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.txtChuyenMon);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.txtTenLop);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.txtMaNhanVien);
            this.guna2GroupBox1.Controls.Add(this.BtnXoaLopHoc);
            this.guna2GroupBox1.Controls.Add(this.btnThemLopHoc);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.btnSuaLopHoc);
            this.guna2GroupBox1.Controls.Add(this.txtMaLop);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.MediumOrchid;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 109);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(572, 626);
            this.guna2GroupBox1.TabIndex = 11;
            this.guna2GroupBox1.Text = "Thông Tin Lớp Học";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.BorderRadius = 10;
            this.dtpKetThuc.Checked = true;
            this.dtpKetThuc.FillColor = System.Drawing.Color.Magenta;
            this.dtpKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKetThuc.ForeColor = System.Drawing.Color.White;
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKetThuc.Location = new System.Drawing.Point(174, 387);
            this.dtpKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(374, 39);
            this.dtpKetThuc.TabIndex = 25;
            this.dtpKetThuc.Value = new System.DateTime(2024, 11, 15, 15, 44, 13, 701);
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.BorderRadius = 10;
            this.dtpBatDau.Checked = true;
            this.dtpBatDau.FillColor = System.Drawing.Color.Magenta;
            this.dtpBatDau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBatDau.ForeColor = System.Drawing.Color.White;
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatDau.Location = new System.Drawing.Point(174, 336);
            this.dtpBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(374, 39);
            this.dtpBatDau.TabIndex = 24;
            this.dtpBatDau.Value = new System.DateTime(2024, 11, 15, 15, 44, 13, 701);
            // 
            // nbSiSo
            // 
            this.nbSiSo.BackColor = System.Drawing.Color.Transparent;
            this.nbSiSo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nbSiSo.BorderRadius = 10;
            this.nbSiSo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbSiSo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbSiSo.Location = new System.Drawing.Point(174, 275);
            this.nbSiSo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nbSiSo.Name = "nbSiSo";
            this.nbSiSo.Size = new System.Drawing.Size(374, 38);
            this.nbSiSo.TabIndex = 23;
            this.nbSiSo.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 48);
            this.label9.TabIndex = 22;
            this.label9.Text = "Kết Thúc";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 48);
            this.label8.TabIndex = 20;
            this.label8.Text = "Bắt Đầu";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 48);
            this.label7.TabIndex = 18;
            this.label7.Text = "Sĩ Số";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 48);
            this.label6.TabIndex = 16;
            this.label6.Text = "Trạng Thái";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtTrangThai.BorderRadius = 10;
            this.txtTrangThai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrangThai.DefaultText = "";
            this.txtTrangThai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTrangThai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTrangThai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTrangThai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.ForeColor = System.Drawing.Color.Black;
            this.txtTrangThai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTrangThai.Location = new System.Drawing.Point(174, 438);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.PasswordChar = '\0';
            this.txtTrangThai.PlaceholderText = "";
            this.txtTrangThai.SelectedText = "";
            this.txtTrangThai.Size = new System.Drawing.Size(374, 39);
            this.txtTrangThai.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 48);
            this.label5.TabIndex = 14;
            this.label5.Text = "Chuyên Môn";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuyenMon
            // 
            this.txtChuyenMon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtChuyenMon.BorderRadius = 10;
            this.txtChuyenMon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChuyenMon.DefaultText = "";
            this.txtChuyenMon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChuyenMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChuyenMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChuyenMon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChuyenMon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChuyenMon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuyenMon.ForeColor = System.Drawing.Color.Black;
            this.txtChuyenMon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChuyenMon.Location = new System.Drawing.Point(174, 222);
            this.txtChuyenMon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtChuyenMon.Name = "txtChuyenMon";
            this.txtChuyenMon.PasswordChar = '\0';
            this.txtChuyenMon.PlaceholderText = "";
            this.txtChuyenMon.SelectedText = "";
            this.txtChuyenMon.Size = new System.Drawing.Size(374, 39);
            this.txtChuyenMon.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 48);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tên Lớp";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenLop
            // 
            this.txtTenLop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtTenLop.BorderRadius = 10;
            this.txtTenLop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenLop.DefaultText = "";
            this.txtTenLop.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenLop.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenLop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.ForeColor = System.Drawing.Color.Black;
            this.txtTenLop.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenLop.Location = new System.Drawing.Point(174, 162);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.PasswordChar = '\0';
            this.txtTenLop.PlaceholderText = "";
            this.txtTenLop.SelectedText = "";
            this.txtTenLop.Size = new System.Drawing.Size(374, 39);
            this.txtTenLop.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 48);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã Nhân Viên";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtMaNhanVien.BorderRadius = 10;
            this.txtMaNhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNhanVien.DefaultText = "";
            this.txtMaNhanVien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhanVien.ForeColor = System.Drawing.Color.Black;
            this.txtMaNhanVien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVien.Location = new System.Drawing.Point(174, 111);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.PasswordChar = '\0';
            this.txtMaNhanVien.PlaceholderText = "";
            this.txtMaNhanVien.SelectedText = "";
            this.txtMaNhanVien.Size = new System.Drawing.Size(374, 39);
            this.txtMaNhanVien.TabIndex = 9;
            // 
            // BtnXoaLopHoc
            // 
            this.BtnXoaLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnXoaLopHoc.BorderRadius = 20;
            this.BtnXoaLopHoc.BorderThickness = 1;
            this.BtnXoaLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnXoaLopHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnXoaLopHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnXoaLopHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnXoaLopHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnXoaLopHoc.FillColor = System.Drawing.Color.Transparent;
            this.BtnXoaLopHoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnXoaLopHoc.ForeColor = System.Drawing.Color.Indigo;
            this.BtnXoaLopHoc.Image = global::QL_NhaThieuNhi.Properties.Resources.trash;
            this.BtnXoaLopHoc.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnXoaLopHoc.ImageSize = new System.Drawing.Size(23, 23);
            this.BtnXoaLopHoc.Location = new System.Drawing.Point(174, 527);
            this.BtnXoaLopHoc.Name = "BtnXoaLopHoc";
            this.BtnXoaLopHoc.Size = new System.Drawing.Size(139, 45);
            this.BtnXoaLopHoc.TabIndex = 8;
            this.BtnXoaLopHoc.Text = "DELETE";
            this.BtnXoaLopHoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BtnXoaLopHoc.Click += new System.EventHandler(this.BtnXoaLopHoc_Click);
            // 
            // btnThemLopHoc
            // 
            this.btnThemLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemLopHoc.BorderRadius = 20;
            this.btnThemLopHoc.BorderThickness = 1;
            this.btnThemLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemLopHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLopHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLopHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemLopHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemLopHoc.FillColor = System.Drawing.Color.Transparent;
            this.btnThemLopHoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThemLopHoc.ForeColor = System.Drawing.Color.Indigo;
            this.btnThemLopHoc.Image = global::QL_NhaThieuNhi.Properties.Resources.add;
            this.btnThemLopHoc.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThemLopHoc.ImageSize = new System.Drawing.Size(25, 25);
            this.btnThemLopHoc.Location = new System.Drawing.Point(18, 528);
            this.btnThemLopHoc.Name = "btnThemLopHoc";
            this.btnThemLopHoc.Size = new System.Drawing.Size(140, 45);
            this.btnThemLopHoc.TabIndex = 6;
            this.btnThemLopHoc.Text = "Add";
            this.btnThemLopHoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnThemLopHoc.Click += new System.EventHandler(this.btnThemLopHoc_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Lớp";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSuaLopHoc
            // 
            this.btnSuaLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaLopHoc.BorderRadius = 20;
            this.btnSuaLopHoc.BorderThickness = 1;
            this.btnSuaLopHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaLopHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaLopHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuaLopHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuaLopHoc.FillColor = System.Drawing.Color.Transparent;
            this.btnSuaLopHoc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaLopHoc.ForeColor = System.Drawing.Color.Indigo;
            this.btnSuaLopHoc.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSuaLopHoc.Location = new System.Drawing.Point(330, 527);
            this.btnSuaLopHoc.Name = "btnSuaLopHoc";
            this.btnSuaLopHoc.Size = new System.Drawing.Size(139, 45);
            this.btnSuaLopHoc.TabIndex = 4;
            this.btnSuaLopHoc.Text = "EDIT";
            this.btnSuaLopHoc.Click += new System.EventHandler(this.btnSuaLopHoc_Click);
            // 
            // txtMaLop
            // 
            this.txtMaLop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtMaLop.BorderRadius = 10;
            this.txtMaLop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaLop.DefaultText = "";
            this.txtMaLop.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaLop.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.ForeColor = System.Drawing.Color.Black;
            this.txtMaLop.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaLop.Location = new System.Drawing.Point(174, 60);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.PasswordChar = '\0';
            this.txtMaLop.PlaceholderText = "";
            this.txtMaLop.SelectedText = "";
            this.txtMaLop.Size = new System.Drawing.Size(374, 39);
            this.txtMaLop.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.BorderRadius = 20;
            this.btnReset.BorderThickness = 1;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.Transparent;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Indigo;
            this.btnReset.Image = global::QL_NhaThieuNhi.Properties.Resources.refresh;
            this.btnReset.ImageSize = new System.Drawing.Size(25, 25);
            this.btnReset.Location = new System.Drawing.Point(480, 527);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(68, 45);
            this.btnReset.TabIndex = 35;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 751);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvLopHoc);
            this.Name = "FrmLopHoc";
            this.Text = "FrmLopHoc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbSiSo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuyenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnExportFileExcel;
        private System.Windows.Forms.Label lb_SoLuongTK;
        private Guna.UI2.WinForms.Guna2Button btn_print;
        private Guna.UI2.WinForms.Guna2ComboBox cbLocTheoChuyenMon;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtTrangThai;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtChuyenMon;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtTenLop;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNhanVien;
        private Guna.UI2.WinForms.Guna2Button BtnXoaLopHoc;
        private Guna.UI2.WinForms.Guna2Button btnThemLopHoc;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSuaLopHoc;
        private Guna.UI2.WinForms.Guna2TextBox txtMaLop;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBatDau;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbSiSo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpKetThuc;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemLopHoc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnReset;
    }
}