using FlacBox;
using GSF;
using GSF.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PcmToFlacCore
{
    public class PcmToFlac
    {
        public static byte[] Convert(byte[] input, int channels)
        {
            using (var dest = new MemoryStream())
            {
                using (var resampledSource = new MemoryStream())
                {
                    ushort[] sdata = new ushort[(int)Math.Ceiling((decimal)input.Length / 2)];
                    Buffer.BlockCopy(input, 0, sdata, 0, input.Length);

                    var file = new WaveFile(SampleRate.Hz48000, BitsPerSample.Bits16, channels == 1 ? DataChannels.Mono : DataChannels.Stereo, WaveFormat.PCM);
                    // https://stackoverflow.com/questions/13316718/explicit-implicit-cast-operator-fails-when-using-linqs-cast-operator
                    foreach (var s in sdata)
                    {
                        file.AddSample(s);
                    }
                    file.Save(resampledSource);
                    
                    using (var encStream = new WaveOverFlacStream(dest, WaveOverFlacStreamMode.Encode, true))
                    {
                        var buf = resampledSource.ToArray();
                        encStream.Write(buf, 0, buf.Length);
                    }

                    return dest.ToArray();
                }
            }
        }
    }
}
