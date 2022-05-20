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
        void EmitDeclarations(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = DeclPath();
            var flow = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(string.Format("{0};", skip(src,i).Sig()));
            EmittedFile(flow, count);
        }
    }
}