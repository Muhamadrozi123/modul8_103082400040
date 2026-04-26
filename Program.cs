using modul8_103082400040;
using System;

namespace modul8_103082400040
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load konfigurasi
            var config = BankTransferConfig.Load();

            // Step 1: Input jumlah uang
            if (config.lang == "en")
            {
                Console.Write("Please insert the amount of money to transfer: ");
            }
            else
            {
                Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
            }

            long nominalTransfer = long.Parse(Console.ReadLine());

            // Step 2: Hitung biaya transfer
            int biayaTransfer;
            if (nominalTransfer <= config.transfer.threshold)
            {
                biayaTransfer = config.transfer.low_fee;
            }
            else
            {
                biayaTransfer = config.transfer.high_fee;
            }

            long totalBayar = nominalTransfer + biayaTransfer;

            // Step 3: Tampilkan biaya dan total
            if (config.lang == "en")
            {
                Console.WriteLine($"Transfer fee= {biayaTransfer}");
                Console.WriteLine($"Total amount= {totalBayar}");
            }
            else
            {
                Console.WriteLine($"Biaya transfer= {biayaTransfer}");
                Console.WriteLine($"Total biaya= {totalBayar}");
            }

            // Step 4: Tampilkan metode transfer
            if (config.lang == "en")
            {
                Console.Write("Select transfer method: ");
            }
            else
            {
                Console.Write("Pilih metode transfer: ");
            }
            Console.WriteLine();

            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }

            // Step 5: Input metode transfer (tidak diproses lebih lanjut)
            Console.Write("Masukkan pilihan metode transfer: ");
            string pilihanMetode = Console.ReadLine();

            // Step 6: Konfirmasi transaksi
            if (config.lang == "en")
            {
                Console.Write($"Please type \"{config.confirmation.en}\" to confirm the transaction: ");
            }
            else
            {
                Console.Write($"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi: ");
            }

            string konfirmasi = Console.ReadLine();

            // Step 7: Proses konfirmasi
            bool isConfirmed = false;
            if (config.lang == "en")
            {
                isConfirmed = (konfirmasi.ToLower() == config.confirmation.en.ToLower());
            }
            else
            {
                isConfirmed = (konfirmasi.ToLower() == config.confirmation.id.ToLower());
            }

            if (isConfirmed)
            {
                if (config.lang == "en")
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
            }
            else
            {
                if (config.lang == "en")
                {
                    Console.WriteLine("Transfer is cancelled");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }

            Console.ReadLine(); // Tahan console
        }
    }
}