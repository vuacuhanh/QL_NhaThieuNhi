using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using DAL;
using DTO;

namespace QL_NhaThieuNhi.LichHoc
{
    public partial class FrmLichHoc : Form
    {
        private TableLayoutPanel table_LichHoc;
        private DateTime currentWeekStartDate;
        private LichHocBLL LichHocBLL;
        public FrmLichHoc()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();     
            LoadScheduleData();
        }

        private void InitializeTableLayoutPanel()
        {
            table_LichHoc = new TableLayoutPanel
            {
                Name = "table_LichHoc",
                Location = new Point(0, 0),
                Size = new Size(1150, 550),
                ColumnCount = 8,
                RowCount = 4
            };

            table_LichHoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            for (int i = 1; i < table_LichHoc.ColumnCount; i++)
            {
                table_LichHoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            }
            table_LichHoc.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F)); // Header Row
            for (int i = 1; i < table_LichHoc.RowCount; i++)
            {
                table_LichHoc.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            table_LichHoc.Controls.Add(CreateLabel("Time Slot", Color.AliceBlue, ContentAlignment.MiddleCenter), 0, 0);
            AddDayAndDateHeaders(table_LichHoc, 0);

            table_LichHoc.Controls.Add(CreateLabel("Sáng", Color.DarkViolet, ContentAlignment.MiddleCenter), 0, 1);
            table_LichHoc.Controls.Add(CreateLabel("Chiều", Color.DarkViolet, ContentAlignment.MiddleCenter), 0, 2);
            table_LichHoc.Controls.Add(CreateLabel("Tối", Color.DarkViolet, ContentAlignment.MiddleCenter), 0, 3);
            panel_Lich.Controls.Add(table_LichHoc);
        }

        private Label CreateLabel(string text, Color backColor, ContentAlignment textAlign)
        {
            return new Label
            {
                Text = text,
                TextAlign = textAlign,
                Font = new Font("Arial", 12F, FontStyle.Bold),
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Dock = DockStyle.Fill
            };
        }
        private DateTime GetStartOfWeek(DateTime date, DayOfWeek startOfWeek)
        {
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-diff).Date;
        }

        private void AddDayAndDateHeaders(TableLayoutPanel table, int row)
        {
            currentWeekStartDate = GetStartOfWeek(DateTime.Now, DayOfWeek.Monday);
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDate = currentWeekStartDate.AddDays(i);

                // Lấy tên thứ và viết hoa chữ cái đầu
                string dayName = vietnameseCulture.DateTimeFormat.DayNames[(int)currentDate.DayOfWeek];
                dayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dayName);

                // Thay thế các ngày bằng tên chính xác
                switch (dayName)
                {
                    case "Monday":
                        dayName = "Thứ Hai";
                        break;
                    case "Tuesday":
                        dayName = "Thứ Ba";
                        break;
                    case "Wednesday":
                        dayName = "Thứ Tư";
                        break;
                    case "Thursday":
                        dayName = "Thứ Năm";
                        break;
                    case "Friday":
                        dayName = "Thứ Sáu";
                        break;
                    case "Saturday":
                        dayName = "Thứ Bảy";
                        break;
                    case "Sunday":
                        dayName = "Chủ Nhật";
                        break;
                }

                string headerText = $"{dayName}\n{currentDate:dd/MM/yyyy}";

                Label headerLabel = CreateLabel(headerText, Color.AliceBlue, ContentAlignment.MiddleCenter);
                table.Controls.Add(headerLabel, i + 1, row);
            }
        }

        private void UpdateColumnHeaders()
        {
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDate = currentWeekStartDate.AddDays(i);

                string dayName = vietnameseCulture.DateTimeFormat.DayNames[(int)currentDate.DayOfWeek];
                dayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dayName);

                // Thay thế các ngày bằng tên chính xác
                switch (dayName)
                {
                    case "Monday": dayName = "Thứ Hai"; break;
                    case "Tuesday": dayName = "Thứ Ba"; break;
                    case "Wednesday": dayName = "Thứ Tư"; break;
                    case "Thursday": dayName = "Thứ Năm"; break;
                    case "Friday": dayName = "Thứ Sáu"; break;
                    case "Saturday": dayName = "Thứ Bảy"; break;
                    case "Sunday": dayName = "Chủ Nhật"; break;
                }

                string headerText = $"{dayName}\n{currentDate:dd/MM/yyyy}";

                // Tìm và cập nhật header label
                var headerLabel = table_LichHoc.GetControlFromPosition(i + 1, 0) as Label;
                if (headerLabel != null)
                {
                    headerLabel.Text = headerText;
                }
            }
        }



        private Label CreateClassLabel(string text, Color backColor)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 10F),
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Dock = DockStyle.Fill
            };
        }

        private void LoadScheduleData()
        {
            try
            {
                LichHocBLL = new LichHocBLL();
                UpdateColumnHeaders();
                List<DTO.LichHoc> scheduleData = LichHocBLL.GetLichHocForWeek(currentWeekStartDate);

                foreach (var item in scheduleData)
                {
                    string timeSlot = GetTimeSlot(item.MaCaHoc);
                    string dayOfWeek = item.ThoiGianHoc.DayOfWeek.ToString();

                    int columnIndex = GetColumnIndex(dayOfWeek);
                    int rowIndex = GetRowIndex(timeSlot);

                    if (columnIndex != -1 && rowIndex != -1)
                    {
                        string periodInfo = GetPeriodInfo(item.MaCaHoc);
                        string lopHocInfo = item.LopHoc != null ? $"Tên lớp: {item.LopHoc.TenLop}\n" : "Tên lớp: N/A\n";
                        string phongHocInfo = !string.IsNullOrEmpty(item.PhongHoc) ? $"Phòng: {item.PhongHoc}\n" : "Phòng: N/A\n";
                        string giaoVienInfo = item.LopHoc?.NhanVien != null ? $"Giáo viên: {item.LopHoc.NhanVien.TenNhanVien}\n" : "Giáo viên: N/A\n";

                        Color backColor = DetermineClassColor(lopHocInfo);

                        Label classLabel = CreateClassLabel(
                            lopHocInfo +
                            phongHocInfo +
                            giaoVienInfo +
                            periodInfo,
                            backColor);

                        if (table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) != null)
                        {
                            var existingLabel = table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) as Label;
                            existingLabel.Text += "\n" + classLabel.Text;
                        }
                        else
                        {
                            table_LichHoc.Controls.Add(classLabel, columnIndex, rowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu lịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetPeriodInfo(int maCaHoc)
        {
            CaHoc period = GetPeriodFromDatabase(maCaHoc);
            return $"Tiết: {period.TietHoc}\nThời gian: " +
             $"{(period.ThoiGianBatDau.HasValue ? $"{period.ThoiGianBatDau.Value.Hours:D2}:{period.ThoiGianBatDau.Value.Minutes:D2}" : "N/A")} - " +
             $"{(period.ThoiGianKetThuc.HasValue ? $"{period.ThoiGianKetThuc.Value.Hours:D2}:{period.ThoiGianKetThuc.Value.Minutes:D2}" : "N/A")}\n";
        }

        private CaHoc GetPeriodFromDatabase(int maCaHoc)
        {
            var periods = new List<CaHoc>
            {
                new CaHoc { MaCaHoc = 1, TietHoc = "Tiết 1", ThoiGianBatDau = new TimeSpan(8, 0, 0), ThoiGianKetThuc = new TimeSpan(9, 30, 0) },
                new CaHoc { MaCaHoc = 2, TietHoc = "Tiết 2", ThoiGianBatDau = new TimeSpan(9, 45, 0), ThoiGianKetThuc = new TimeSpan(11, 15, 0) },
                new CaHoc { MaCaHoc = 3, TietHoc = "Tiết 3", ThoiGianBatDau = new TimeSpan(13, 0, 0), ThoiGianKetThuc = new TimeSpan(14, 30, 0) },
                new CaHoc { MaCaHoc = 4, TietHoc = "Tiết 4", ThoiGianBatDau = new TimeSpan(14, 45, 0), ThoiGianKetThuc = new TimeSpan(16, 15, 0) },
                new CaHoc { MaCaHoc = 5, TietHoc = "Tiết 5", ThoiGianBatDau = new TimeSpan(16, 30, 0), ThoiGianKetThuc = new TimeSpan(18, 0, 0) }
            };
            return periods.Find(p => p.MaCaHoc == maCaHoc);
        }

        private Color DetermineClassColor(string className)
        {
            if (className.Contains("Thực hành"))
            {
                return Color.LightGreen;
            }
            else if (className.Contains("Trực tuyến"))
            {
                return Color.LightBlue;
            }
            else if (className.Contains("Thi"))
            {
                return Color.LightYellow;
            }
            else
            {
                return Color.White;
            }
        }

        private string GetTimeSlot(int maCaHoc)
        {
            switch (maCaHoc)
            {
                case 1:
                case 2:
                    return "Sáng";
                case 3:
                case 4:
                    return "Chiều";
                case 5:
                    return "Tối";
                default:
                    return "";
            }
        }


        private int GetColumnIndex(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "Monday":
                    return 1;
                case "Tuesday":
                    return 2;
                case "Wednesday":
                    return 3;
                case "Thursday":
                    return 4;
                case "Friday":
                    return 5;
                case "Saturday":
                    return 6;
                case "Sunday":
                    return 7;
                default:
                    return -1;
            }
        }

        private int GetRowIndex(string timeSlot)
        {
            switch (timeSlot)
            {
                case "Sáng":
                    return 1;
                case "Chiều":
                    return 2;
                case "Tối":
                    return 3;
                default:
                    return -1;
            }
        }
        private void ReloadSchedule()
        {
            // Chỉ xóa dữ liệu cũ (bỏ qua hàng header và cột thời gian)
            for (int row = 1; row < table_LichHoc.RowCount; row++)
            {
                for (int col = 1; col < table_LichHoc.ColumnCount; col++)
                {
                    var control = table_LichHoc.GetControlFromPosition(col, row);
                    if (control != null)
                    {
                        table_LichHoc.Controls.Remove(control);
                    }
                }
            }

            // Tải lại dữ liệu mới
            LoadScheduleData();
        }

        private void btn_present_Click(object sender, EventArgs e)
        {
            currentWeekStartDate = GetStartOfWeek(DateTime.Now, DayOfWeek.Monday);
            ReloadSchedule();
            UpdateColumnHeaders();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DateTime minDate = GetStartOfWeek(DateTime.Now, DayOfWeek.Monday).AddDays(-28); // 4 tuần trước
            if (currentWeekStartDate > minDate)
            {
                currentWeekStartDate = currentWeekStartDate.AddDays(-7); // Lùi 1 tuần
                ReloadSchedule();
                UpdateColumnHeaders(); // Cập nhật tiêu đề cột
            }
            else
            {
                MessageBox.Show("Không thể lùi quá 4 tuần từ tuần hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            currentWeekStartDate = currentWeekStartDate.AddDays(7); // Tiến 1 tuần
            ReloadSchedule();
            UpdateColumnHeaders();
        }
    }
}
