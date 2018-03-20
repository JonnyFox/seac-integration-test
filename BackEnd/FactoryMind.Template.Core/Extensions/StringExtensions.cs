using System.IO;

namespace FactoryMind.Template.Core.Extensions
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
