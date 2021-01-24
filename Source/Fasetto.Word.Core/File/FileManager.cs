using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Handles reading/writing and querying the file system
    /// </summary>
    public class FileManager : IFileManager
    {
        public string NormalizePath(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return path?.Replace('/', '\\').Trim();
            }
            else
            {
                return path?.Replace('\\', '/').Trim();
            }
        }

        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }

        public async Task WriteAllTextToFileAsync(string text, string path, bool append = false)
        {
            path = NormalizePath(path);

            path = ResolvePath(path); 

            await AsyncAwaiter.AwaitAsync(nameof(WriteAllTextToFileAsync) + path, async () =>
             {
                 await IoC.Task.Run(() =>
                 {
                     using (var fileStrem = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                     {
                         fileStrem.Write(text);
                     }
                 }); 
             });
        }
    }
}
