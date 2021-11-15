//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmFragmentWriter
    {
        void WriteDirective(string src);

        void WriteLabelAddress(string src);

        void WritePrefix(string src);

        void WriteLabel(string src);

        void WriteMnemonic(string src);

        void WriteKeyword(string src);

        void WriteOperator(string src);

        void WriteRegister(string src);

        void WriteDecorator(string src);

        void WriteData(string src);

        void WriteFunctionAddress(string src);

        void WriteSelectorValue(string src);

        void WriteFunction(string src);

        void WriteNumber(string src);

        void WriteText(string src);

        void Write(string src, AsmFragmentKind kind);
    }
}