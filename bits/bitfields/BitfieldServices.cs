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
        // public BitfieldModel Bitvector(BfOrigin origin, string name, ReadOnlySpan<ListItem> src)
        //     => Bitfields.bitvector(origin, name, src);


        // public ReadOnlySpan<BitfieldModel> EmitBitVectors(FS.Files src, FS.FolderPath dst)
        // {
        //     var count = src.Count;
        //     var bitfields = span<BitfieldModel>(count);
        //     var result = Outcome.Success;
        //     var counter = 0u;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var inpath = ref src[i];
        //         result = Tables.list(inpath, out var items);
        //         if(result.Fail)
        //         {
        //             Error(result.Message);
        //             continue;
        //         }
        //         var name = inpath.FileName.WithoutExtension.Format();
        //         var outpath = dst + inpath.FileName.ChangeExtension(FS.ext("bv"));
        //         var emitting = EmittingFile(outpath);
        //         var bitfield = Bitfields.bitvector(Bitfields.origin(inpath.ToUri()), name, items);
        //         using var writer = outpath.AsciWriter();
        //         writer.Write(bitfield.Format());
        //         EmittedFile(emitting, bitfield.SegCount);
        //         seek(bitfields,counter++) = bitfield;
        //     }
        //     return slice(bitfields,0, counter);
        // }
    }
}