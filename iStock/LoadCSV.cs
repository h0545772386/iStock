using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace iStock
{
    public class LoadCSV
    {
        public static List<RecCSV> LoadCSVFromFile(string FilePath)
        {
            List<RecCSV> LRC = File.ReadAllLines(FilePath)
                                          .Skip(1)
                                          .Select(v => RecCSV.FromCsv(v))
                                          .ToList();
            return LRC;
        }

        public static List<Transaction> LoadCSV2Transaction(string FilePath)
        {
            List<Transaction> LTs = new List<Transaction>();
            List<RecCSV> LRC = File.ReadAllLines(FilePath)
                                          .Skip(1)
                                          .Select(v => RecCSV.FromCsv(v))
                                          .ToList();
            if (LRC != null)
            {
                LRC.ForEach(x => LTs.Add(x.Convet2Transaction()));
            }
            var Batch1 = UTILS.GetBatch1(DateTime.Now);
            LTs.ForEach(x => x.Batch1 = Batch1);
            LTs.ForEach(x => x.Status = "פעיל");
            return LTs;
        }

    }

    public class RecCSV
    {
        public int MatId { get; set; }

        public string Direction { get; set; }  /*IN or OUT*/

        public decimal TrnQTY { get; set; }

        public string UOM { get; set; }

        public string Error { get; set; }

        internal static RecCSV FromCsv(string csvLine)
        {
            RecCSV rc = new RecCSV();
            string[] values = csvLine.Split(',');
            rc.MatId = Convert.ToInt32(values[0]);
            rc.Direction = values[1].Trim();
            rc.TrnQTY = Convert.ToDecimal(values[2]);
            rc.UOM = values[3].Trim();
            rc.Error = "";
            return rc;
        }

        internal Transaction Convet2Transaction()
        {
            Transaction t = new Transaction();
            t.Date1 = DateTime.Today.DateToINT_YYYYMMDD();
            t.MatId = this.MatId;
            t.Direction = this.Direction;
            t.TrnQTY = this.TrnQTY;
            t.UOM1 = this.UOM;
            return t;
        }
    }

}
