//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedDisasm
    {
        public readonly struct DisasmOpDetails : IIndex<DisasmOpDetail>
        {
            readonly Index<DisasmOpDetail> Data;

            [MethodImpl(Inline)]
            public DisasmOpDetails(DisasmOpDetail[] src)
            {
                Data = src;
            }

            public DisasmOpDetail[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public int Length
            {
                [MethodImpl(Inline)]
                get => Data.Length;
            }

            public ref DisasmOpDetail this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref DisasmOpDetail this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public bool Search(OpWidthCode match, byte offset, out DisasmOpDetail dst)
            {
                var result = false;
                dst = default;
                for(var i=offset; i<Count; i++)
                {
                    ref readonly var op = ref Data[i];
                    if(op.OpWidth.Code == match)
                    {
                        dst = op;
                        result = true;
                        break;
                    }
                }
                return result;
            }

            public bool Search(OpWidthCode match, out DisasmOpDetail dst)
                => Search(match,0,out dst);

            public string Format()
                => XedRender.format(this);


            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator DisasmOpDetails(DisasmOpDetail[] src)
                => new DisasmOpDetails(src);

            [MethodImpl(Inline)]
            public static implicit operator DisasmOpDetail[](DisasmOpDetails src)
                => src.Storage;
        }
    }
}