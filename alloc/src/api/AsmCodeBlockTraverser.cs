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
        public void Traverse(ReadOnlySpan<AsmCodeBlocks> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var blocks = ref skip(src,i);
                Traverse(blocks);
            }
        }

        public void Traverse(in AsmCodeBlocks src)
        {
            Traversing(src);
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref src[i];
                Traverse(block);
            }
            Traversed(src);
        }

        public void Traverse(in AsmCodeBlock src)
        {
            Traversing(src);
            var count = src.Count;
            for(var i=0; i<count;i++)
            {
                ref readonly var code = ref src[i];
                Traverse(code);
            }
            Traversed(src);
        }

        public void Traverse(in AsmCode src)
        {
            Traversing(src);
            Traversed(src);
        }


        protected virtual void Traversing(in AsmCodeBlocks src)
        {

        }

        protected virtual void Traversing(in AsmCodeBlock src)
        {

        }

        protected virtual void Traversing(in AsmCode src)
        {

        }

        protected virtual void Traversed(in AsmCodeBlock src)
        {

        }

        protected virtual void Traversed(in AsmCodeBlocks src)
        {

        }

        protected virtual void Traversed(in AsmCode src)
        {

        }

    }
}