//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class OperandSpec
    {
        public string Name {get;}

        public string Type {get;}

        public Index<string> Modifiers {get;}

        public OperandSpec(string name, string type, string[] modifiers)
        {
            Name = name;
            Type = type;
            Modifiers = modifiers;
        }
    }
}