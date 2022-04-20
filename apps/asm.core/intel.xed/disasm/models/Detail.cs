//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public class Detail : IComparable<Detail>
        {
            public readonly DataFile File;

            public readonly Index<DetailBlock> Blocks;

            [MethodImpl(Inline)]
            public Detail(in DataFile file, DetailBlock[] data)
            {
                File = file;
                Blocks = data;
            }

            public ref readonly FileRef Origin
            {
                [MethodImpl(Inline)]
                get => ref File.Origin;
            }

            public ref readonly FileRef Source
            {
                [MethodImpl(Inline)]
                get => ref File.Source;
            }

            public uint Seq
            {
                [MethodImpl(Inline)]
                get => File.Source.Seq;
            }

            public ref DetailBlock this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Blocks[i];
            }

            public ref DetailBlock this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Blocks[i];
            }

            public FS.FilePath Path
            {
                [MethodImpl(Inline)]
                get => File.Source.Path;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Blocks.Count;
            }

            public int CompareTo(Detail src)
                => Seq.CompareTo(src.Seq);

            public static Detail Empty => new Detail(DataFile.Empty, sys.empty<DetailBlock>());
        }
    }
}