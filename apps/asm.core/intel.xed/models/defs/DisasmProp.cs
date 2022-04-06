//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasm
    {
        public readonly struct DisasmProp : IEquatable<DisasmProp>, IComparable<DisasmProp>
        {
            readonly CellValue Data;

            readonly Func<CellValue,string> Render;

            [MethodImpl(Inline)]
            public DisasmProp(CellValue data, Func<CellValue,string> render)
            {
                Data = data;
                Render = render;
            }

            [MethodImpl(Inline)]
            public DisasmProp(CellValue data)
            {
                Data = data;
                Render = XedRender.format;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Data.Field;
            }

            public ulong Value
            {
                [MethodImpl(Inline)]
                get => Data.Data;
            }

            [MethodImpl(Inline)]
            public int CompareTo(DisasmProp src)
            {
                var result = ((byte)Field).CompareTo((byte)src.Field);
                if(result == 0)
                    result = Value.CompareTo(src.Value);
                return result;
            }

            public string Format()
                => Render(Data);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(DisasmProp src)
                => Data.Equals(src.Data);

            public override bool Equals(object src)
                => src is DisasmProp x && Equals(x);

            public override int GetHashCode()
                => (int)Data.Hash;

            [MethodImpl(Inline)]
            public static implicit operator DisasmProp(CellValue src)
                => new DisasmProp(src);
        }
    }
}