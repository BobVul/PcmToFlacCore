using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WavDotNet.Core;
using Xunit;

namespace Wav.Net.Tests
{
    public class SamplesTests
    {
        [Fact]
        public void ArrayConstructor()
        {
            var testSamples = new int[1000];
            for (var i = 0; i < 1000; i++)
            {
                testSamples[i] = i;
            }
            var samples = new Samples<int>(testSamples);

            Assert.NotNull(samples);
            Assert.Equal(1000, samples.Count);
            Assert.Equal(100, samples[100]);
            Assert.Equal(typeof(int), samples.SampleType);

            var j = 0;
            foreach (var sample in samples)
            {
                Assert.Equal(j, sample);
                j++;
            }
        }

        [Fact]
        public void ListConstructor()
        {
            var testSamples = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                testSamples.Add(i);
            }
            var samples = new Samples<int>(testSamples);

            Assert.NotNull(samples);
            Assert.Equal(1000, samples.Count);
            Assert.Equal(100, samples[100]);
            Assert.Equal(typeof(int), samples.SampleType);

            var j = 0;
            foreach (var sample in samples)
            {
                Assert.Equal(j, sample);
                j++;
            }
        }

        [Fact]
        public void IEnumerableConstructor()
        {
            var testSamples = new Queue<int>();
            for (var i = 0; i < 1000; i++)
            {
                testSamples.Enqueue(i);
            }
            var samples = new Samples<int>(testSamples);

            Assert.NotNull(samples);
            Assert.Equal(1000, samples.Count);
            Assert.Equal(100, samples[100]);
            Assert.Equal(typeof(int), samples.SampleType);

            var j = 0;
            foreach (var sample in samples)
            {
                Assert.Equal(j, sample);
                j++;
            }
        }

        [Fact]
        public void ManualConstructor()
        {
            var testSamples = new int[1000];
            for (var i = 0; i < 1000; i++)
            {
                testSamples[i] = i;
            }
            var samples = new Samples<int>(() => testSamples.Length, i => testSamples[i], testSamples.GetEnumerator());

            Assert.NotNull(samples);
            Assert.Equal(1000, samples.Count);
            Assert.Equal(100, samples[100]);
            Assert.Equal(typeof(int), samples.SampleType);

            var j = 0;
            foreach (var sample in samples)
            {
                Assert.Equal(j, sample);
                j++;
            }
        }
    }
}
