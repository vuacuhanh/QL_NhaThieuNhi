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
    public partial class FrmLichDay : Form
    {
        private TableLayoutPanel table_LichDay;
        private DateTime currentWeekStartDate;
        private LichDayBLL lichDayBLL;

        public FrmLichDay()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();
            LoadScheduleData();
        }

        private void InitializeTableLayoutPanel()
        {
            table_LichDay = new TableLayoutPanel
            {
                Name = "table_LichDay",
                Location = new Point(0, 0),
                Size = new Size(1150, 550),
                ColumnCount = 8,
                RowCount = 4
            };

            table_LichDay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            for (int i = 1; i < table_LichDay.ColumnCount; i++)
            {
                table_LichDay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            }
            table_LichDay.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F)); // Header Row
            for (int i = 1; i < table_LichDay.RowCount; i++)
            {
                table_LichDay.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            table_LichDay.Controls.Add(CreateLabel("Time Slot", Color.AliceBlue, ContentAlignment.MiddleCenter), 0, 0);
            AddDayAndDateHeaders(table_LichDay, 0);

            table_LichDay.Controls.Add(CreateLabel("Sáng", Color.DarkViolet, ContentAlignment.MiddleCenter), 0, 1);
            table_LichDay.Controls.Add(CreateLabel("Chiều", Color.DarkViolet, ContentAlignment.MiddleCenter), 0, 2);
            table_LichDay.Controls.Add(CreateLabel("Tối", Color.DarkViolet, ContentAlignment.MiddleCenter), 0, 3);
            panel_Lich.Controls.Add(table_LichDay);
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

                string dayName = vietnameseCulture.DateTimeFormat.DayNames[(int)currentDate.DayOfWeek];
                dayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dayName);

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

                Label headerLabel = CreateLabel(headerText, Color.AliceBlue, ContentAlignment.MiddleCenter);
                table.Controls.Add(headerLabel, i + 1, row);
            }
        }

        private void LoadScheduleData()
        {
            try
            {
                lichDayBLL = new LichDayBLL();
                UpdateColumnHeaders();
                List<DTO.LichDay> scheduleData = lichDayBLL.GetLichDayForWeek(currentWeekStartDate);

                foreach (var item in scheduleData)
                {
                    string timeSlot = GetTimeSlot(item.MaCaHoc);
                    string dayOfWeek = item.NgayDay.DayOfWeek.ToString();

                    int columnIndex = GetColumnIndex(dayOfWeek);
                    int rowIndex = GetRowIndex(timeSlot);

                    if (columnIndex != -1 && rowIndex != -1)
                    {
                        string periodInfo = GetPeriodInfo(item.MaCaHoc);
                        string lopHocInfo = item.LopHoc != null ? $"Tên lớp: {item.LopHoc.TenLop}\n" : "Tên lớp: N/A\n";
                        string giaoVienInfo = item.NhanVien != null ? $"Giáo viên: {item.NhanVien.TenNhanVien}\n" : "Giáo viên: N/A\n";

                        Color backColor = DetermineClassColor(lopHocInfo);

                        Label classLabel = CreateClassLabel(
                            lopHocInfo +
                            giaoVienInfo +
                            periodInfo,
                            backColor);

                        if (table_LichDay.GetControlFromPosition(columnIndex, rowIndex) != null)
                        {
                            var existingLabel = table_LichDay.GetControlFromPosition(columnIndex, rowIndex) as Label;
                            existingLabel.Text += "\n" + classLabel.Text;
                        }
                        else
                        {
                            table_LichDay.Controls.Add(classLabel, columnIndex, rowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu lịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var headerLabel = table_LichDay.GetControlFromPosition(i + 1, 0) as Label;
                if (headerLabel != null)
                {
                    headerLabel.Text = headerText;
                }
            }
        }

        private void ReloadSchedule()
        {
            for (int row = 1; row < table_LichDay.RowCount; row++)
            {
                for (int col = 1; col < table_LichDay.ColumnCount; col++)
                {
                    var control = table_LichDay.GetControlFromPosition(col, row);
                    if (control != null)
                    {
                        table_LichDay.Controls.Remove(control);
                    }
                }
            }

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
            DateTime minDate = GetStartOfWeek(DateTime.Now, DayOfWeek.Monday).AddDays(-28);
            if (currentWeekStartDate > minDate)
            {
                currentWeekStartDate = currentWeekStartDate.AddDays(-7);
                ReloadSchedule();
                UpdateColumnHeaders();
            }
            else
            {
                MessageBox.Show("Không thể lùi quá 4 tuần từ tuần hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            currentWeekStartDate = currentWeekStartDate.AddDays(7);
            ReloadSchedule();
            UpdateColumnHeaders();
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
                case "Monday": return 1;
                case "Tuesday": return 2;
                case "Wednesday": return 3;
                case "Thursday": return 4;
                case "Friday": return 5;
                case "Saturday": return 6;
                case "Sunday": return 7;
                default: return -1;
            }
        }

        private int GetRowIndex(string timeSlot)
        {
            switch (timeSlot)
            {
                case "Sáng": return 1;
                case "Chiều": return 2;
                case "Tối": return 3;
                default: return -1;
            }
        }

        private string GetPeriodInfo(int maCaHoc)
        {
            switch (maCaHoc)
            {
                case 1: return "Thời gian: 07h00-09h30";
                case 2: return "Thời gian: 09h30-11h30";
                case 3: return "Thời gian: 13h30-15h30";
                case 4: return "Thời gian: 15h30-17h30";
                case 5: return "Thời gian: 18h30-21h00";
                default: return "";
            }
        }

        private Color DetermineClassColor(string className)
        {
            if (className.Contains("Văn"))
                return Color.LightBlue;
            else if (className.Contains("Toán"))
                return Color.LightPink;
            else if (className.Contains("Anh"))
                return Color.LightGreen;
            else
                return Color.PeachPuff;
        }

        private Label CreateClassLabel(string text, Color backColor)
        {
            return new Label
            {
                Text = text,
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10F, FontStyle.Regular)
            };
        }
    }
}
