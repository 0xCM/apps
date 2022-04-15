//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static XedModels;
    using static XedRules;

    partial class XTend
    {
        public static SortedLookup<InstForm,Index<InstPattern>> FormPatterns(this Index<InstPattern> src)
            => src.Storage.Where(x => x.InstForm.IsNonEmpty)
                    .GroupBy(x => (x.InstForm))
                    .Select(x => (x.Key, x.ToIndex()))
                    .ToSortedLookup();

        public static SortedLookup<InstClass,Index<InstForm>> ClassForms(this Index<InstPattern> src)
            => src.Storage.Where(x => x.InstForm.IsNonEmpty)
                    .GroupBy(x => x.InstClass)
                    .Select(x => (x.Key, x.Select(y => y.InstForm).ToIndex()))
                    .ToSortedLookup();

        public static SortedLookup<InstClass,Index<InstPattern>> ClassPatterns(this Index<InstPattern> src)
            => src.Storage
                    .GroupBy(x => x.InstClass)
                    .Select(x => (x.Key, x.ToIndex()))
                    .ToSortedLookup();

    }
}