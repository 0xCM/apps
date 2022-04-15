//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmDetailDoc : IComparable<DisasmDetailDoc>
    {
        public readonly DisasmFile File;

        public readonly Index<DetailBlock> Blocks;

        [MethodImpl(Inline)]
        public DisasmDetailDoc(DisasmFile file, DetailBlock[] data)
        {
            File = file;
            Blocks = data;
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

        public int CompareTo(DisasmDetailDoc src)
            => Seq.CompareTo(src.Seq);

        public static DisasmDetailDoc Empty => new DisasmDetailDoc(DisasmFile.Empty, sys.empty<DetailBlock>());
    }
}