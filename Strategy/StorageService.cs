namespace Strategy {
    public class StorageService {
        private IStorageStrategy _strategy;
        
        public IStorageStrategy Strategy {
            get {
                return _strategy;
            }
            set {
                _strategy = value;
            }
        }
        
        public StorageService(IStorageStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Upload(File file)
        {
            _strategy.Upload(file);
        }

        public void Delete(File file, string path)
        {
            _strategy.Delete(file);
        }

        public void Move(File file, string path)
        {
            _strategy.Move(file, path);
        }
    }
}