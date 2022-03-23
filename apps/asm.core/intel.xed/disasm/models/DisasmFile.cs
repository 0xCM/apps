//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public readonly struct DisasmFile
        {
            public readonly FileRef Source;

            public readonly Index<DisasmLineBlock> Lines;

            [MethodImpl(Inline)]
            public DisasmFile(FileRef src, DisasmLineBlock[] lines)
            {
                Source = src;
                Lines = lines;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Lines.Count;
            }

            public ref readonly DisasmLineBlock this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Lines[i];
            }

            public ref readonly DisasmLineBlock this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Lines[i];
            }
        }
    }
}