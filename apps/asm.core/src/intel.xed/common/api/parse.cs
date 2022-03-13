//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
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
                return (false,FormParseFailed.Format(nameof(dst.Index), src));

            result = DataParser.eparse(skip(cells,j++), out IFormType ft);
            if(result.Fail)
                return (false,FormParseFailed.Format(nameof(dst.Form), src));

            dst.Form = ft;

            result = DataParser.eparse(skip(cells,j++), out dst.Class);
            if(result.Fail)
                return (false,FormParseFailed.Format(nameof(dst.Class), src));

            result = DataParser.eparse(skip(cells,j++), out dst.Category);
            if(result.Fail)
                return (false,FormParseFailed.Format(nameof(dst.Category), src));

            result = DataParser.eparse(skip(cells,j++), out dst.IsaKind);
            if(result.Fail)
                return (false,FormParseFailed.Format(nameof(dst.IsaKind), src));

            result = DataParser.eparse(skip(cells,j++), out dst.Extension);
            if(result.Fail)
                return (false,FormParseFailed.Format(nameof(dst.Extension), src));

            dst.Attributes = attributes(skip(cells,j++));

            return result;
        }

        static MsgPattern<string,TextLine> FormParseFailed => "The attempt to parse the {0} field from '{1}' failed";

        public static Outcome parse(in XedFormSource src, ushort seq, out XedFormImport dst)
        {
            var result = Outcome.Success;
            result = DataParser.eparse(src.Class, out dst.Class);
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = DataParser.eparse(src.Form, out IFormType ft);
            dst.Index = (ushort)ft;
            dst.Form = ft;
            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = attributes(src.Attributes);
            return true;
        }
    }
}