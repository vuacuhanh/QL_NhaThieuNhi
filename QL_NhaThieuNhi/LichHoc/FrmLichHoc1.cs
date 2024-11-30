using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DAL;
using DTO;

namespace QL_NhaThieuNhi.LichHoc
{
    public partial class FrmLichHoc1 : Form
    {
        public FrmLichHoc1()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();
            LoadScheduleData();
        }

        private void InitializeTableLayoutPanel()
        {
            // Create TableLayoutPanel
            TableLayoutPanel table_LichHoc = new TableLayoutPanel
            {
                Name = "table_LichHoc",
                Location = new Point(13, 13),
                Size = new Size(1200, 800),
                ColumnCount = 8, // 1 for Time Slot and 7 for days of the week
                RowCount = 4 // 1 for header and 3 for time slots
            };

            // Set Column and Row styles
            table_LichHoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F)); // Time Slot Column
            for (int i = 1; i < table_LichHoc.ColumnCount; i++)
            {
                table_LichHoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            }
            table_LichHoc.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F)); // Header Row
            for (int i = 1; i < table_LichHoc.RowCount; i++)
            {
                table_LichHoc.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            // Add Headers with Borders
            table_LichHoc.Controls.Add(CreateHeaderLabel("Time Slot"), 0, 0);
            AddDayAndDateHeaders(table_LichHoc, 0);

            // Add Time Slot Labels with Borders
            table_LichHoc.Controls.Add(CreateTimeSlotLabel("Sáng"), 0, 1);
            table_LichHoc.Controls.Add(CreateTimeSlotLabel("Chiều"), 0, 2);
            table_LichHoc.Controls.Add(CreateTimeSlotLabel("Tối"), 0, 3);

            this.Controls.Add(table_LichHoc);
        }

        private Label CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12F, FontStyle.Bold),
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Dock = DockStyle.Fill
            };
        }

        private void AddDayAndDateHeaders(TableLayoutPanel table, int row)
        {
            DateTime startDate = new DateTime(2024, 11, 30); // Example start date
            for (int i = 0; i < 7; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                string headerText = $"{currentDate.ToString("dddd")}\n{currentDate.ToString("dd/MM/yyyy")}";
                Label headerLabel = new Label
                {
                    Text = headerText,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12F, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoSize = false,
                    Dock = DockStyle.Fill
                };
                table.Controls.Add(headerLabel, i + 1, row);
            }
        }

        private Label CreateTimeSlotLabel(string text)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12F, FontStyle.Bold),
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Dock = DockStyle.Fill
            };
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
            // Fetch the schedule data for today from the database
            List<DTO.LichHoc> scheduleData = LichHocDAL.GetLichHocDataForWeek();

            // Get TableLayoutPanel
            TableLayoutPanel table_LichHoc = (TableLayoutPanel)this.Controls["table_LichHoc"];

            foreach (var item in scheduleData)
            {
                string timeSlot = GetTimeSlot(item.MaCaHoc);
                string dayOfWeek = item.ThoiGianHoc.DayOfWeek.ToString();

                int columnIndex = GetColumnIndex(dayOfWeek);
                int rowIndex = GetRowIndex(timeSlot);

                if (columnIndex != -1 && rowIndex != -1)
                {
                    // Fetch period info
                    string periodInfo = GetPeriodInfo(item.MaCaHoc);

                    // Check if LopHoc is null
                    string lopHocInfo = item.LopHoc != null ? $"Tên lớp: {item.LopHoc.TenLop}\n" : "Tên lớp: N/A\n";
                    string phongHocInfo = !string.IsNullOrEmpty(item.PhongHoc) ? $"Phòng: {item.PhongHoc}\n" : "Phòng: N/A\n";
                    string giaoVienInfo = item.LopHoc?.NhanVien != null ? $"Giáo viên: {item.LopHoc.NhanVien.TenNhanVien}\n" : "Giáo viên: N/A\n";

                    // Determine background color based on class type
                    Color backColor = DetermineClassColor(lopHocInfo);

                    // Create label for class info with Border
                    Label classLabel = CreateClassLabel(
                        lopHocInfo +
                        phongHocInfo +
                        giaoVienInfo +
                        periodInfo,
                        backColor);

                    // Check if there is already a control in the cell
                    if (table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) != null)
                    {
                        // Append text to existing control
                        var existingLabel = table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) as Label;
                        existingLabel.Text += "\n" + classLabel.Text;
                    }
                    else
                    {
                        // Add new control to the cell
                        table_LichHoc.Controls.Add(classLabel, columnIndex, rowIndex);
                    }
                }
            }
        }


        private string GetPeriodInfo(int maCaHoc)
        {
            // Fetch period info from database
            CaHoc period = GetPeriodFromDatabase(maCaHoc);
            return $"Tiết: {period.TietHoc}\nThời gian: " +
             $"{(period.ThoiGianBatDau.HasValue ? $"{period.ThoiGianBatDau.Value.Hours:D2}:{period.ThoiGianBatDau.Value.Minutes:D2}" : "N/A")} - " +
             $"{(period.ThoiGianKetThuc.HasValue ? $"{period.ThoiGianKetThuc.Value.Hours:D2}:{period.ThoiGianKetThuc.Value.Minutes:D2}" : "N/A")}\n";

        }


        private CaHoc GetPeriodFromDatabase(int maCaHoc)
        {
            // Simulate fetching from the database
            // Replace this with actual database fetching logic
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
            // Set colors based on the type of class
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
    }
}
