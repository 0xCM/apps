//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;

    using static core;
    using static IntrinsicsDoc;

    partial class IntelIntrinsicSvc
    {
        void EmitAlgorithms(ReadOnlySpan<IntrinsicDef> src)
        {
            var count = src.Length;
            var dst = AlgPath();
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(Formatter.FormatAlgorithm(skip(src,i)));
            EmittedFile(flow, count);
        }
    }
}