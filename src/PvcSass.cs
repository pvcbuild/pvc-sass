using PvcCore;
using SassAndCoffee.Ruby.Sass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvcSass
{
    public class PvcSass : PvcPlugin
    {
        public override IEnumerable<PvcCore.PvcStream> Execute(IEnumerable<PvcCore.PvcStream> inputStreams)
        {
            var resultStreams = new List<PvcStream>();

            foreach (var inputStream in inputStreams)
            {
                var sassContent = PvcUtil.StreamToTempFile(inputStream);
                var cssContent = new SassCompiler().Compile(sassContent, false, null);

                var resultStream = PvcUtil.StringToStream(cssContent, inputStream.StreamName);
                resultStreams.Add(resultStream);
            }

            return resultStreams;
        }
    }
}
