//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class FunctionSpec
    {
        public string Name {get;}

        public Index<string> Operands {get;}

        public string ReturnType {get;}

        public string Body {get;}

        public FunctionSpec(string name, string[] operands, string ret, string body)
        {
            Name = name;
            Operands = operands;
            ReturnType = ret;
            Body = body;
        }
    }
}