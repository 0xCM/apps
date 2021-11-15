//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    public sealed class CodeBlock : Block
    {
        public CodeBlock(IComponent owner, uint key, BinaryCode def)
            : base(owner,key)
        {

            Definition = def;
        }

        public BinaryCode Definition {get;}
    }
}