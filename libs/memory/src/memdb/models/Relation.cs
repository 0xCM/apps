//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct Relation16 : IEntity<Relation16,uint>
        {
            public readonly ushort Source;

            public readonly ushort Target;            

            [MethodImpl(Inline)]
            public Relation16(ushort src, ushort dst)
            {
                Source = src;
                Target = dst;
            }

            [MethodImpl(Inline)]
            public Relation16(Arrow<ushort> def)
            {
                Source = def.Source;
                Target = def.Target;
            }

            public uint Key
            {
                [MethodImpl(Inline)]
                get => (uint)Source | (uint)Target << 16;
            }

            public Arrow<ushort> Arrow
            {
                [MethodImpl(Inline)]
                get => (Source,Target);
            }

            [MethodImpl(Inline)]
            public int CompareTo(Relation16 src)
            {
                var result = Source.CompareTo(src.Source);
                if(result==0)
                    result = Target.CompareTo(src.Target);
                return result;
            }

            [MethodImpl(Inline)]
            public static explicit operator Relation16(uint id)
            {
                split(id, out var src, out var dst);
                return new Relation16(src,dst);
            }

            [MethodImpl(Inline)]
            public static explicit operator uint(Relation16 src)
                => src.Key;

            [MethodImpl(Inline)]
            public static implicit operator Relation16((ushort src, ushort dst) x)
                => new Relation16(x.src, x.dst);

            [MethodImpl(Inline)]
            public static implicit operator Arrow<ushort>(Relation16 def)
                => def.Arrow;

            [MethodImpl(Inline)]
            public static implicit operator Relation16(Arrow<ushort> def)
                => new Relation16(def);
        }
    }
}