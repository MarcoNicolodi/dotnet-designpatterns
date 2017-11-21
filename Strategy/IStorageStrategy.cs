using System.IO;

public interface IStorageStrategy {
    void Upload(Strategy.File file);
    void Delete(Strategy.File file);
    void Move(Strategy.File file, string path);    
}