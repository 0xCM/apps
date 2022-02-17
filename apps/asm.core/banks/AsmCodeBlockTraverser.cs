//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    public abstract class AsmCodeBlockTraverser
    {
        public virtual void Traverse(ReadOnlySpan<AsmCodeBlocks> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var blocks = ref skip(src,i);
                Traverse(blocks);
            }
        }

        public virtual void Traverse(in AsmCodeBlocks src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref src[i];
                Traverse(block);
            }
        }

        public virtual void Traverse(in AsmCodeBlock src)
        {
            var count = src.LineCount;
            for(var i=0; i<count;i++)
            {
                ref readonly var code = ref src[i];
                Traverse(code);
            }
        }


        public virtual void Traverse(in AsmCode src)
        {

        }
    }
}