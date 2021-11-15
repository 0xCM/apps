//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using types;

    public readonly struct LlvmTypes
    {
        public static dag<ITerm> dag(string src)
        {
            var dag = new dag<ITerm>(@string.Empty, @string.Empty);
            if(src.Contains("->"))
            {
                var parts = src.SplitClean("->").Select(x => x.Trim());
                var count = parts.Length;
                var first = EmptyString;
                for(var i=0; i<count; i++)
                {
                    ref readonly var current = ref skip(parts,i);
                    if(i==0)
                        first = current;
                    else if(i==1)
                        dag = new dag<ITerm>((@string)first, (@string)current);
                    else
                        dag = new dag<ITerm>((@string)current, dag);
                }
            }
            else
            {
                dag = new dag<ITerm>((@string)src, @string.Empty);
            }
            return dag;
        }
    }
}