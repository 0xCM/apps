//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public AsmIdDefs DiscoverAsmIdDefs()
        {
            const string BeginAsmIdMarker = "PHI	= 0,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Info);
            if(src.Count != 1)
            {
                Wf.Error("Path not found");
                return llvm.AsmIdDefs.Empty;
            }
            return enumliterals<ushort>(src[0],BeginAsmIdMarker).Map(x => new AsmIdDef(x.Key, x.Value));
        }

        public RegIdDefs DiscoverRegIdDefs()
        {
            const string BeginRegsMarker = "NoRegister,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Registers);
            if(src.Count != 1)
            {
                Wf.Error("Path not found");
                return llvm.RegIdDefs.Empty;
            }
            return enumliterals<ushort>(src[0],BeginRegsMarker).Map(x => new RegIdDef(x.Key, x.Value));
        }

        static bool enumliteral<T>(string src, out LlvmListItem<T,string> dst)
            where T : unmanaged
        {
            if(definesliteral(src))
            {
                var i = text.index(src, Chars.Eq);
                var name = text.left(src,i).Trim();
                var idtext = text.remove(text.right(src,i),Chars.Comma).Trim();
                DataParser.numeric(idtext, out ushort id);
                dst = (generic<T>(id),name);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        static bool definesliteral(string src)
            => src.Contains(Chars.Eq) && src.Trim().EndsWith(Chars.Comma);

        static LlvmListItem<T,string>[] enumliterals<T>(FS.FilePath header, string marker)
            where T : unmanaged
        {
            var items = list<LlvmListItem<T,string>>();
            using var reader = header.Utf8LineReader();
            var parsing = false;
            while(reader.Next(out var line))
            {
                if(parsing)
                {
                    if(enumliteral<T>(line.Content, out var literal))
                        items.Add(literal);
                    else
                        break;
                }
                else
                {
                    if(line.Contains(marker))
                    {
                        parsing = true;
                        if(definesliteral(marker))
                        {
                            if(enumliteral<T>(marker, out var first))
                                items.Add(first);
                        }
                        else
                            items.Add((zero<T>(), text.remove(marker, Chars.Comma)));
                    }
                }
            }
            return items.ToArray();
        }

    }
}