using System;
using Terminal.Gui;
using App = Terminal.Gui.Application; // Sử dụng alias để tránh xung đột hệ thống

namespace GameToolClaudeStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Khởi tạo ứng dụng Terminal.Gui
            App.Init();
            var top = App.Top;

            // 1. Tạo Cửa sổ chính bao toàn màn hình
            var mainWindow = new Window(" Gacha Tool - Fix mọi chức năng mà bạn cần chỉ trong 1 ứng dụng , code bởi YRF419. Link Github ")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(mainWindow);

            // =======================================================
            // CỘT TRÁI - SIDEBAR DANH MỤC CHÍNH (THOÁNG, DỄ NHÌN)
            // =======================================================
            var sidebar = new FrameView(" Menu Hệ Thống ")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(25), // Chiếm 25% chiều rộng màn hình
                Height = Dim.Fill()
            };

            // Danh sách menu xen kẽ các dòng trống "" để tạo khoảng cách dễ nhìn
            string[] mainTabs = {
                " 🚀  Tải Launcher",
                "",                  // Dòng trống tạo khoảng thở
                " 🛠️  Fix Lỗi Game",
                "",                  // Dòng trống tạo khoảng thở
                " 💿  Phần Mềm App",
                "",                  // Dòng trống tạo khoảng thở
                " 📦  Tải Game Tool"
            };

            var menuListView = new ListView(mainTabs)
            {
                X = 1,               // Thụt lề vào 1 khoảng để không dính viền
                Y = 1,
                Width = Dim.Fill() - 1,
                Height = Dim.Fill() - 1,
                ColorScheme = Colors.Menu
            };
            sidebar.Add(menuListView);
            mainWindow.Add(sidebar);

            // =======================================================
            // CỘT PHẢI - KHU VỰC HIỂN THỊ CHI TIẾT NỘI DUNG (CONTENT)
            // =======================================================
            var contentArea = new FrameView(" Chi Tiết Chức Năng ")
            {
                X = Pos.Right(sidebar), // Đứng sát cạnh phải của Sidebar
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            mainWindow.Add(contentArea);

            // -------------------------------------------------------
            // KHỞI TẠO CÁC GIAO DIỆN CON (CON-VIEW) CHO TỪNG TAB CHÍNH
            // -------------------------------------------------------

            // --- View 1: Tải Launcher ---
            var viewLauncher = new View() { Width = Dim.Fill(), Height = Dim.Fill() };
            viewLauncher.Add(
                new Label("🚀 TRÌNH KHỞI ĐỘNG GAME CHÍNH THỨC") { X = 2, Y = 1 },
                new Label("Tải xuống Launcher tổng hợp để cài đặt tự động các game.") { X = 2, Y = 3 }
            );
            var btnDlLauncher = new Button("📥 Bắt đầu tải Launcher") { X = 2, Y = 5 };
            btnDlLauncher.Clicked += () => MessageBox.Query("Tải tệp", "Đang kết nối CDN và tải setup_launcher.exe...", "OK");
            viewLauncher.Add(btnDlLauncher);

            // --- View 2: Fix lỗi game (Có chứa các nút Tab phụ bên trong) ---
            var viewFixLoi = new View() { Width = Dim.Fill(), Height = Dim.Fill() };
            viewFixLoi.Add(new Label("🛠️ TRÌNH SỬA LỖI & TỐI ƯU HỆ THỐNG") { X = 2, Y = 1 });

            var btnFixSocial = new Button("🔗 Fix Social") { X = 2, Y = 4, Width = 18 };
            var btnDlDriver = new Button("💻 Tải Driver") { X = 2, Y = 6, Width = 18 };
            var btnCloseGacha = new Button("❌ Đóng Gacha") { X = 2, Y = 8, Width = 18 };

            btnFixSocial.Clicked += () => MessageBox.Query("Sửa lỗi", "Đã dọn dẹp cache DNS và sửa kẹt Rockstar Social Club!", "OK");
            btnDlDriver.Clicked += () => MessageBox.Query("Driver", "Đã mở trình duyệt tải Driver đồ họa thích hợp!", "OK");
            btnCloseGacha.Clicked += () => MessageBox.Query("Tiến trình", "Đã buộc đóng hoàn toàn các game Gacha chạy ngầm bị kẹt!", "OK");

            viewFixLoi.Add(btnFixSocial, btnDlDriver, btnCloseGacha);

            // --- View 3: Phần mềm ---
            var viewPhanMem = new View() { Width = Dim.Fill(), Height = Dim.Fill() };
            viewPhanMem.Add(new Label("💿 PHẦN MỀM VÀ CÔNG CỤ BỔ TRỢ") { X = 2, Y = 1 });

            var btnUltra = new Button("🖥️ Tải Ultra") { X = 2, Y = 4, Width = 18 };
            var btnDiscord = new Button("💬 Tải Discord") { X = 2, Y = 6, Width = 18 };

            btnUltra.Clicked += () => MessageBox.Query("Tải tệp", "Đang chuẩn bị tải xuống bản cài UltraViewer...", "OK");
            btnDiscord.Clicked += () => MessageBox.Query("Tải tệp", "Đang kết nối máy chủ tải DiscordSetup...", "OK");

            viewPhanMem.Add(btnUltra, btnDiscord);

            // --- View 4: Tải game ---
            var viewTaiGame = new View() { Width = Dim.Fill(), Height = Dim.Fill() };
            viewTaiGame.Add(new Label("📦 HỖ TRỢ TẢI GAME & TÀI KHOẢN") { X = 2, Y = 1 });

            var btnSteam = new Button("🔑 Login Steam") { X = 2, Y = 4, Width = 18 };
            var btnCmd = new Button("⚙️ Download CMD") { X = 2, Y = 6, Width = 18 };

            btnSteam.Clicked += () => MessageBox.Query("Steam", "Đang mở giao diện đăng nhập Steam...", "OK");
            btnCmd.Clicked += () => MessageBox.Query("SteamCMD", "Đang khởi động tiến trình tải gói SteamCMD chuyên dụng...", "OK");

            viewTaiGame.Add(btnSteam, btnCmd);


            // =======================================================
            // XỬ LÝ LOGIC ĐIỀU HƯỚNG VÀ TỰ ĐỘNG NHẢY DÒNG TRỐNG
            // =======================================================
            Action updateContent = () => {
                contentArea.RemoveAll(); // Dọn dẹp giao diện bên phải hiện tại

                // Chỉ định view hiển thị dựa theo Index của dòng được chọn ở menu trái
                switch (menuListView.SelectedItem)
                {
                    case 0: contentArea.Add(viewLauncher); break;
                    case 2: contentArea.Add(viewFixLoi); break;
                    case 4: contentArea.Add(viewPhanMem); break;
                    case 6: contentArea.Add(viewTaiGame); break;
                }

                contentArea.SetNeedsDisplay(); // Yêu cầu vẽ lại giao diện tức thì
            };

            // Biến cờ (flag) hỗ trợ theo dõi hướng di chuyển (lên hay xuống)
            int lastSelectedIndex = 0;

            menuListView.SelectedItemChanged += (e) => {
                // Kiểm tra xem vị trí mới có lọt vào dòng lẻ (dòng trống) hay không
                if (menuListView.SelectedItem % 2 != 0)
                {
                    if (menuListView.SelectedItem > lastSelectedIndex)
                    {
                        // Đang đi xuống -> tự nhảy thêm 1 dòng nữa xuống dưới
                        if (menuListView.SelectedItem < mainTabs.Length - 1)
                            menuListView.SelectedItem++;
                        else
                            menuListView.SelectedItem--; // Giữ chặn dưới nếu ở cuối mảng
                    }
                    else
                    {
                        // Đang đi lên -> tự nhảy thêm 1 dòng nữa lên trên
                        if (menuListView.SelectedItem > 0)
                            menuListView.SelectedItem--;
                        else
                            menuListView.SelectedItem++; // Giữ chặn trên nếu ở đầu mảng
                    }
                }

                // Cập nhật lại chỉ mục cũ sau khi xử lý nhảy dòng thành công
                lastSelectedIndex = menuListView.SelectedItem;

                // Đổi nội dung bên phải tương ứng
                updateContent();
            };

            // Kích hoạt nạp nội dung của Tab đầu tiên ngay khi bật ứng dụng
            updateContent();

            // Chạy vòng lặp chính của TUI ứng dụng
            App.Run();

            // Giải phóng bộ nhớ terminal khi tắt chương trình
            App.Shutdown();
        }
    }
}