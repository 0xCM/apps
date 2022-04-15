//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmDetailDoc
    {
        public readonly DisasmFile File;

        public readonly Index<DetailBlock> Blocks;

        [MethodImpl(Inline)]
        public DisasmDetailDoc(DisasmFile file, DetailBlock[] data)
        {
            File = file;
            Blocks = data;
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

        public static DisasmDetailDoc Empty => new DisasmDetailDoc(DisasmFile.Empty, sys.empty<DetailBlock>());
    }
}