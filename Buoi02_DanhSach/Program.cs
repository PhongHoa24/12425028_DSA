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
            head = DaoNguocDS(head);
            Console.WriteLine("Đã đảo ngược danh sách liên kết đơn thành công.");
            DaoNguocDS(head);
        }
        //Bài 14
        static Node MergeTwoLists(Node l1, Node l2)
        {
            Node dummy = new Node(0);
            Node tail = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.Data <= l2.Data) { tail.Link = l1; l1 = l1.Link; }
                else { tail.Link = l2; l2 = l2.Link; }
                tail = tail.Link;
            }
            tail.Link = l1 != null ? l1 : l2;
            return dummy.Link;
        }
        static void Bai14()
        {
            Node l1 = new Node(1); l1.Link = new Node(3);
            Node l2 = new Node(2); l2.Link = new Node(4);
            Node merged = MergeTwoLists(l1, l2);
            Console.WriteLine("Đã gộp thành công hai danh sách liên kết.");
            MergeTwoLists(l1, l2);
        }
    }
}