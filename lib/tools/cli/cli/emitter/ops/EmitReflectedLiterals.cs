//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class CliEmitter
    {
        FS.FolderPath FieldLiteralTarget
            => Wf.Db().DbTableRoot() + FS.folder(MemberFieldName.TableId);

        ReadOnlySpan<Paired<FieldRef,string>> EmitFieldLiterals(ApiPartTypes src)
        {
            var fields = ClrFields.literals(src.Types);
            if(fields.Length != 0)
                return Emit(fields, FieldLiteralTarget + FS.file(src.Part.Format(), FS.Csv));
            else
                return Index<Paired<FieldRef,string>>.Empty;
        }

        public void EmitReflectedLiterals()
        {
            FieldLiteralTarget.Clear();
            var parts = span(Wf.ApiCatalog.Parts.Map(part => ApiPartTypes.from(part)));
            foreach(var part in parts)
            {
                try
                {
                    EmitFieldLiterals(part);
                }
                catch(Exception e)
                {
                    Wf.Error(e);
                }
            }
        }

        ReadOnlySpan<Paired<FieldRef,string>> Emit(FieldRef[] src, FS.FilePath dst)
        {
            const string Sep = "| ";

            static string formatLine(in FieldRef src)
            {
                const string Sep = "| ";

                var content = ClrLiterals.format(src).PadRight(48);
                var address = src.Address.Format().PadRight(16);
                var width = src.Width.Content.ToString().PadRight(16);
                var type = src.Field.DeclaringType.Name.PadRight(36);
                var field = src.Field.Name.PadRight(36);
                var line = string.Concat(address, Sep, width, Sep,type, Sep, field, Sep, content, Sep);
                return line;
            }

            static string FormatHeader()
                => string.Concat(
                    "FieldAddress".PadRight(16), Sep,
                    "FieldWidth".PadRight(16), Sep,
                    "DeclaringType".PadRight(36), Sep,
                    "FieldName".PadRight(36), Sep,
                    "Value".PadRight(48), Sep
                    );


            var flow = Wf.EmittingFile(dst);
            var input = span(src);
            var count = input.Length;
            var buffer = sys.alloc<Paired<FieldRef,string>>(count);
            ref var emissions = ref first(buffer);

            using var writer = dst.Writer();
            writer.WriteLine(FormatHeader());

            for(var i=0u; i<count; i++)
            {
                try
                {
                    ref readonly var field = ref skip(input,i);
                    var formatted = formatLine(field);
                    seek(emissions, i) = (field,formatted);

                    writer.WriteLine(formatted);
                }
                catch(Exception e)
                {
                    Wf.Warn(e.Message);
                }
            }

            Wf.EmittedFile(flow, count);
            return buffer;
        }
    }
}