using System;

namespace Strategy {
    public class LocalStorage : IStorageStrategy
    {
        public void Delete(File file)
        {
            Console.WriteLine($"Deleted with {this.GetType().Name} Strategy");
        }

        public void Move(File file, string path)
        {
            Console.WriteLine($"Moved with {this.GetType().Name} Strategy");
        }

        public void Upload(File file)
        {
            Console.WriteLine($"Uploaded with {this.GetType().Name} Strategy");
        }
    }

}