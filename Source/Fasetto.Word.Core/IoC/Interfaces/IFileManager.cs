
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Handles reading/writing and querying the file system
    /// </summary>
    public interface IFileManager
    {
        Task WriteAllTextToFileAsync(string text, string path, bool append = false);

        string NormalizePath(string path);

        string ResolvePath(string path);
    }
}
