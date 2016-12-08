using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PcmToFlacCore.Tests
{
    public class Class1
    {
        [Fact]
        public void TestMono()
        {
            File.WriteAllBytes(@"bensound-littleidea-48k-s16le-mono.flac", PcmToFlac.Convert(File.ReadAllBytes(@"bensound-littleidea-48k-s16le-mono.raw"), 1));
        }

        [Fact]
        public void TestStereo()
        {
            File.WriteAllBytes(@"bensound-littleidea-48k-s16le-stereo.flac", PcmToFlac.Convert(File.ReadAllBytes(@"bensound-littleidea-48k-s16le-stereo.raw"), 2));
        }
    }
}
