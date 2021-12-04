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
    using Types;

    public readonly struct LlvmTypes
    {
        public static dag<L,R> dag<L,R>(L left, R right)
            where L : ITerm
            where R : ITerm
                => new dag<L,R>(left,right);

        public static Outcome parse(string src, out dag<ITerm> dag)
        {
            dag = new dag<ITerm>(@string.Empty, @string.Empty);
            if(src.Contains("->"))
            {
                var parts = src.SplitClean("->").Select(x => x.Trim());
                var count = parts.Length;
                for(var i=1; i<count; i++)
                {
                    if(i==1)
                        dag = new dag<ITerm>((@string)skip(parts,i-1), (@string)skip(parts,i));
                    else
                        dag = new dag<ITerm>(dag, (@string)skip(parts,i));
                }
            }
            else
            {
                dag = new dag<ITerm>((@string)src, @string.Empty);
            }
            return true;
        }
    }
}