//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    partial class IntelIntrinsicModels
    {
        public struct Return : ITextual
        {
            public const string ElementName = "return";

            public string varname;

            public DataType type;

            public string etype;

            public string memwidth;

            public string Format()
                => type.Format();

            public override string ToString()
                => Format();

            public static Return Empty
            {
                get
                {
                    var dst = new Return();
                    dst.varname = EmptyString;
                    dst.type = EmptyString;
                    dst.etype = EmptyString;
                    dst.memwidth = EmptyString;
                    return dst;
                }
            }
        }
    }
}