//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdUri
    {
        [MethodImpl(Inline)]
        public static CmdUri define(PartName part, asci32 host, asci32 command)
            => new CmdUri($"cmd://{part}/{host}?name={command}");

        readonly AsciBlock128 Data;

        [MethodImpl(Inline)]
        internal CmdUri(string src)
        {
            Data = src;
        }

        public string Format()
            => Data.Format();


        public override string ToString()
            => Format();
    }
}