//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ImageMemory
    {
        [Op]
        public static ReadOnlySeq<ProcessMemoryRegion> regions()
            => pages(MemoryNode.snapshot().Describe());

        [Op]
        public static ReadOnlySeq<ProcessMemoryRegion> regions(int procid)
            => pages(MemoryNode.snapshot(procid).Describe());

        [Op]
        public static ReadOnlySeq<ProcessMemoryRegion> regions(Process src)
            => pages(MemoryNode.snapshot(src.Id).Describe());

        public static Outcome parse(string src, out ProcessMemoryRegion dst)
        {
            dst = default;
            if(text.empty(src))
                return false;

            var count = ProcessMemoryRegion.FieldCount;
            var parts = text.split(src,Chars.Pipe);
            if(parts.Length != ProcessMemoryRegion.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(parts.Length, count));

            var buffer = alloc<Outcome>(count);
            ref var outcomes = ref first(buffer);

            var i=0;
            var j=0;
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Index);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Identity);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.StartAddress);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.EndAddress);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Size);
            seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.Type);
            seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.Protection);
            seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.State);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.FullIdentity);
            return true;
        }
    }
}