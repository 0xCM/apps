//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using static XedTool;

    public class XedTypeProvider : AppService<XedTypeProvider>
    {
        TypeParser TypeParser => Service(Wf.TypeParser);

        public Outcome Concretize(TypeSpec src, out Type dst)
        {
            var result = Outcome.Success;
            dst = typeof(void);

            if(TypeParser.IsParametric(src))
            {
                var parameters = TypeParser.Parameters(src);
            }

            return result;
        }

    }
}