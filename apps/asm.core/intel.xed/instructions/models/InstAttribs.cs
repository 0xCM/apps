//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly struct InstAttribs : IIndex<AttributeKind>
        {
            readonly Index<AttributeKind> Data;

            [MethodImpl(Inline)]
            public InstAttribs(AttributeKind[] src)
            {
                Data = src;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public AttributeKind[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref AttributeKind this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref AttributeKind this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public InstAttribs Sort()
            {
                Data.Sort();
                return this;
            }

            public bool Locked
            {
                [MethodImpl(Inline)]
                get => Data.Any(x => x == AttributeKind.LOCKED);
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstAttribs(AttributeKind[] src)
                => new InstAttribs(src);

            [MethodImpl(Inline)]
            public static implicit operator AttributeKind[](InstAttribs src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<AttributeKind>(InstAttribs src)
                => src.Data;

            public static InstAttribs Empty => sys.empty<AttributeKind>();
        }
    }
}