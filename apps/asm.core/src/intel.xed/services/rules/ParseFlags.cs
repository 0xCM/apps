//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;
    using static Root;

    partial class XedRules
    {
        Index<FlagAction> ParseFlags(string src)
        {
            var i = text.index(src,Chars.LBracket);
            var j = text.index(src,Chars.RBracket);
            var buffer = sys.empty<FlagAction>();
            if(i >=0 && j>1)
            {
                var specs = text.split(text.despace(text.inside(src,i,j)),Chars.Space);
                var count = specs.Length;
                buffer = alloc<FlagAction>(count);
                for(var k=0; k<count; k++)
                {
                    ref readonly var spec = ref skip(specs,k);
                    var m = text.index(spec,Chars.Dash);
                    if(m>0)
                    {
                        var name = text.left(spec, m);
                        var action = text.right(spec,m);
                        if(Flags.ExprKind(name, out var flag) && FlagActionKinds.ExprKind(action, out var ak))
                            seek(buffer,k) = new FlagAction(flag,ak);
                    }
                }
            }

            return buffer;
        }
    }
}