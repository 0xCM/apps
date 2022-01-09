//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public sealed class BitfieldServices : AppService<BitfieldServices>
    {
        public ReadOnlySpan<BitfieldModel> EmitBitVectors(ReadOnlySpan<FS.FilePath> src, FS.FolderPath dst)
        {
            var count = src.Length;
            var bitfields = span<BitfieldModel>(count);
            var result = Outcome.Success;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var inpath = ref skip(src,i);
                result = Tables.list(inpath, out var items);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }
                var name = inpath.FileName.WithoutExtension.Format();
                var outpath = dst + inpath.FileName.ChangeExtension(FS.ext("bv"));
                var emitting = EmittingFile(outpath);
                var bitfield = Bitfields.bitvector(name, items);
                using var writer = outpath.AsciWriter();
                writer.Write(bitfield.Format());
                EmittedFile(emitting, bitfield.SegCount);
                seek(bitfields,counter++) = bitfield;
            }
            return slice(bitfields,0, counter);
        }
    }
}