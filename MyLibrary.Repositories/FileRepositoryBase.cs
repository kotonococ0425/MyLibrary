namespace MyLibrary.Repositories;

/// <summary>
/// ファイルによってデータの永続化を行う基底クラス
/// </summary>
public abstract class FileRepositoryBase<T> : IRepository<T>
{
    /// <summary>
    /// データの永続化に使用するファイルパス。(拡張子不要)
    /// </summary>
    public string FilePath { get => _filePath; set => _filePath = AppendExtension(value); }
    private string _filePath = "";

    /// <summary>
    /// <see cref="FilePath"/> からデシリアライズされた <see cref="T"/> のインスタンスを取得する。
    /// </summary>
    /// <returns>デシリアライズされた <see cref="T"/> のインスタンス。</returns>
    public abstract T? Find();

    /// <summary>
    /// <see cref="FilePath"/> からデシリアライズされた <see cref="T"/> のインスタンスを取得する。
    /// </summary>
    /// <returns>デシリアライズされた <see cref="T"/> のインスタンス。</returns>
    public abstract Task<T?> FindAsync();

    /// <summary>
    /// <paramref name="instance"/> をシリアライズし、<see cref="FilePath"/> に保存する
    /// </summary>
    /// <param name="instance">シリアライズ対象のインスタンス</param>
    /// <returns></returns>
    public abstract void Save(T instance);

    /// <summary>
    /// <paramref name="instance"/> をシリアライズし、<see cref="FilePath"/> に保存する
    /// </summary>
    /// <param name="instance">シリアライズ対象のインスタンス</param>
    /// <returns></returns>
    public abstract Task SaveAsync(T instance);

    public virtual void BeforeSave()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
    }

    /// <summary>
    /// 拡張子
    /// </summary>
    protected abstract string Extension { get; }

    /// <summary>
    /// <paramref name="filePath"/> に拡張子が無ければ追加する。
    /// </summary>
    /// <returns>拡張子をつけられたファイルパス。</returns>
    private string AppendExtension(string filePath)
    {
        return filePath.EndsWith(Extension) ? filePath : $"{filePath}{Extension}";
    }
}
