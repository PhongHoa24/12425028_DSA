using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_DanhSach
{
    struct NhanVien
    {
        public string ManV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
        public int ThucLinh => LuongCB + Thuong;
    }
    class Node
    {
        public int Data;
        public Node Link;
        public Node(int data)
        {
            Data = data;
            Link = null;
        }
    }
    class DNode<T>
    {
        public T Data;
        public DNode<T> Prev;
        public DNode<T> Next;
        public DNode(T data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }
    class BaiHat
    {
        public string TenBai { get; set; }
        public string CaSi { get; set; }

        public BaiHat(string tenBai, string caSi)
        {
            TenBai = tenBai;
            CaSi = caSi;
        }
        public override string ToString() => $"{TenBai} - {CaSi}";
    }
    class DonHang
    {
        public string MaDH { get; set; }
        public string KhachHang { get; set; }
        public string TrangThai { get; set; }
        public DonHang(string maDH, string khachHang, string trangThai = "Chờ xử lý")
        {
            MaDH = maDH;
            KhachHang = khachHang;
            TrangThai = trangThai;
        }
        public override string ToString() => $"[{MaDH}] {KhachHang} | Trạng thái: {TrangThai}";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Bài 1 ===");
            Bai1();
            Console.WriteLine("=== Bài 2 ===");
            Bai2();
            Console.WriteLine("=== Bài 3 ===");
            Bai3();
            Console.WriteLine("=== Bài 4 ===");
            Bai4();
            Console.WriteLine("=== Bài 5 ===");
            Bai5();
            Console.WriteLine("=== Bài 7 ===");
            Bai7();
            Console.WriteLine("=== Bài 8 ===");
            Bai8();
            Console.WriteLine("=== Bài 9 ===");
            Bai9();
            Console.WriteLine("=== Bài 10 ===");
            Bai10();
            Console.WriteLine("=== Bài 11 ===");
            Bai11();
            Console.WriteLine("=== Bài 12 ===");
            Bai12();
            Console.WriteLine("=== Bài 13 ===");
            Bai13();
            Console.WriteLine("=== Bài 14 ===");
            Bai14();
            Console.WriteLine("=== Bài 15 ===");
            Bai15();
            Console.WriteLine("=== Bài 16 ===");
            Bai16();
            Console.WriteLine("=== Bài 17 ===");
            Bai17();
            Console.WriteLine("=== Bài 18 ===");
            Bai18();
        }
        //Bài 1
        static int[] NhapMang(out int n)
        {
            Console.Write("Nhập số lượng phần tử n: ");
            n = int.Parse(Console.ReadLine() ?? "0");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }
            return a;
        }
        static void XuatMang(int[] a)
        {
            foreach (int item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static int[] ChenPhanTu(int[] a, int x, int k)
        {
            int n = a.Length;
            int[] tmp = new int[n + 1];
            for (int i = 0; i < k; i++)
            {
                tmp[i] = a[i];
            }
            tmp[k] = x;
            for (int i = k; i < n; i++)
            {
                tmp[i + 1] = a[i];
            }
            return tmp;
        }
        static void Bai1()
        {
            int n = 0;
            int[] a = NhapMang(out n);
            Console.Write("Mảng vừa nhập: ");
            XuatMang(a);
            Console.Write("Nhập giá trị cần chèn x: ");
            int x = int.Parse(Console.ReadLine() ?? "0");
            Console.Write($"Nhập vị trí k cần chèn (0 < k < {n-1}: ");
            int k = int.Parse(Console.ReadLine() ?? "0");
            if (k >= 0 && k <= a.Length)
            {
                a = ChenPhanTu(a, x, k);
                Console.Write("Mảng sau khi chèn: ");
                XuatMang(a);
            }
            else
            {
                Console.WriteLine("Vị trí k không hợp lệ!");
            }
        }
        //Bài 2
        static int TongThucLinh(NhanVien[] ds)
        {
            int tong = 0;
            foreach (var nv in ds)
            {
                tong += nv.ThucLinh;
            }
            return tong;
        }
        static void InNVLuongCBThapNhat(NhanVien[] ds)
        {
            if (ds.Length == 0) return;
            int minLuong = ds.Min(nv => nv.LuongCB);
            foreach (var nv in ds)
            {
                if (nv.LuongCB == minLuong)
                {
                    Console.WriteLine($"   - Mã: {nv.ManV}, Tên: {nv.Hoten}, Lương CB: {nv.LuongCB}");
                }
            }
        }
        static int DemNV(NhanVien[] ds)
        {
            int dem = 0;
            foreach (var nv in ds)
            {
                if (nv.Thuong >= 1200000) dem++;
            }
            return dem;
        }
        static void SapXepVaIn(NhanVien[] ds)
        {
            var ketQua = ds.OrderBy(nv => nv.Phongban).ThenByDescending(nv => nv.ManV);
            foreach (var nv in ketQua)
            {
                Console.WriteLine($"   - Phòng: {nv.Phongban}, Mã NV: {nv.ManV}, Tên: {nv.Hoten}");
            }
        }
        static void TangLuong(NhanVien[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                ds[i].LuongCB = (int)(ds[i].LuongCB * 1.05);
                Console.WriteLine($"{ds[i].ManV} - {ds[i].Hoten}: {ds[i].LuongCB}");
            }
        }
        static void Bai2()
        {
            NhanVien[] ds = new NhanVien[]
            {
                new NhanVien { ManV = "NV02", Hoten = "Nguyễn Phong Hòa", Namsinh = 2006, Phongban = "IT", LuongCB = 50000000, Thuong = 1500000 },
                new NhanVien { ManV = "NV01", Hoten = "Nguyễn Viết Đạt", Namsinh = 2007, Phongban = "HR", LuongCB = 40000000, Thuong = 1000000 },
                new NhanVien { ManV = "NV03", Hoten = "Lê Thành Long", Namsinh = 2007, Phongban = "IT", LuongCB = 40000000, Thuong = 1200000 }
            };
            Console.WriteLine($"Tổng thực lĩnh tháng của công ty: {TongThucLinh(ds)}");
            Console.WriteLine("Danh sách nhân viên có lương cơ bản thấp nhất:");
            InNVLuongCBThapNhat(ds);
            Console.WriteLine($"Số lượng nhân viên có thưởng >= 1,200,000: {DemNV(ds)}");
            Console.WriteLine("Danh sách nhân viên sắp xếp theo phòng ban:");
            SapXepVaIn(ds);
            Console.WriteLine("Cập nhật lương NV (tăng 5%):");
            TangLuong(ds);
        }
        //Bài 3
        static int TongS1(int[,] a, int n)
        {
            int t = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    t += a[i, j];
            return t;
        }
        static int TimGTNN(int[,] a, int n)
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] > 0 && a[i, j] < min)
                    {
                        min = a[i, j];
                    }
                }
            }
            return (min == int.MaxValue) ? -1 : min;
        }
        static int TongS2(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                tong += a[i, n - 1 - i];
            }
            return tong;
        }
        static bool KiemTra(int[,] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i, i] >= a[i + 1, i + 1]) return false;
            }
            return true;
        }
        static void Bai3()
        {
            int n = 3;
            int[,] a = {
                { 1, 5, 3 },
                { 4, 2, 6 },
                { 7, 8, 9 }
            };

            Console.WriteLine($"Tổng tất cả các phần tử ma trận: {TongS1(a, n)}");
            Console.WriteLine($"Giá trị dương nhỏ nhất của ma trận: {TimGTNN(a, n)}");
            Console.WriteLine($"Tổng các phần tử đường chéo phụ: {TongS2(a, n)}");
            Console.WriteLine($"Đường chéo chính có tăng dần không? {(KiemTra(a, n) ? "Có" : "Không")}");
        }
        //Bài 4
        static Node ThemCuoi(Node pHead, int x)
        {
            Node newNode = new Node(x);
            if (pHead == null) return newNode;
            Node p = pHead;
            while (p.Link != null)
            {
                p = p.Link;
            }
            p.Link = newNode;
            return pHead;
        }

        static void XuatDanhSach(Node pHead)
        {
            Node p = pHead;
            while (p != null)
            {
                Console.Write(p.Data + " ");
                p = p.Link;
            }
            Console.WriteLine();
        }
        static int DemSoBangX(Node pHead, int x)
        {
            int d = 0;
            Node p = pHead;
            while (p != null)
            {
                if (p.Data == x) d++;
                p = p.Link;
            }
            return d;
        }
        static int TimPTNN(Node pHead)
        {
            int minDuong = int.MaxValue;
            Node p = pHead;
            while (p != null)
            {
                if (p.Data > 0 && p.Data < minDuong)
                {
                    minDuong = p.Data;
                }
                p = p.Link;
            }
            return (minDuong == int.MaxValue) ? -1 : minDuong;
        }
        static Node XoaX(Node pHead, int x)
        {
            if (pHead == null) return null;
            if (pHead.Data == x)
            {
                return pHead.Link;
            }
            Node p = pHead;
            while (p.Link != null && p.Link.Data != x)
            {
                p = p.Link;
            }
            if (p.Link != null)
            {
                p.Link = p.Link.Link;
            }
            return pHead;
        }
        static void Bai4()
        {
            Node pHead = null;
            pHead = ThemCuoi(pHead, 5);
            pHead = ThemCuoi(pHead, -2);
            pHead = ThemCuoi(pHead, 5);
            pHead = ThemCuoi(pHead, 12);
            pHead = ThemCuoi(pHead, 7);
            Console.Write("Danh sách hiện tại: ");
            XuatDanhSach(pHead);
            Console.Write("Nhập x cần tìm kiếm: ");
            int x;
            int.TryParse(Console.ReadLine(), out x);
            Console.WriteLine($"Số lượng phần tử có giá trị bằng {x}: {DemSoBangX(pHead, x)}");
            Console.WriteLine($"Phần tử dương nhỏ nhất trong danh sách: {TimPTNN(pHead)}");
            pHead = XoaX(pHead, x);
            Console.WriteLine($"Đã xóa phần tử {x} xuất hiện đầu tiên");
            Console.Write("Danh sách sau khi xóa: ");
            XuatDanhSach(pHead);
        }
        //Bài 5
        static int TimPTLN(Node pHead)
        {
            if (pHead == null) throw new Exception("Danh sách rỗng!");
            int max = pHead.Data;
            Node p = pHead.Link;
            while (p != null)
            {
                if (p.Data > max)
                {
                    max = p.Data;
                }
                p = p.Link;
            }
            return max;
        }
        static int TinhTong(Node pHead)
        {
            int t = 0;
            Node p = pHead;
            while (p != null)
            {
                t += p.Data;
                p = p.Link;
            }
            return t;
        }
        static bool KiemTraSNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static int DemSNT(Node pHead)
        {
            int dem = 0;
            Node p = pHead;
            while (p != null)
            {
                if (KiemTraSNT(p.Data))
                {
                    dem++;
                }
                p = p.Link;
            }
            return dem;
        }
        static void DemSo(Node pHead, out int demAm, out int demKhong, out int demDuong)
        {
            demAm = 0;
            demKhong = 0;
            demDuong = 0;
            Node p = pHead;
            while (p != null)
            {
                if (p.Data < 0) demAm++;
                else if (p.Data > 0) demDuong++;
                else demKhong++;
                p = p.Link;
            }
        }
        static void Bai5()
        {
            Node pHead = null;
            pHead = ThemCuoi(pHead, 7);
            pHead = ThemCuoi(pHead, 8);
            pHead = ThemCuoi(pHead, 6);
            pHead = ThemCuoi(pHead, 12);
            pHead = ThemCuoi(pHead, 8);

            Console.Write("Danh sách hiện tại: ");
            XuatDanhSach(pHead);
            Console.WriteLine();
            Console.WriteLine($"Phần tử lớn nhất trong danh sách: {TimPTLN(pHead)}");
            Console.WriteLine($"Tổng các phần tử của danh sách: {TinhTong(pHead)}");
            Console.WriteLine($"Số lượng số nguyên tố trong danh sách: {DemSNT(pHead)}");
            DemSo(pHead, out int demAm, out int demKhong, out int demDuong);
            Console.WriteLine($"Thống kê: {demAm} số âm, {demKhong} số bằng 0, {demDuong} số dương.");
            Console.Write("Nhập x cần tìm kiếm: ");
            int x = 0;
            int.TryParse(Console.ReadLine(), out x);
            Console.WriteLine($"Số lượng phần tử bằng {x}: {DemSoBangX(pHead, x)}");
            Console.WriteLine($"Phần tử dương nhỏ nhất trong danh sách: {TimPTNN(pHead)}");
        }
        //Bài 7
        static void Bai7()
        {
            Console.Write("Nhập số ngày n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            double[] nhietDo = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập nhiệt độ ngày {i + 1}: ");
                nhietDo[i] = double.Parse(Console.ReadLine() ?? "0");
            }
            double max = nhietDo[0], min = nhietDo[0], tong = 0;
            int ngayMax = 1, ngayMin = 1;
            for (int i = 0; i < n; i++)
            {
                tong += nhietDo[i];
                if (nhietDo[i] > max) { max = nhietDo[i]; ngayMax = i + 1; }
                if (nhietDo[i] < min) { min = nhietDo[i]; ngayMin = i + 1; }
            }
            Console.WriteLine($"Ngày nhiệt độ cao nhất: Ngày {ngayMax} ({max}°C)");
            Console.WriteLine($"Ngày nhiệt độ thấp nhất: Ngày {ngayMin} ({min}°C)");
            Console.WriteLine($"Nhiệt độ trung bình tuần: {tong / n:F2}°C");
        }
        // Bài 8
        static void Bai8()
        {
            Console.Write("Nhập một chuỗi văn bản: ");
            string s = Console.ReadLine() ?? "";
            string[] words = s.ToLower().Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (dict.ContainsKey(w)) dict[w]++;
                else dict[w] = 1;
            }
            Console.WriteLine("Tần suất xuất hiện của mỗi từ:");
            foreach (var pair in dict)
            {
                Console.WriteLine($"- '{pair.Key}': {pair.Value} lần");
            }
        }
        //Bài 9
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++) if (n % i == 0) return false;
            return true;
        }
        static bool IsPerfect(int n)
        {
            if (n < 2) return false;
            int sum = 1;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    if (i * i != n) sum += n / i;
                }
            }
            return sum == n;
        }
        static void Bai9()
        {
            Console.Write("Nhập số lượng phần tử mảng: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"arr[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine() ?? "0");
            }
            Console.Write("Các số nguyên tố: ");
            foreach (var x in arr) if (IsPrime(x)) Console.Write(x + " ");
            Console.WriteLine();
            Console.Write("Các số chẵn: ");
            foreach (var x in arr) if (x % 2 == 0) Console.Write(x + " ");
            Console.WriteLine();
            Console.Write("Các số hoàn hảo: ");
            foreach (var x in arr) if (IsPerfect(x)) Console.Write(x + " ");
            Console.WriteLine();
        }
        //Bài 10
        static void Bai10()
        {
            Console.Write("Nhập kích thước n của ma trận xoắn ốc: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            int[,] matrix = new int[n, n];
            int top = 0, bottom = n - 1, left = 0, right = n - 1;
            int val = 1;
            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++) matrix[top, i] = val++;
                top++;
                for (int i = top; i <= bottom; i++) matrix[i, right] = val++;
                right--;
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--) matrix[bottom, i] = val++;
                    bottom--;
                }
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--) matrix[i, left] = val++;
                    left++;
                }
            }
            Console.WriteLine("In ma trận theo thứ tự xoắn ốc:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }
        }
        //Bài 11
        static void Bai11()
        {
            int n = 3;
            int[,] mIdentity = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] mSymmetric = { { 1, 2, 3 }, { 2, 5, 6 }, { 3, 6, 9 } };
            bool isIdentity = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if ((i == j && mIdentity[i, j] != 1) || (i != j && mIdentity[i, j] != 0)) isIdentity = false;
            Console.WriteLine($"Ma trận có phải ma trận đơn vị không? {isIdentity}");
            bool isSymmetric = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (mSymmetric[i, j] != mSymmetric[j, i]) isSymmetric = false;
            Console.WriteLine($"Ma trận có phải ma trận đối xứng không? {isSymmetric}");
        }

        //Bài 12
        static void Bai12()
        {
            int m = 4, n = 4;
            int[,] board = {
                { -1, 0, 0, 0 },
                { 0, 0, -1, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            };
            int[,] result = new int[m, n];
            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == -1) { result[i, j] = -1; continue; }
                    int count = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        int ni = i + dr[k], nj = j + dc[k];
                        if (ni >= 0 && ni < m && nj >= 0 && nj < n && board[ni, nj] == -1) count++;
                    }
                    result[i, j] = count;
                }
            }
            Console.WriteLine("Bảng Minesweeper sau khi tính số mìn xung quanh:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++) Console.Write($"{result[i, j],3}");
                Console.WriteLine();
            }
        }
        //Bài 13
        static Node DaoNguocDS(Node pHead)
        {
            Node prev = null, current = pHead, next = null;
            while (current != null)
            {
                next = current.Link;
                current.Link = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
        static void Bai13()
        {
            Node head = new Node(1);
            head.Link = new Node(2);
            head.Link.Link = new Node(3);
            Console.Write("Danh sách ban đầu: ");
            XuatDanhSach(head);
            head = DaoNguocDS(head);
            Console.Write("Danh sách sau khi đảo ngược: ");
            XuatDanhSach(head);
        }
        //Bài 14
        static Node MergeTwoLists(Node l1, Node l2)
        {
            Node dummy = new Node(0);
            Node tail = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.Data <= l2.Data)
                {
                    tail.Link = l1;
                    l1 = l1.Link;
                }
                else
                {
                    tail.Link = l2;
                    l2 = l2.Link;
                }
                tail = tail.Link;
            }
            tail.Link = l1 != null ? l1 : l2;
            return dummy.Link;
        }
        static void Bai14()
        {
            Node l1 = new Node(1);
            l1.Link = new Node(3);
            Node l2 = new Node(2);
            l2.Link = new Node(4);
            Console.Write("Danh sách 1: ");
            XuatDanhSach(l1);
            Console.Write("Danh sách 2: ");
            XuatDanhSach(l2);
            Node merged = MergeTwoLists(l1, l2);
            Console.Write("Danh sách sau khi gộp: ");
            XuatDanhSach(merged);
        }
        //Bài 15
        static bool CoChuTrinh(Node head)
        {
            if (head == null || head.Link == null) return false;
            Node slow = head;
            Node fast = head;

            while (fast != null && fast.Link != null)
            {
                slow = slow.Link;
                fast = fast.Link.Link;
                if (slow == fast) return true;
            }
            return false;
        }
        static void Bai15()
        {
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            n2.Link = n3;
            n3.Link = n4;
            n4.Link = n5;
            n5.Link = n6;
            n6.Link = n2;
            Console.WriteLine("Danh sách có chu trình không? " + (CoChuTrinh(n2) ? "Có chu trình" : "Không có chu trình"));
            n6.Link = null;
            Console.WriteLine("Sau khi ngắt liên kết cuối: " + (CoChuTrinh(n2) ? "Có chu trình" : "Không có chu trình"));
        }

        //Bài 16
        static void Bai16()
        {
            DNode<string> current = null;
            void TruyCap(string url)
            {
                DNode<string> nodeMoi = new DNode<string>(url);
                if (current != null)
                {
                    current.Next = null;
                    nodeMoi.Prev = current;
                    current.Next = nodeMoi;
                }
                current = nodeMoi;
                Console.WriteLine($"Truy cập: {current.Data}");
            }
            void Back()
            {
                if (current != null && current.Prev != null)
                {
                    current = current.Prev;
                    Console.WriteLine($"Back -> Đang xem: {current.Data}");
                }
                else
                {
                    Console.WriteLine("Back -> Không thể quay lại.");
                }
            }
            void Forward()
            {
                if (current != null && current.Next != null)
                {
                    current = current.Next;
                    Console.WriteLine($"Forward -> Đang xem: {current.Data}");
                }
                else
                {
                    Console.WriteLine("Forward -> Không thể chuyển tiếp.");
                }
            }
            TruyCap("https://example.com");
            TruyCap("https://github.com");
            TruyCap("https://learn.microsoft.com");
            Back();
            Back();
            Forward();
            TruyCap("https://stackoverflow.com");
            Forward();
        }
        //Bài 17
        static void Bai17()
        {
            DNode<BaiHat> head = null, tail = null, current = null;
            void ThemBaiHat(string ten, string casi)
            {
                DNode<BaiHat> moi = new DNode<BaiHat>(new BaiHat(ten, casi));
                if (head == null)
                {
                    head = tail = current = moi;
                }
                else
                {
                    tail.Next = moi;
                    moi.Prev = tail;
                    tail = moi;
                }
                Console.WriteLine($"Đã thêm: {moi.Data}");
            }
            void XoaBaiHienTai()
            {
                if (current == null)
                {
                    Console.WriteLine("Playlist rỗng!");
                    return;
                }
                Console.WriteLine($"Đã xóa: {current.Data}");

                if (head == tail)
                {
                    head = tail = current = null;
                }
                else if (current == head)
                {
                    head = head.Next;
                    head.Prev = null;
                    current = head;
                }
                else if (current == tail)
                {
                    tail = tail.Prev;
                    tail.Next = null;
                    current = tail;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    current = current.Next;
                }
            }
            void NextBai()
            {
                if (current != null && current.Next != null)
                {
                    current = current.Next;
                    Console.WriteLine($"Next -> Đang phát: {current.Data}");
                }
                else Console.WriteLine("Next -> Đã ở cuối playlist.");
            }
            void PrevBai()
            {
                if (current != null && current.Prev != null)
                {
                    current = current.Prev;
                    Console.WriteLine($"Previous -> Đang phát: {current.Data}");
                }
                else Console.WriteLine("Previous -> Đã ở đầu playlist.");
            }
            ThemBaiHat("Nơi này có anh", "Sơn Tùng M-TP");
            ThemBaiHat("Có chắc yêu là đây", "Sơn Tùng M-TP");
            ThemBaiHat("Hãy trao cho anh", "Sơn Tùng M-TP");
            Console.WriteLine($"Bài đang phát: {current?.Data}");
            NextBai();
            PrevBai();
            XoaBaiHienTai();
            Console.WriteLine($"Bài đang phát sau xóa: {current?.Data}");
        }
        //Bài 18
        static void Bai18()
        {
            string[] cacTrangThai = { "Chờ xử lý", "Đang giao", "Hoàn thành" };
            DNode<DonHang> head = null, tail = null;

            void ThemDonHang(string maDH, string khachHang)
            {
                DNode<DonHang> moi = new DNode<DonHang>(new DonHang(maDH, khachHang, cacTrangThai[0]));
                if (head == null) head = tail = moi;
                else
                {
                    tail.Next = moi;
                    moi.Prev = tail;
                    tail = moi;
                }
            }
            DNode<DonHang> TimDon(string maDH)
            {
                DNode<DonHang> p = head;
                while (p != null)
                {
                    if (p.Data.MaDH == maDH) return p;
                    p = p.Next;
                }
                return null;
            }
            void ChuyenTrangThaiTiep(string maDH)
            {
                var node = TimDon(maDH);
                if (node == null) return;
                int idx = Array.IndexOf(cacTrangThai, node.Data.TrangThai);
                if (idx < cacTrangThai.Length - 1)
                {
                    node.Data.TrangThai = cacTrangThai[idx + 1];
                    Console.WriteLine($"Cập nhật tiến độ -> {node.Data}");
                }
                else
                {
                    Console.WriteLine($"Đơn {maDH} đã ở trạng thái cuối ({node.Data.TrangThai}).");
                }
            }
            void QuayLaiTrangThaiTruoc(string maDH)
            {
                var node = TimDon(maDH);
                if (node == null) return;
                int idx = Array.IndexOf(cacTrangThai, node.Data.TrangThai);
                if (idx > 0)
                {
                    node.Data.TrangThai = cacTrangThai[idx - 1];
                    Console.WriteLine($"Hoàn tác trạng thái -> {node.Data}");
                }
            }
            void InDanhSachDon()
            {
                DNode<DonHang> p = head;
                while (p != null)
                {
                    Console.WriteLine("  " + p.Data);
                    p = p.Next;
                }
            }
            ThemDonHang("DH01", "Nguyễn Phong Hòa");
            ThemDonHang("DH02", "Nguyễn Viết Đạt");
            Console.WriteLine("Danh sách đơn ban đầu:");
            InDanhSachDon();
            ChuyenTrangThaiTiep("DH01");
            ChuyenTrangThaiTiep("DH01");
            QuayLaiTrangThaiTruoc("DH01");
            Console.WriteLine("Danh sách đơn sau cập nhật:");
            InDanhSachDon();
        }
    }
}