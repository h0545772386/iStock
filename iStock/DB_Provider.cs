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
    }
}
