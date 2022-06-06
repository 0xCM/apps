//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmOpCodeMap : ConstLookup<Identifier,Index<InstEntity>>
    {
        public LlvmOpCodeMap(Dictionary<Identifier,Index<InstEntity>> src)
            : base(src)
        {


        }

        public static implicit operator LlvmOpCodeMap(Dictionary<Identifier,Index<InstEntity>> src)
            => new LlvmOpCodeMap(src);
    }
}