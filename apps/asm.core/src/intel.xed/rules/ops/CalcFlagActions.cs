//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        Index<FlagAction> CalcFlagActions(string src)
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