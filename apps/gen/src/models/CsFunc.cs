//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CsFunc
    {
        public static CsFunc define(Identifier ret, Identifier name, CsOperand[] ops, params string[] body)
            => new CsFunc(ret, name, true, ops, body);

        public Identifier ReturnType {get;}

        public Identifier Name {get;}

        public Index<CsOperand> Ops {get;}

        public Index<string> Body {get;}

        public bool IsStatic {get;} = true;

        public CsFunc(Identifier ret, Identifier name, bool @static, CsOperand[] ops, Index<string> body)
        {
            Name = name;
            ReturnType = ret;
            Body = body;
            Ops = ops;
            IsStatic = @static;
        }


        string SigPattern()
        {
            if(IsStatic)
                return "public static {0} {1}({2})";
            else
                return "public {0} {1}({2})";
        }

        public void Render(uint margin, ITextBuffer dst)
        {
            dst.IndentLineFormat(margin, SigPattern(), ReturnType, Name, Ops);
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            iter(Body, b => dst.IndentLine(margin,b));
            margin -= 4;
            dst.IndentLine(margin, Chars.RBrace);
        }
    }
}