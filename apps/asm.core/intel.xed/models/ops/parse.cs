//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public static Outcome parse(string src, out FormImport dst)
        {
            const char Delimiter = Chars.Pipe;
            dst = FormImport.Empty;
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

        public static Outcome parse(in FormSource src, ushort seq, out FormImport dst)
        {
            var result = Outcome.Success;
            result = XedParsers.parse(src.Class, out dst.InstClass);
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = XedParsers.parse(src.Form, out dst.InstForm);
            dst.Index = (ushort)dst.InstForm.Kind;
            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = XedPatterns.attributes(src.Attributes);
            return true;
        }
    }
}