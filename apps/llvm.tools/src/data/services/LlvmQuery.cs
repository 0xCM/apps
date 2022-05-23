//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmQuery : AppService<LlvmQuery>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        AppServices AppSvc => Service(Wf.AppServices);

        public uint EmitFile<T>(string query, ReadOnlySpan<T> src)
            => EmitFile(query, string.Empty, src);

        // public Index<DefRelations> QueryDefRelations(Func<DefRelations,bool> predicate)
        // {
        //     var relations = Provider.DefRelations();
        //     var count = relations.Count;
        //     var dst = hashset<DefRelations>();
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var relation = ref relations[i];
        //         ref readonly var child = ref relation.Name;
        //         var ancestors = relation.AncestorNames;
        //         if(ancestors.Length != 0 && predicate(relation))
        //             dst.Add(relation);
        //     }

        //     return dst.Array().Sort();
        // }

        public uint EmitFile<T>(string query, string args, ReadOnlySpan<T> src)
        {
            var count = (uint)src.Length;
            var file = FS.file(text.replace(query, Chars.FSlash, Chars.Dot) + tag(args), FS.Txt);
            var dst = LlvmPaths.QueryResult(file);
            var emitting = EmittingFile(dst);
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i));
            EmittedFile(emitting,count);
            return count;
        }

        static string tag(string args)
            => text.empty(args) ? string.Empty : "-" + args;

        public void EmitTable<T>(string name, ReadOnlySpan<T> src)
            where T : struct
                => AppSvc.TableEmit(src, LlvmPaths.QueryTable<T>(FS.file(name, FS.Csv)));
    }
}