//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public Outcome ImportVolume(byte vol)
        {
            var result = Outcome.Success;
            var src = SdmPaths.SdmSrcPath(vol);
            var dst = SdmPaths.SdmDstPath(vol);
            var emitting = EmittingFile(dst);
            var counter = 0u;
            using var reader = src.UnicodeLineReader();
            using var writer = dst.UnicodeWriter();
            while(reader.Next(out var line))
            {
                writer.WriteLine(line.Format());
                counter++;
            }
            EmittedFile(emitting,counter);
            return result;
        }
    }
}