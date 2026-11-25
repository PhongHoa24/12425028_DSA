using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi01_DeQuy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Bài 1 Chương 1 ===");
            Bai1Chuong1();
            Console.WriteLine("\n=== Bài 2 Chương 1 ===");
            Bai2Chuong1();
            Console.WriteLine("\n=== Bài 3 Chương 1 ===");
            Bai3Chuong1();
            Console.WriteLine("\n=== Bài 4 Chương 1 ===");
            Bai4Chuong1();
            Console.WriteLine("\n=== Bài 5 Chương 1 ===");
            Bai5Chuong1();
            Console.WriteLine("\n=== Bài 1 Chương 2 ===");
            Bai1Chuong2();
            Console.WriteLine("\n=== Bài 2 Chương 2 ===");
            Bai2Chuong2();
            Console.WriteLine("\n=== Bài 3 Chương 2 ===");
            Bai3Chuong2();
            Console.WriteLine("\n=== Bài 4 Chương 2 ===");
            Bai4Chuong2();
            Console.WriteLine("\n=== Bài 5 Chương 2 ===");
            Bai5Chuong2();
            Console.WriteLine("\n=== Bài 6 Chương 2 ===");
            Bai6Chuong2();
            Console.WriteLine("\n=== Bài 1 Chương 3 ===");
            Bai1Chuong3();
            Console.WriteLine("\n=== Bài 2 Chương 3 ===");
            Bai2Chuong3();
            Console.WriteLine("\n=== Bài 3 Chương 3 ===");
            Bai3Chuong3();
            Console.WriteLine("\n=== Bài 4 Chương 3 ===");
            Bai4Chuong3();
            Console.WriteLine("\n=== Bài 5 Chương 3 ===");
            Bai5Chuong3();
            Console.WriteLine("\n=== Bài 6 Chương 3 ===");
            Bai6Chuong3();
            Console.WriteLine("\n=== Bài 7 Chương 3 ===");
            Bai7Chuong3();
            Console.WriteLine("\n=== Bài 8 Chương 3 ===");
            Bai8Chuong3();
            Console.WriteLine("\n=== Bài 1 Cuối sách ===");
            Bai1CS();
            Console.WriteLine("\n=== Bài 2 Cuối sách ===");
            Bai2CS();
            Console.WriteLine("\n=== Bài 3 Cuối sách ===");
            Bai3CS();
            Console.WriteLine("\n=== Bài 4 Cuối sách ===");
            Bai4CS();
            Console.WriteLine("\n=== Bài 5 Cuối sách ===");
            Bai5CS();
            Console.WriteLine("\n=== Bài 6 Cuối sách ===");
            Bai6CS();
            Console.WriteLine("\n=== Bài 7 Cuối sách ===");
            Bai7CS();
        }
        // Bài 1 Chương 1
        static void Bai1Chuong1()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Range(0, 1000).Select(_ => rand.Next(1, 100)).ToArray();

            Console.WriteLine($"Số lớn nhất: {arr.Max()}");
            Console.WriteLine($"Số nhỏ nhất: {arr.Min()}");
        }
        // Bài 2 Chương 1
        static void Bai2Chuong1()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.Write("FizzBuzz ");
                else if (i % 3 == 0) Console.Write("Fizz ");
                else if (i % 5 == 0) Console.Write("Buzz ");
                else Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        // Bài 3 Chương 1
        static void Bai3Chuong1()
        {
            Console.Write("Nhập chuỗi: ");
            string s = Console.ReadLine() ?? "";
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine("Chuỗi đảo ngược: " + new string(arr));
        }
        // Bài 4 Chương 1
        static void Bai4Chuong1()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Range(0, 10).Select(_ => rand.Next(1, 100)).ToArray();

            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", arr));

            Array.Sort(arr);
            Console.WriteLine("Mảng sắp xếp: " + string.Join(", ", arr));
        }
        // Bài 5 Chương 1
        static void Bai5Chuong1()
        {
            Console.Write("Nhập vào n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                long a = 0, b = 1, c = 0;

                for (int i = 2; i <= n; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                Console.WriteLine($"Số Fibonacci thứ {n} là: {(n <= 1 ? n : c)}");
            }
            else
            {
                Console.WriteLine("Giá trị bạn nhập không hợp lệ!");
            }
        }
        // Bài 1 Chương 2
        static void ThapHaNoi(int n, char nguon, char trungGian, char dich)
        {
            if (n == 1) return;
            ThapHaNoi(n - 1, nguon, dich, trungGian);
            ThapHaNoi(n - 1, trungGian, nguon, dich);
        }
        static void Bai1Chuong2()
        {
            Console.Write("Nhập số lượng đĩa n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Stopwatch sw = Stopwatch.StartNew();
                ThapHaNoi(n, 'A', 'B', 'C');
                sw.Stop();
                Console.WriteLine($"Thời gian thực thi: {sw.Elapsed.TotalMilliseconds} ms");
            }
        }
        // Bài 2 Chương 2
        static int BinarySearchDeQuy(int[] arr, int left, int right, int key)
        {
            if (left > right) return -1;
            int mid = left + (right - left) / 2;
            if (arr[mid] == key) return mid;
            if (arr[mid] > key) return BinarySearchDeQuy(arr, left, mid - 1, key);
            return BinarySearchDeQuy(arr, mid + 1, right, key);
        }
        static void Bai2Chuong2()
        {
            int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int key = 15;
            Console.WriteLine("Mảng tìm kiếm: " + string.Join(", ", arr));
            Console.WriteLine($"Khóa cần tìm: {key}");
            int result = BinarySearchDeQuy(arr, 0, arr.Length - 1, key);
            Console.WriteLine(result != -1 ? $"Tìm thấy tại vị trí: {result}" : "Không tìm thấy");
        }
        // Bài 3 Chương 2
        static bool IsPrime(long n)
        {
            if (n < 2) return false;
            for (long i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }
        static void Bai3Chuong2()
        {
            Console.Write("Nhập số nguyên cần kiểm tra: ");
            if (long.TryParse(Console.ReadLine(), out long n))
            {
                Console.WriteLine(IsPrime(n) ? $"{n} là số nguyên tố." : $"{n} không phải số nguyên tố.");
            }
        }
        // Bài 4 Chương 2
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
        static void Bai4Chuong2()
        {
            Console.Write("Nhập n để liệt kê số hoàn hảo nhỏ hơn n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.Write($"Các số hoàn hảo nhỏ hơn {n}: ");
                for (int i = 1; i < n; i++)
                    if (IsPerfect(i)) Console.Write(i + " ");
                Console.WriteLine();
            }
        }
        // Bài 5 Chương 2
        static long FiboLap(int n)
        {
            if (n <= 2) return 1;
            long f1 = 1, f2 = 1, fn = 1;
            for (int i = 3; i <= n; i++)
            {
                fn = f1 + f2;
                f1 = f2;
                f2 = fn;
            }
            return fn;
        }
        static void Bai5Chuong2()
        {
            Console.Write("Nhập vị trí n của số Fibonacci cần tìm: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine($"Số Fibonacci thứ {n} là: {FiboLap(n)}");
            }
        }
        // Bài 6 Chương 2
        static void BubbleSort(double[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        double temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }
        static void Bai6Chuong2()
        {
            double[] arr = { 3.5, 1.2, 9.8, 5.4, 2.1 };
            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", arr));
            BubbleSort(arr);
            Console.WriteLine("Dãy sau khi sắp xếp:");
            foreach (var x in arr) Console.Write(x + "  ");
            Console.WriteLine();
        }
        // Bài 1 Chương 3
        static int TinhS1(int n)
        {
            if (n == 1) return 1;
            return TinhS1(n - 1) + n;
        }
        static void Bai1Chuong3()
        {
            Console.Write("Nhập n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"S({n}) = {TinhS1(n)}");
            }
        }
        // Bài 2 Chương 3
        static int TinhS2(int n)
        {
            if (n == 1) return 1;
            return TinhS2(n - 1) + n * n;
        }
        static void Bai2Chuong3()
        {
            Console.Write("Nhập n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"S({n}) = {TinhS2(n)}");
            }
        }
        // Bài 3 Chương 3
        static double TinhS3(int n)
        {
            if (n == 1) return 1.0;
            return TinhS3(n - 1) + 1.0 / n;
        }
        static void Bai3Chuong3()
        {
            Console.Write("Nhập n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"S({n}) = {TinhS3(n):F4}");
            }
        }
        // Bài 4 Chương 3
        static double LuyThua(double x, int n)
        {
            if (n == 0) return 1;
            return LuyThua(x, n - 1) * x;
        }
        static double TinhS4(double x, int n)
        {
            if (n < 0) return 1.0 / LuyThua(x, -n);
            return LuyThua(x, n);
        }
        static void Bai4Chuong3()
        {
            Console.Write("Nhập cơ sở x: ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                Console.Write("Nhập số mũ n: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    Console.WriteLine($"{x}^{n} = {TinhS4(x, n)}");
                }
            }
        }
        // Bài 5 Chương 3
        static int UocLeMax(int n)
        {
            if (n % 2 == 1) return n;
            return UocLeMax(n / 2);
        }
        static void Bai5Chuong3()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"Ước số lẻ lớn nhất của {n} là: {UocLeMax(n)}");
            }
        }
        // Bài 6 Chương 3
        static int UCLN(int a, int b)
        {
            if (a % b == 0) return b;
            return UCLN(b, a % b);
        }
        static void Bai6Chuong3()
        {
            Console.Write("Nhập a: ");
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                Console.Write("Nhập b: ");
                if (int.TryParse(Console.ReadLine(), out int b) && b != 0)
                {
                    Console.WriteLine($"UCLN({a}, {b}) = {UCLN(Math.Abs(a), Math.Abs(b))}");
                }
            }
        }
        // Bài 7 Chương 3
        static int SoChuSo(int n)
        {
            if (n == 0) return 0;
            return SoChuSo(n / 10) + 1;
        }
        static void Bai7Chuong3()
        {
            Console.Write("Nhập n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                int absN = Math.Abs(n);
                Console.WriteLine($"Số chữ số của {n} là: {(absN == 0 ? 1 : SoChuSo(absN))}");
            }
        }
        // Bài 8 Chương 3
        static double Can(int i, int n)
        {
            if (i == n) return Math.Sqrt(n);
            return Math.Sqrt(i + Can(i + 1, n));
        }
        static double TinhS8(int n)
        {
            return Can(1, n);
        }
        static void Bai8Chuong3()
        {
            Console.Write("Nhập n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"S({n}) = {TinhS8(n):F4}");
            }
        }


        // Bài 1 Cuối sách
        static long TinhTong1DenN(int n)
        {
            if (n <= 1) return n;
            return n + TinhTong1DenN(n - 1);
        }

        static void Bai1CS()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 1)
            {
                Console.WriteLine($"S({n}) = {TinhTong1DenN(n)}");
            }
            else
            {
                Console.WriteLine("Vui lòng nhập n >= 1!");
            }
        }

        // Bài 2 Cuối sách
        static string DaoNguocChuoi(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;
            return DaoNguocChuoi(s.Substring(1)) + s[0];
        }

        static void Bai2CS()
        {
            Console.Write("Nhập chuỗi cần đảo ngược: ");
            string s = Console.ReadLine() ?? "";
            Console.WriteLine($"Chuỗi đảo ngược: \"{DaoNguocChuoi(s)}\"");
        }

        // Bài 3 Cuối sách
        static double TinhLuyThua(double x, int n)
        {
            if (n == 0) return 1;
            if (n < 0) return 1.0 / TinhLuyThua(x, -n);
            return x * TinhLuyThua(x, n - 1);
        }

        static void Bai3CS()
        {
            Console.Write("Nhập cơ sở x: ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                Console.Write("Nhập số mũ nguyên n: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    Console.WriteLine($"{x}^{n} = {TinhLuyThua(x, n)}");
                }
            }
        }

        // Bài 4 Cuối sách
        static int TimMaxDeQuy(int[] arr, int n)
        {
            if (n == 1) return arr[0];
            int maxConLai = TimMaxDeQuy(arr, n - 1);
            return arr[n - 1] > maxConLai ? arr[n - 1] : maxConLai;
        }

        static void Bai4CS()
        {
            int[] arr = { 12, 45, 7, 89, 23, 89, 14 };
            Console.WriteLine("Mảng: " + string.Join(", ", arr));
            Console.WriteLine($"Phần tử lớn nhất: {TimMaxDeQuy(arr, arr.Length)}");
        }

        // Bài 5 Cuối sách
        static int DemChuSo(int n)
        {
            if (n < 10) return 1;
            return 1 + DemChuSo(n / 10);
        }

        static void Bai5CS()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.WriteLine($"Số chữ số của {n} là: {DemChuSo(n)}");
            }
            else
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương!");
            }
        }

        // Bài 6 Cuối sách
        static void ChuyenThapHaNoi(int n, char cotA, char cotB, char cotC)
        {
            if (n == 1)
            {
                Console.WriteLine($"Chuyển 1 đĩa từ {cotA} -> {cotC}");
                return;
            }
            ChuyenThapHaNoi(n - 1, cotA, cotC, cotB);
            Console.WriteLine($"Chuyển 1 đĩa từ {cotA} -> {cotC}");
            ChuyenThapHaNoi(n - 1, cotB, cotA, cotC);
        }

        static void Bai6CS()
        {
            Console.Write("Nhập số đĩa n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 1)
            {
                ChuyenThapHaNoi(n, 'A', 'B', 'C');
            }
            else
            {
                Console.WriteLine("Vui lòng nhập số đĩa >= 1!");
            }
        }

        // Bài 7 Cuối sách
        static void SinhNhiPhan(int[] a, int i, int n)
        {
            if (i == n)
            {
                Console.WriteLine(string.Join("", a));
                return;
            }

            a[i] = 0;
            SinhNhiPhan(a, i + 1, n);

            a[i] = 1;
            SinhNhiPhan(a, i + 1, n);
        }

        static void Bai7CS()
        {
            Console.Write("Nhập độ dài dãy nhị phân n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 1)
            {
                int[] a = new int[n];
                Console.WriteLine($"Các dãy nhị phân độ dài {n}:");
                SinhNhiPhan(a, 0, n);
            }
            else
            {
                Console.WriteLine("Vui lòng nhập n >= 1!");
            }
        }
    }
}