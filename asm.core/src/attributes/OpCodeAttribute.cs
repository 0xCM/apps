//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class OpCodeAttribute : Attribute
    {
        public OpCodeAttribute(string code)
        {
            OpCode =  code;
        }

        public string OpCode {get;}
    }

}