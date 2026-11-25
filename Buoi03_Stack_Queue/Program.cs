using System;
using System.Collections.Generic;
using System.Text;

namespace Buoi03_Stack_Queue
{
    // Lớp hỗ trợ cho Bài 3 (Khung ngăn xếp hàm)
    class StackFrame
    {
        public string TenHam { get; set; }
        public string ThamSo { get; set; }
        public string DiaChiTraVe { get; set; }

        public StackFrame(string tenHam, string thamSo, string diaChiTraVe)
        {
            TenHam = tenHam;
            ThamSo = thamSo;
            DiaChiTraVe = diaChiTraVe;
        }

        public override string ToString()
        {
            return $"{TenHam}({ThamSo}) [Tra ve -> {DiaChiTraVe}]";
        }
    }

    // Lớp hỗ trợ cho Bài 5 (Gói tin mạng)
    class DataPacket
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public bool BiLoi { get; set; }

        public DataPacket(int id, string noiDung, bool biLoi = false)
        {
            Id = id;
            NoiDung = noiDung;
            BiLoi = biLoi;
        }
    }

    // Lớp hỗ trợ cho Bài 6 (Khách hàng trong hàng đợi)
    class KhachHang
    {
        public int SoThuTu { get; set; }
        public string HoTen { get; set; }
        public string ThoiGianDen { get; set; }
        public string LoaiDichVu { get; set; }

        public KhachHang(int stt, string hoTen, string thoiGianDen, string loaiDichVu)
        {
            SoThuTu = stt;
            HoTen = hoTen;
            ThoiGianDen = thoiGianDen;
            LoaiDichVu = loaiDichVu;
        }

        public override string ToString()
        {
            return $"[STT {SoThuTu}] {HoTen} | Den: {ThoiGianDen} | DV: {LoaiDichVu}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Bài 1: Kiểm tra tính đúng đắn của biểu thức toán học ===");
            Bai1();

            Console.WriteLine("\n=== Bài 2: Mô phỏng lịch sử trình duyệt web ===");
            Bai2();

            Console.WriteLine("\n=== Bài 3: Mô phỏng quá trình thực thi chương trình (Function Call Stack) ===");
            Bai3();

            Console.WriteLine("\n=== Bài 4: Mô phỏng hệ thống in ấn ===");
            Bai4();

            Console.WriteLine("\n=== Bài 5: Mô phỏng đường truyền dữ liệu ===");
            Bai5();

            Console.WriteLine("\n=== Bài 6: Mô phỏng quản lý hàng đợi tại Trung tâm Dịch vụ / Ngân hàng ===");
            Bai6();
        }

        // Bài 1
        static bool KiemTraNgoacHopLe(string bieuThuc)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in bieuThuc)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false;
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        static void Bai1()
        {
            Console.Write("Hãy nhập biểu thức cần kiểm tra: ");
            string bt1 = Console.ReadLine();

            Console.WriteLine($"{bt1} -> {(KiemTraNgoacHopLe(bt1) ? "Hợp lệ" : "Không hợp lệ")}");
        }

        // Bài 2
        static void Bai2()
        {
            Stack<string> backStack = new Stack<string>();
            Stack<string> forwardStack = new Stack<string>();
            string currentPage = "Trang chủ";

            void TruyCap(string url)
            {
                backStack.Push(currentPage);
                currentPage = url;
                forwardStack.Clear();
                Console.WriteLine($"Truy cập '{url}' -> Hiện tại: {currentPage}");
            }

            void Back()
            {
                if (backStack.Count == 0)
                {
                    Console.WriteLine("Back: Không có trang trước đó.");
                    return;
                }
                forwardStack.Push(currentPage);
                currentPage = backStack.Pop();
                Console.WriteLine($"Back -> Hiện tại: {currentPage}");
            }

            void Forward()
            {
                if (forwardStack.Count == 0)
                {
                    Console.WriteLine("Forward: Không có trang tiếp theo.");
                    return;
                }
                backStack.Push(currentPage);
                currentPage = forwardStack.Pop();
                Console.WriteLine($"Forward -> Hiện tại: {currentPage}");
            }

            Console.WriteLine($"Bắt đầu tại: {currentPage}");
            TruyCap("google.com");
            TruyCap("youtube.com");
            Back();
            Back();
            Forward();
            TruyCap("github.com");
            Forward();
        }

        // Bài 3
        static void Bai3()
        {
            Stack<StackFrame> callStack = new Stack<StackFrame>();

            void GoiHam(string tenHam, string thamSo, string diaChiTraVe)
            {
                StackFrame frame = new StackFrame(tenHam, thamSo, diaChiTraVe);
                callStack.Push(frame);
                Console.WriteLine($"Gọi: {frame} (Độ sâu stack: {callStack.Count})");
            }

            void TraVeHam()
            {
                if (callStack.Count == 0) return;
                StackFrame frame = callStack.Pop();
                Console.WriteLine($"Trả về từ: {frame.TenHam} -> Quay về {frame.DiaChiTraVe} (Độ sâu stack: {callStack.Count})");
            }

            GoiHam("Main", "", "OS");
            GoiHam("TinhTong", "a=3, b=4", "Main:15");
            GoiHam("CongHaiSo", "3, 4", "TinhTong:8");
            TraVeHam();
            TraVeHam();
            TraVeHam();
        }

        // Bài 4
        static void Bai4()
        {
            Queue<string> queueIn = new Queue<string>();

            queueIn.Enqueue("TaiLieu_01.pdf");
            queueIn.Enqueue("BaoCao_02.docx");
            queueIn.Enqueue("Slide_03.pptx");

            while (queueIn.Count > 0)
            {
                string file = queueIn.Dequeue();
                Console.WriteLine($"Đang in: {file} | Còn lại: {queueIn.Count}");
            }
        }

        // Bài 5
        static void Bai5()
        {
            Queue<DataPacket> queueGoiTin = new Queue<DataPacket>();

            queueGoiTin.Enqueue(new DataPacket(1, "Goi_tin_1"));
            queueGoiTin.Enqueue(new DataPacket(2, "Goi_tin_2", true));
            queueGoiTin.Enqueue(new DataPacket(3, "Goi_tin_3"));

            while (queueGoiTin.Count > 0)
            {
                DataPacket pkt = queueGoiTin.Dequeue();
                if (pkt.BiLoi)
                    Console.WriteLine($"Gói #{pkt.Id} ({pkt.NoiDung}) bị lỗi -> Cần gửi lại");
                else
                    Console.WriteLine($"Nhận thành công gói #{pkt.Id}: {pkt.NoiDung}");
            }
        }

        // Bài 6
        static void Bai6()
        {
            Queue<KhachHang> hangDoi = new Queue<KhachHang>();
            int stt = 1;

            void KhachDen(string ten, string gioDen, string loaiDV)
            {
                KhachHang kh = new KhachHang(stt++, ten, gioDen, loaiDV);
                hangDoi.Enqueue(kh);
                Console.WriteLine($"Vào hàng đợi: {kh}");
            }

            void PhucVu()
            {
                if (hangDoi.Count == 0)
                {
                    Console.WriteLine("Hàng đợi rỗng.");
                    return;
                }
                KhachHang kh = hangDoi.Dequeue();
                Console.WriteLine($"Đang phục vụ: {kh} | Còn chờ: {hangDoi.Count}");
            }

            KhachDen("Nguyễn Văn A", "08:00", "Rút tiền");
            KhachDen("Trần Thị B", "08:05", "Mở tài khoản");
            PhucVu();
            KhachDen("Lê Văn C", "08:10", "Đóng tiền điện");
            PhucVu();
            PhucVu();
        }
    }
}
