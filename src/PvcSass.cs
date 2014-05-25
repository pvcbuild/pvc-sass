using PvcCore;
using SassAndCoffee.Ruby.Sass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvcPlugins
{
    public class PvcSass : PvcPlugin
    {
        public override string[] SupportedTags
        {
            get
            {
                return new string[] { ".sass", ".scss" };
            }
        }

        public override IEnumerable<PvcCore.PvcStream> Execute(IEnumerable<PvcCore.PvcStream> inputStreams)
        {
            var resultStreams = new List<PvcStream>();

            foreach (var inputStream in inputStreams)
            {
                var sassContent = PvcUtil.StreamToTempFile(inputStream);
                var cssContent = new SassCompiler().Compile(sassContent, false, null);

                var newStreamName = Path.Combine(Path.GetDirectoryName(inputStream.StreamName), Path.GetFileNameWithoutExtension(inputStream.StreamName) + ".css");
                var resultStream = PvcUtil.StringToStream(cssContent, newStreamName);
                resultStreams.Add(resultStream);
            }

            return resultStreams;
        }
    }
}
