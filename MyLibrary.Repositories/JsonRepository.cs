using Newtonsoft.Json;

namespace MyLibrary.Repositories;

/// <summary>
/// Json形式のファイルによってデータの永続化を行うクラス
/// </summary>
/// <typeparam name="T"><see cref="JsonObjectAttribute"/> を与えられたクラス。</typeparam>
public class JsonRepository<T> : FileRepositoryBase<T>
{
    protected override string Extension { get; } = ".json";

    public override T? Find()
    {
        if (File.Exists(FilePath))
        {
            var jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
        else
        {
            return default;
        }
    }

    public override async Task<T?> FindAsync()
    {
        if (File.Exists(FilePath))
        {
            var jsonData = await File.ReadAllTextAsync(FilePath);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
        else
        {
            return default;
        }
    }

    public override void Save(T instance)
    {
        BeforeSave();
        var jsonData = JsonConvert.SerializeObject(instance, Formatting.Indented);
        File.WriteAllText(FilePath, jsonData);
    }

    public override async Task SaveAsync(T instance)
    {
        BeforeSave();
        var jsonData = JsonConvert.SerializeObject(instance, Formatting.Indented);
        await File.WriteAllTextAsync(FilePath, jsonData);
    }
}
