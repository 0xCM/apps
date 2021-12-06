//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public partial class IntelIntrinsicModels
    {
        public struct Parameter : ITextual
        {
            public const string ElementName = "parameter";

            public string varname;

            public DataType type;

            public string etype;

            public string memwidth;

            public string Format()
                => string.Format("{0} {1}", type, varname);

            public override string ToString()
                => Format();
        }
    }
}