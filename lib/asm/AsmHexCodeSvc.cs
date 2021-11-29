//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [TypeService(typeof(AsmHexCode))]
    public struct AsmHexCodeSvc :
        IParser<AsmHexCode>,
        IFormatter<AsmHexCode>,
        ITransformer<ulong,AsmHexCode>,
        ISeqLoader<char,AsmHexCode>,
        ISeqLoader<byte,AsmHexCode>
    {
        public Outcome Parse(string src, out AsmHexCode dst)
        {
            var result = AsmHexCode.parse(src, out dst);
            if(result)
                return true;
            else
                return false;
        }

        public Outcome Map(in ulong src, out AsmHexCode dst)
        {
            dst = AsmHexCode.load(src);
            return true;
        }

        public string Format(AsmHexCode src)
            => src.Format();

        public Outcome Load(ReadOnlySpan<char> src, out AsmHexCode dst)
            => AsmHexCode.parse(src, out dst);

        public Outcome Load(ReadOnlySpan<byte> src, out AsmHexCode dst)
        {
            dst = AsmHexCode.load(src);
            return true;
        }
    }
}