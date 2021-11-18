//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public interface IBinaryContent
    {
        BinaryCode Data {get;}
    }

    public class CoffObj : IBinaryContent
    {
        public BinaryCode Data {get;}

        public CoffObj(BinaryCode data)
        {
            Data = data;
        }

        CoffObj()
        {
            Data = BinaryCode.Empty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public static CoffObj Empty => new CoffObj();
    }
}