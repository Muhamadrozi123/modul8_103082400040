using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace modul8_103082400040
{
    public class TransferConfig
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class ConfirmationConfig
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public class BankTransferConfig
    {
        public string lang { get; set; }
        public TransferConfig transfer { get; set; }
        public List<string> methods { get; set; }
        public ConfirmationConfig confirmation { get; set; }

        private const string CONFIG_FILE = "bank_transfer_config.json";

        public static BankTransferConfig Load()
        {
            if (!File.Exists(CONFIG_FILE))
            {
                // Return default values jika file tidak ada
                return new BankTransferConfig
                {
                    lang = "en",
                    transfer = new TransferConfig
                    {
                        threshold = 25000000,
                        low_fee = 6500,
                        high_fee = 15000
                    },
                    methods = new List<string> { "RTO(real-time)", "SKN", "RTGS", "BI FAST" },
                    confirmation = new ConfirmationConfig
                    {
                        en = "yes",
                        id = "ya"
                    }
                };
            }

            string json = File.ReadAllText(CONFIG_FILE);
            return JsonSerializer.Deserialize<BankTransferConfig>(json);
        }
    }
}