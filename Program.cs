using System;
using System.Threading.Tasks;
using Terminal.Gui;
using App = Terminal.Gui.Application;
using TerminalAttribute = Terminal.Gui.Attribute;

namespace GameToolClaudeStyle
{
    class Program
    {
        private static Label dynamicTitleLabel;
        private static string currentTargetTitle = "";

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            App.Init();
            var top = App.Top;

            // =======================================================
            // 🎨 THIẾT LẬP BẢNG MÀU PHẢN HỒI MẠNH
            // =======================================================
            var darkTheme = new ColorScheme()
            {
                Normal = TerminalAttribute.Make(Color.White, Color.Black),
                Focus = TerminalAttribute.Make(Color.BrightYellow, Color.DarkGray),
                HotNormal = TerminalAttribute.Make(Color.BrightCyan, Color.Black),
                HotFocus = TerminalAttribute.Make(Color.BrightCyan, Color.DarkGray)
            };

            var graySidebarTheme = new ColorScheme()
            {
                Normal = TerminalAttribute.Make(Color.Black, Color.Gray),
                Focus = TerminalAttribute.Make(Color.BrightCyan, Color.DarkGray),
                HotNormal = TerminalAttribute.Make(Color.DarkGray, Color.Gray),
                HotFocus = TerminalAttribute.Make(Color.BrightCyan, Color.DarkGray)
            };

            top.ColorScheme = darkTheme;

            // 1. Cửa sổ chính bao toàn màn hình (Sửa Height thành Dim.Fill())
            var mainWindow = new Window(" Gacha Tool - code bởi YRF419. Link Github https://github.com/FrySimpl3/Gacha_Tool_Console ")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(), // Đã sửa từ Dim.Fill() - 1 thành Dim.Fill() để chiếm trọn màn hình
                ColorScheme = darkTheme
            };
            top.Add(mainWindow);

            // =======================================================
            // CỘT TRÁI - SIDEBAR MENU
            // =======================================================
            var sidebar = new FrameView(" Menu Hệ Thống ")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(25),
                Height = Dim.Fill(),
                ColorScheme = graySidebarTheme
            };

            string[] mainTabs = {
                " ►  Tải Launcher", "",
                " ►  Fix Lỗi Game",  "",
                " ►  Phần Mềm App",  "",
                " ►  Tải Game Tool"
            };

            var menuListView = new ListView(mainTabs)
            {
                X = 1,
                Y = 1,
                Width = Dim.Fill() - 1,
                Height = Dim.Fill() - 1,
                ColorScheme = graySidebarTheme
            };
            sidebar.Add(menuListView);
            mainWindow.Add(sidebar);

            // =======================================================
            // CỘT PHẢI - NỘI DUNG VÀ THAY ĐỔI CÁCH HIỂN THỊ NÚT
            // =======================================================
            var contentArea = new FrameView(" Chi Tiết Chức Năng (Bấm Tab để chọn nút) ")
            {
                X = Pos.Right(sidebar),
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                ColorScheme = darkTheme
            };
            mainWindow.Add(contentArea);

            dynamicTitleLabel = new Label("") { X = 2, Y = 1, ColorScheme = darkTheme };

            // --- View 1: Tải Launcher ---
            var viewLauncher = new View() { Width = Dim.Fill(), Height = Dim.Fill(), ColorScheme = darkTheme };
            viewLauncher.Add(new Label("Tải xuống Launcher tổng hợp để cài đặt tự động các game.") { X = 2, Y = 3 });
            var btnDlLauncher = new Button(" ► Bắt đầu tải Launcher ") { X = 2, Y = 5, ColorScheme = darkTheme };
            btnDlLauncher.Clicked += () => MessageBox.Query("Tải tệp", "Đang kết nối CDN và tải setup_launcher.exe...", "OK");
            viewLauncher.Add(btnDlLauncher);

            // --- View 2: Fix lỗi game ---
            var viewFixLoi = new View() { Width = Dim.Fill(), Height = Dim.Fill(), ColorScheme = darkTheme };
            var btnFixSocial = new Button(" ► Fix Social ") { X = 2, Y = 4, Width = 22, ColorScheme = darkTheme };
            var btnDlDriver = new Button(" ► Tải Driver ") { X = 2, Y = 6, Width = 22, ColorScheme = darkTheme };
            var btnCloseGacha = new Button(" ► Đóng Gacha ") { X = 2, Y = 8, Width = 22, ColorScheme = darkTheme };

            btnFixSocial.Clicked += () => MessageBox.Query("Sửa lỗi", "Đã dọn dẹp cache DNS và sửa kẹt Rockstar Social Club!", "OK");
            btnDlDriver.Clicked += () => MessageBox.Query("Driver", "Đã mở trình duyệt tải Driver đồ họa thích hợp!", "OK");
            btnCloseGacha.Clicked += () => MessageBox.Query("Tiến trình", "Đã buộc đóng hoàn toàn các game Gacha chạy ngầm bị kẹt!", "OK");
            viewFixLoi.Add(btnFixSocial, btnDlDriver, btnCloseGacha);

            // --- View 3: Phần mềm ---
            var viewPhanMem = new View() { Width = Dim.Fill(), Height = Dim.Fill(), ColorScheme = darkTheme };
            var btnUltra = new Button(" ► Tải Ultra ") { X = 2, Y = 4, Width = 22, ColorScheme = darkTheme };
            var btnDiscord = new Button(" ► Tải Discord ") { X = 2, Y = 6, Width = 22, ColorScheme = darkTheme };

            btnUltra.Clicked += () => MessageBox.Query("Tải tệp", "Đang chuẩn bị tải xuống bản cài UltraViewer...", "OK");
            btnDiscord.Clicked += () => MessageBox.Query("Tải tệp", "Đang kết nối máy chủ tải DiscordSetup...", "OK");
            viewPhanMem.Add(btnUltra, btnDiscord);

            // --- View 4: Tải game ---
            var viewTaiGame = new View() { Width = Dim.Fill(), Height = Dim.Fill(), ColorScheme = darkTheme };
            var btnSteam = new Button(" ► Login Steam ") { X = 2, Y = 4, Width = 22, ColorScheme = darkTheme };
            var btnCmd = new Button(" ► Download CMD ") { X = 2, Y = 6, Width = 22, ColorScheme = darkTheme };

            btnSteam.Clicked += () => MessageBox.Query("Steam", "Đang mở giao diện đăng nhập Steam...", "OK");
            btnCmd.Clicked += () => MessageBox.Query("SteamCMD", "Đang khởi động tiến trình tải gói SteamCMD chuyên dụng...", "OK");
            viewTaiGame.Add(btnSteam, btnCmd);

            // =======================================================
            // LOGIC ĐIỀU HƯỚNG
            // =======================================================
            Action updateContent = () => {
                contentArea.RemoveAll();
                contentArea.Add(dynamicTitleLabel);

                switch (menuListView.SelectedItem)
                {
                    case 0: currentTargetTitle = " TRÌNH KHỞI ĐỘNG GAME CHÍNH THỨC"; contentArea.Add(viewLauncher); break;
                    case 2: currentTargetTitle = " TRÌNH SỬA LỖI & TỐI ƯU HỆ THỐNG"; contentArea.Add(viewFixLoi); break;
                    case 4: currentTargetTitle = " PHẦN MỀM VÀ CÔNG CỤ BỔ TRỢ"; contentArea.Add(viewPhanMem); break;
                    case 6: currentTargetTitle = " HỖ TRỢ TẢI GAME & TÀI KHOẢN"; contentArea.Add(viewTaiGame); break;
                }
                TriggerTypewriterEffect(currentTargetTitle);
            };

            int lastSelectedIndex = 0;
            menuListView.SelectedItemChanged += (e) => {
                if (menuListView.SelectedItem % 2 != 0)
                {
                    if (menuListView.SelectedItem > lastSelectedIndex) { if (menuListView.SelectedItem < mainTabs.Length - 1) menuListView.SelectedItem++; else menuListView.SelectedItem--; }
                    else { if (menuListView.SelectedItem > 0) menuListView.SelectedItem--; else menuListView.SelectedItem++; }
                }
                lastSelectedIndex = menuListView.SelectedItem;
                updateContent();
            };

            updateContent();

            // Đã xóa hoàn toàn đoạn khởi tạo và top.Add(statusBar) ở vị trí này.

            App.Run();
            App.Shutdown();
        }

        private static async void TriggerTypewriterEffect(string fullText)
        {
            dynamicTitleLabel.Text = "";
            for (int i = 0; i <= fullText.Length; i++)
            {
                if (currentTargetTitle != fullText) return;
                dynamicTitleLabel.Text = fullText.Substring(0, i);
                App.MainLoop.Invoke(() => { dynamicTitleLabel.SetNeedsDisplay(); });
                await Task.Delay(20);
            }
        }
    }
}