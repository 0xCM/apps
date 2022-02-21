//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelIntrinsics
    {
        public readonly struct DataType : ITextual
        {
            public string Name {get;}

            [MethodImpl(Inline)]
            public DataType(string src)
            {
                Name = src;
            }

            public string Format()
                => Name;

            public override string ToString()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator DataType(string src)
                => new DataType(src);
        }
    }
}