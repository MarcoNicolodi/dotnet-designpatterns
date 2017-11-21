using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var file = new File(){ name = "spreadsheet", ext = "ods", size = 40000 };
            
            var storage = new StorageService(new LocalStorage());           
            
            storage.Move(file, "/temporary");
            storage.Upload(file);
            storage.Delete(file, "/deleted");

            storage.Strategy = new AzureStorage();

            storage.Move(file, "/temporary");
            storage.Upload(file);
            storage.Delete(file, "/deleted");
        }
    }
}
