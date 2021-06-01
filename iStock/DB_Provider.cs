using System.Linq;

namespace iStock
{
    // מחלקה לטיפול מול בסיס הנתונים
    public class DB_Provider
    {
        //מביא את מספר העובד הפנוי הבא בעת יצירת עובד חדש
        // כדי למנוע יצירת עובד עם אותו מספר
        public static int GetNextWorkerNumber()
        {
            int wn = 0;
            using (var db = new Model1())
            {
                wn = db.Materials.Max(x => x.MatId);
            }
            if (wn != 0)
            {
                return wn + 8;
            }
            else
            {
                return 100500;
            }
        }

        // פונקיצה שבודקת אם מספר חומר כבר קיים בבסיס הנתונים או לא
        // אם קיים מספר חומר אז הפונקציה מחזירה TRUE
        public static bool MatIdAlreadyExist(int MatId)
        {
            Material m = null;
            using (var db = new Model1())
            {
                m = db.Materials.FirstOrDefault(x => x.MatId == MatId);
            }
            if (m != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetLoadNum()
        {
            int trnid = 0;
            Transaction t = null;
            using (var db = new Model1())
            {
                if (db.Transactions.ToList() != null && db.Transactions.ToList().Count > 0)
                    trnid = db.Transactions.Max(x => x.TrnId);
                t = db.Transactions.FirstOrDefault(x => x.TrnId == trnid);
            }

            if (t != null)
            {
                return t.LoadNum + 7;
            }
            return 164;
        }
    }
}
