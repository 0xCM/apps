//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmForms : ConstLookup<Identifier,AsmFormDescriptor>
    {
        public AsmForms(Dictionary<Identifier,AsmFormDescriptor> src)
            : base(src)
        {


        }

        public static implicit operator AsmForms(Dictionary<Identifier,AsmFormDescriptor> src)
            => new AsmForms(src);
    }
}