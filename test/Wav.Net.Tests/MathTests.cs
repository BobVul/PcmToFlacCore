using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using WavMath = WavDotNet.Tools.Math;

namespace Wav.Net.Tests
{
    public class MathTests
    {
        [Fact]
        public void TestToDecibels()
        {
            Assert.Equal(WavMath.ToDecibels(10D), 20);
            Assert.Equal(WavMath.ToDecibels(10F), 20);
            Assert.Equal(WavMath.ToDecibels(100D), 40);
            Assert.Equal(WavMath.ToDecibels(100F), 40);
        }

        [Fact]
        public void TestToAmplitude()
        {
            Assert.Equal(WavMath.ToAmplitude(100D), 100000);
            Assert.Equal(WavMath.ToAmplitude(100F), 100000);
        }
    }
}
