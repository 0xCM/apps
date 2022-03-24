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
        public static Outcome parse(string src, out XedFormImport dst)
        {
            const char Delimiter = Chars.Pipe;
            dst = XedFormImport.Empty;
            var result = Outcome.Success;
            var reader = text.trim(text.split(text.trim(text.despace(src)), Delimiter)).Reader();
            result = XedParsers.parse(reader.Next(), out dst.Index);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Index), reader.Prior()));

            result = XedParsers.parse(reader.Next(), out dst.InstForm);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.InstForm), reader.Prior()));

            result = XedParsers.parse(reader.Next(), out dst.InstClass);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.InstClass), reader.Prior()));

            dst.ClassId = reader.Next();

            result = DataParser.eparse(reader.Next(), out dst.Category);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Category), reader.Prior()));

            result = DataParser.eparse(reader.Next(), out dst.IsaKind);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.IsaKind), reader.Prior()));

            result = DataParser.eparse(reader.Next(), out dst.Extension);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Extension), reader.Prior()));

            dst.Attributes = XedPatterns.attributes(reader.Next());

            return result;
        }


        // public static Outcome parse(TextLine src, out XedFormImport dst)
        // {
        //     const char Delimiter = Chars.Pipe;

        //     dst = default;
        //     var result = Tables.cells(src, Delimiter, XedFormImport.FieldCount, out var cells);
        //     if(result.Fail)
        //         return result;
        //     var j=0;

        //     result = DataParser.parse(skip(cells,j++), out dst.Index);
        //     if(result.Fail)
        //         return (false,FormParseFailed.Format(nameof(dst.Index), src));

        //     result = XedParsers.parse(skip(cells,j++), out dst.InstForm);
        //     if(result.Fail)
        //         return (false, FormParseFailed.Format(nameof(dst.InstForm), src));

        //     result = XedParsers.parse(skip(cells,j++), out dst.InstClass);
        //     if(result.Fail)
        //         return (false,FormParseFailed.Format(nameof(dst.InstClass), src));

        //     result = DataParser.eparse(skip(cells,j++), out dst.Category);
        //     if(result.Fail)
        //         return (false,FormParseFailed.Format(nameof(dst.Category), src));

        //     result = DataParser.eparse(skip(cells,j++), out dst.IsaKind);
        //     if(result.Fail)
        //         return (false,FormParseFailed.Format(nameof(dst.IsaKind), src));

        //     result = DataParser.eparse(skip(cells,j++), out dst.Extension);
        //     if(result.Fail)
        //         return (false,FormParseFailed.Format(nameof(dst.Extension), src));

        //     dst.Attributes = XedPatterns.attributes(skip(cells,j++));

        //     return result;
        // }

        //static MsgPattern<string,TextLine> FormParseFailed => "The attempt to parse the {0} field from '{1}' failed";

        public static Outcome parse(in XedFormSource src, ushort seq, out XedFormImport dst)
        {
            var result = Outcome.Success;
            result = XedParsers.parse(src.Class, out dst.InstClass);
            dst.ClassId = src.Class;
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = XedParsers.parse(src.Form, out dst.InstForm);
            dst.Index = (ushort)dst.InstForm.Type;
            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = XedPatterns.attributes(src.Attributes);
            return true;
        }
    }
}