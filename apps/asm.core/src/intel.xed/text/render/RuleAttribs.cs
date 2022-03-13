//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using K = XedRules.RuleOpClass;

    partial class XedRender
    {
        public static string format(RuleOpAttrib src)
        {
            var dst = EmptyString;
            switch(src.Class)
            {
                case K.Action:
                    dst = format(src.AsAction());
                break;
                case K.OpWidth:
                    dst = format(src.AsOpWidth());
                break;

                case K.PtrWidth:
                    dst = format(src.AsPtrWidth());
                break;

                case K.ElementType:
                    dst = format(src.AsElementType());
                break;

                case K.EncGroup:
                    dst = format(src.AsGroupName());
                break;

                // case K.Common:
                //     dst = format(src.AsCommon());
                // break;

                case K.Modifier:
                    dst = format(src.AsModifier());
                break;

                case K.Nonterminal:
                    dst = format(src.AsNonTerm());
                break;

                case K.Visibility:
                    dst = format(src.AsVisiblity());
                break;

                case K.RegLiteral:
                    dst = format(src.AsRegLiteral());
                break;

                case K.Scale:
                    dst = src.AsScale().Format();
                break;

                case K.Macro:
                    dst = src.AsMacro().ToString();
                break;
            }
            return dst;
        }
    }
}