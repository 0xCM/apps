//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public class Seq8u : LiteralSeq<byte>
        {
            public Seq8u(Identifier name, Literal<byte>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq8i : LiteralSeq<sbyte>
        {
            public Seq8i(Identifier name, Literal<sbyte>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq16u : LiteralSeq<ushort>
        {
            public Seq16u(Identifier name, Literal<ushort>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq16i : LiteralSeq<short>
        {
            public Seq16i(Identifier name, Literal<short>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq32u : LiteralSeq<uint>
        {
            public Seq32u(Identifier name, Literal<uint>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq32i : LiteralSeq<int>
        {
            public Seq32i(Identifier name, Literal<int>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq64u : LiteralSeq<ulong>
        {
            public Seq64u(Identifier name, Literal<ulong>[] values)
                : base(name, values)
            {

            }
        }

        public class Seq64i : LiteralSeq<long>
        {
            public Seq64i(Identifier name, Literal<long>[] values)
                : base(name, values)
            {

            }
        }
    }
}