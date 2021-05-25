using System.Collections.Generic;

namespace iStock
{
    public class UOM
    {
        public int Id { get; set; }
        public int Sort { get; set; }
        public int Numer { get; set; }
        public string Name1 { get; set; }
    }

    public class LUOM : List<UOM>
    {
        public LUOM()
        {
            this.Add(new UOM() { Id = 10, Sort = 1, Numer = 1, Name1 = "יחידה" });
            this.Add(new UOM() { Id = 11, Sort = 1, Numer = 1, Name1 = "קרטון" });
            this.Add(new UOM() { Id = 12, Sort = 1, Numer = 1, Name1 = "מארז" });
            this.Add(new UOM() { Id = 13, Sort = 2, Numer = 1, Name1 = "סנטימטר" });
            this.Add(new UOM() { Id = 14, Sort = 2, Numer = 1, Name1 = "מטר" });
            this.Add(new UOM() { Id = 15, Sort = 2, Numer = 1, Name1 = "קילומטר" });
            this.Add(new UOM() { Id = 16, Sort = 3, Numer = 1, Name1 = "גרם" });
            this.Add(new UOM() { Id = 17, Sort = 3, Numer = 1, Name1 = "קילוגרם" });
            this.Add(new UOM() { Id = 18, Sort = 3, Numer = 1, Name1 = "טון" });
            this.Add(new UOM() { Id = 20, Sort = 4, Numer = 1, Name1 = "מלילטר" });
            this.Add(new UOM() { Id = 21, Sort = 4, Numer = 1, Name1 = "לטר" });
            this.Add(new UOM() { Id = 22, Sort = 4, Numer = 1, Name1 = "קוב" });
        }
    }
}
