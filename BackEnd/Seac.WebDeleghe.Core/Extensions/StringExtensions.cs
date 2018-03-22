using System.IO;

namespace Seac.WebDeleghe.Core.Extensions
{
    public static class StringExtensions
    {
        public static Stream AsStream(this string source)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(source);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
