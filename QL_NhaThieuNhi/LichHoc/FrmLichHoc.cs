using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DAL;
using DTO;

namespace QL_NhaThieuNhi.LichHoc
{
    public partial class FrmLichHoc : Form
    {
        private DateTime currentWeekStartDate;
        private DateTime initialWeekStartDate;

        public FrmLichHoc()
        {
            InitializeComponent();
            currentWeekStartDate = GetStartOfWeek(DateTime.Now); // Lấy thứ Hai của tuần hiện tại
            initialWeekStartDate = currentWeekStartDate;  // Set the initial week start date
            InitializeTableLayoutPanel();
            LoadScheduleData();
        }

        //Hàm lấy thứ 2 ngày đầu tuần
        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void InitializeTableLayoutPanel()
        {
            AddHeadersWithDates();
            TableLayout_LichHoc.Controls.Add(CreateTimeSlotLabel("Sáng"), 0, 1);
            TableLayout_LichHoc.Controls.Add(CreateTimeSlotLabel("Chiều"), 0, 2);
            TableLayout_LichHoc.Controls.Add(CreateTimeSlotLabel("Tối"), 0, 3);
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
        private void AddHeadersWithDates()
        {
            DateTime startDate = currentWeekStartDate; 
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Thêm tiêu đề cột đầu tiên là "Time Slot"
            TableLayout_LichHoc.Controls.Add(CreateHeaderLabel("Khung giờ"), 0, 0);

            for (int i = 0; i < daysOfWeek.Length; i++)
            {
                // Tính ngày hiện tại
                DateTime currentDate = startDate.AddDays(i);

                // Tạo tiêu đề với tên ngày và ngày/tháng/năm
                string dayHeader = $"{currentDate.ToString("dddd", new CultureInfo("vi-VN"))}\n{currentDate:dd/MM/yyyy}";

                // Thêm tiêu đề vào cột (bắt đầu từ cột thứ 2: i + 1)
                TableLayout_LichHoc.Controls.Add(CreateHeaderLabel(dayHeader), i + 1, 0);
            }
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
            List<DTO.LichHoc> scheduleData = LichHocDAL.GetLichHocDataForWeek();

            // Kiểm tra dữ liệu lấy được
            foreach (var item in scheduleData)
            {
                Console.WriteLine($"MaLichHoc={item.MaLichHoc}, ThoiGianHoc={item.ThoiGianHoc}, MaCaHoc={item.MaCaHoc}, PhongHoc={item.PhongHoc}");
            }
            TableLayoutPanel table_LichHoc = TableLayout_LichHoc;

            foreach (var item in scheduleData)
            {
                string timeSlot = GetTimeSlot(item.MaCaHoc);
                string dayOfWeek = item.ThoiGianHoc.ToString("dddd", new CultureInfo("vi-VN"));

                int columnIndex = GetColumnIndex(dayOfWeek);
                int rowIndex = GetRowIndex(timeSlot);

                // Kiểm tra việc tính toán cột và hàng
                Console.WriteLine($"Day: {dayOfWeek}, Time Slot: {timeSlot}, Column: {columnIndex}, Row: {rowIndex}");

                if (columnIndex != -1 && rowIndex != -1)
                {
                    // Lấy thông tin tiết học
                    string periodInfo = GetPeriodInfo(item.MaCaHoc);

                    // Kiểm tra nếu LopHoc là null
                    string lopHocInfo = item.LopHoc != null ? $"Tên lớp: {item.LopHoc.TenLop}\n" : "Tên lớp: N/A\n";
                    string phongHocInfo = !string.IsNullOrEmpty(item.PhongHoc) ? $"Phòng: {item.PhongHoc}\n" : "Phòng: N/A\n";
                    string giaoVienInfo = item.LopHoc?.NhanVien != null ? $"Giáo viên: {item.LopHoc.NhanVien.TenNhanVien}\n" : "Giáo viên: N/A\n";

                    // Xác định màu nền dựa trên loại lớp
                    Color backColor = DetermineClassColor(lopHocInfo);

                    // Tạo nhãn cho thông tin lớp học với viền
                    Label classLabel = CreateClassLabel(
                        periodInfo +
                        lopHocInfo +
                        phongHocInfo +
                        giaoVienInfo,
                        backColor);
                    Console.WriteLine($"Adding data: {classLabel.Text} to Column: {columnIndex}, Row: {rowIndex}");
                    // Kiểm tra nếu đã có control trong ô
                    if (table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) != null)
                    {
                        var existingLabel = table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) as Label;
                        existingLabel.Text += "\n" + classLabel.Text;
                    }
                    else
                    {
                        Console.WriteLine($"Adding control at Column: {columnIndex}, Row: {rowIndex}");
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
                case "Thứ hai":
                    return 1;
                case "Thứ ba":
                    return 2;
                case "Thứ tư":
                    return 3;
                case "Thứ năm":
                    return 4;
                case "Thứ sáu":
                    return 5;
                case "Thứ bảy":
                    return 6;
                case "Chủ nhật":
                    return 7;
                default:
                    Console.WriteLine($"Unknown day of the week: {dayOfWeek}");
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
                    Console.WriteLine($"Unknown time slot: {timeSlot}");
                    return -1;
            }
        }

        // Làm mới lịch học
        private void RefreshSchedule()
        {
            TableLayout_LichHoc.Controls.Clear();  
            InitializeTableLayoutPanel(); 
            LoadScheduleData(); 
        }


        private void btn_next_Click(object sender, EventArgs e)
        {
            currentWeekStartDate = currentWeekStartDate.AddDays(7);
            RefreshSchedule();
        }

        private void btn_present_Click(object sender, EventArgs e)
        {
            currentWeekStartDate = GetStartOfWeek(DateTime.Now);
            RefreshSchedule();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DateTime fourWeeksAgo = initialWeekStartDate.AddDays(-28); 

            if (currentWeekStartDate > fourWeeksAgo)
            {
                currentWeekStartDate = currentWeekStartDate.AddDays(-7);
                RefreshSchedule();
            }
            else
            {
                MessageBox.Show("You can only go back up to 4 weeks.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AddManualSchedule()
        {
            // Tạo nhãn cho lớp học thủ công
            string timeSlot = "Chiều"; // Tiết 2
            string dayOfWeek = "Thứ ba"; // Ngày học

            // Thông tin lớp học
            string lopHocInfo = "Tên lớp: Lớp học 1\n";
            string phongHocInfo = "Phòng: P101\n";
            string giaoVienInfo = "Giáo viên: Nguyễn Văn A\n";

            // Màu nền của lớp học
            Color backColor = Color.LightGreen; // Ví dụ: màu xanh nhạt cho lớp Thực hành

            // Tạo label cho tiết học
            Label classLabel = CreateClassLabel(
                timeSlot + "\n" + lopHocInfo + phongHocInfo + giaoVienInfo,
                backColor
            );

            // Tính toán cột và hàng để thêm vào đúng vị trí trong TableLayoutPanel
            int columnIndex = GetColumnIndex(dayOfWeek);  // Lấy chỉ số cột cho Thứ hai
            int rowIndex = GetRowIndex(timeSlot);         // Lấy chỉ số hàng cho Tiết 2 (Chiều)

            // Kiểm tra nếu có nhãn đã có trong ô, nếu không thì thêm nhãn mới vào
            TableLayoutPanel table_LichHoc = TableLayout_LichHoc;
            if (table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) != null)
            {
                var existingLabel = table_LichHoc.GetControlFromPosition(columnIndex, rowIndex) as Label;
                existingLabel.Text += "\n" + classLabel.Text;  // Thêm thông tin vào nhãn hiện có
            }
            else
            {
                // Thêm nhãn vào ô nếu chưa có nhãn
                table_LichHoc.Controls.Add(classLabel, columnIndex, rowIndex);
            }
        }
        private void FrmLichHoc_Load(object sender, EventArgs e)
        {
            AddManualSchedule();
            LoadScheduleData();
        }
    }
}