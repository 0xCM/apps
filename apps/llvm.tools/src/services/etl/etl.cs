//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using records;

    using static core;

    using SQ = SymbolicQuery;
    using K = llvm.LlvmConfigKind;

    public readonly struct etl
    {
        public static ReadOnlySpan<RecordFields> partition(ReadOnlySpan<RecordField> src)
        {
            var count = src.Length;
            var dst = list<RecordFields>();
            var subset = list<RecordField>();
            var current = Identifier.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var f = ref skip(src,i);
                ref readonly var id = ref f.RecordName;
                if(id != current)
                {
                    if(subset.Count != 0)
                    {
                        dst.Add(new RecordFields(current, subset.ToArray()));
                        subset.Clear();
                        current = id;
                    }
                }
                subset.Add(f);
            }

            if(subset.Count != 0)
                dst.Add(new RecordFields(current, subset.ToArray()));
            return dst.ViewDeposited();
        }

        public static bool lineage(string content, out Lineage dst)
        {
            var m = SQ.index(content, Chars.FSlash, Chars.FSlash);
            if(m >= 0)
            {
                var chain = text.trim(text.right(content, m + 1)).Split(Chars.Space);
                if(chain.Length > 0)
                {
                    dst = Lineage.path(chain);
                    return true;
                }
            }
            dst = Lineage.Empty;
            return false;
        }

        public static void store(Sym<LlvmConfigKind> sym, TextLine src, LlvmConfig dst)
        {
            var content = text.trim(src.Content);
            if(empty(content))
                return;

            var kind = sym.Kind;
            // Write(sym.Name, sym.Description, FlairKind.StatusData);
            // Write(RP.PageBreak80, FlairKind.StatusData);
            switch(kind)
            {
                case K.Version:
                {
                    dst.Set(kind, content);
                    //Write(content);
                }
                break;
                case K.IncludeDir:
                {
                    var data = FS.dir(content);
                    dst.Set(kind, data);
                    //Write(data);
                }
                break;
                case K.LibDir:
                {
                    var data = FS.dir(content);
                    dst.Set(kind,data);
                    //Write(data);
                }
                break;
                case K.TargetsBuilt:
                {
                    var data = content.Split(Chars.Space);
                    dst.Set(kind, data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.SrcRoot:
                {
                    var dir = FS.dir(content);
                    dst.Set(kind, dir);
                    //Write(dir);
                }
                break;
                case K.ObjRoot:
                {
                    var data = FS.dir(content);
                    dst.Set(kind, data);
                    //Write(data);
                }
                break;
                case K.BinDir:
                {
                    var data = FS.dir(content);
                    dst.Set(kind, data);
                    //Write(data);
                }
                break;
                case K.HostTarget:
                {
                    dst.Set(kind, content);
                    //Write(content);
                }
                break;
                case K.CFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind, data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.CxxFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind, data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.SystemLibs:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.file);
                    dst.Set(kind,data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.LibNames:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.file);
                    dst.Set(kind, data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.CppFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind,data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.LinkerFlags:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind, data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.LinkStatic:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind, data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.Components:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty);
                    dst.Set(kind,data);
                    //iter(data, c => Write(c));
                }
                break;
                case K.Libs:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.path);
                    dst.Set(kind, data);
                    //iter(data,p => Write(p.ToUri()));
                }
                break;
                case K.LibFiles:
                {
                    var data = content.Split(Chars.Space).Select(x => x.Trim()).Where(nonempty).Select(FS.path);
                    dst.Set(kind, data);
                    //iter(data,p =>  Write(p.ToUri()));
                }
                break;
            }
        }
    }
}