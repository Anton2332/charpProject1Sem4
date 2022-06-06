
using DAL_Project2;
using (DBContext db = new DBContext())
{
    bool isAvalaible = db.Database.CanConnect();
    // bool isAvalaible2 = await db.Database.CanConnectAsync();
    if (isAvalaible) Console.WriteLine("База данных доступна");
    else Console.WriteLine("База данных не доступна");
}

