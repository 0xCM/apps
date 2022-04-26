//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct Relation : IElement<Relation>
        {
            public readonly ushort Source;

            public readonly ushort Target;

            [MethodImpl(Inline)]
            public Relation(ushort src, ushort dst)
            {
                Source = src;
                Target = dst;
            }

            [MethodImpl(Inline)]
            public Relation(Arrow<ushort> def)
            {
                Source = def.Source;
                Target = def.Target;
            }

            public uint Id
            {
                [MethodImpl(Inline)]
                get => Bitfields.join(Source,Target);
            }

            public Arrow<ushort> Arrow
            {
                [MethodImpl(Inline)]
                get => (Source,Target);
            }

            [MethodImpl(Inline)]
            public int CompareTo(Relation src)
            {
                var result = Source.CompareTo(src.Source);
                if(result==0)
                    result = Target.CompareTo(src.Target);
                return result;
            }

            [MethodImpl(Inline)]
            public static explicit operator Relation(uint id)
            {
                Bitfields.split(id, out var src, out var dst);
                return new Relation(src,dst);
            }

            [MethodImpl(Inline)]
            public static explicit operator uint(Relation src)
                => src.Id;

            [MethodImpl(Inline)]
            public static implicit operator Relation((ushort src, ushort dst) x)
                => new Relation(x.src, x.dst);

            [MethodImpl(Inline)]
            public static implicit operator Arrow<ushort>(Relation def)
                => def.Arrow;

            [MethodImpl(Inline)]
            public static implicit operator Relation(Arrow<ushort> def)
                => new Relation(def);
        }
    }
}