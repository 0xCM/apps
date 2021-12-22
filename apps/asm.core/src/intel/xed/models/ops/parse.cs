//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct XedModels
    {
        public static Outcome parse(TextLine src, out XedFormImport dst)
        {
            const char Delimiter = Chars.Pipe;

            dst = default;
            var result = Tables.cells(src, Delimiter, XedFormImport.FieldCount, out var cells);
            if(result.Fail)
                return result;
            var j=0;

            result = DataParser.parse(skip(cells,j++), out dst.Index);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out IFormType ft);
            if(result.Fail)
                return result;
            else
                dst.Form = ft;

            result = DataParser.eparse(skip(cells,j++), out dst.Class);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Category);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.IsaKind);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Extension);
            if(result.Fail)
                return result;

            dst.Attributes = attributes(skip(cells,j++)).Delimit(fence:Fencing.Embraced);

            return result;
        }

        public static Outcome parse(in XedFormSource src, ushort seq, out XedFormImport dst)
        {
            var result = Outcome.Success;
            dst.Index = seq;
            result = DataParser.eparse(src.Class, out dst.Class);
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = DataParser.eparse(src.Form, out IFormType ft);
            dst.Form = ft;
            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = attributes(src.Attributes);
            return true;
        }
    }
}