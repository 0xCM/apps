//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static XedModels;
    using static XedRules;

    partial class XedMachine
    {
        void LoadLookups()
        {
            var rules = XedRules;
            var patterns = rules.CalcInstPatterns();
            var groups = rules.CalcInstGroups(patterns);
            var members = groups.SelectMany(x => x.Members);
            _GroupMemberLookup = members.Select(x => (x.PatternId,x)).ToDictionary();
            _ClassPatternLookup = patterns.ClassPatterns();
            _ClassFormLookup = patterns.ClassForms();
            _ClassGroupLookup = groups.ClassGroups();
        }

        ConstLookup<ushort,InstGroupMember> _GroupMemberLookup;

        SortedLookup<InstClass,Index<InstGroupMember>> _ClassGroupLookup;

        SortedLookup<InstClass,Index<InstPattern>> _ClassPatternLookup;

        SortedLookup<InstClass,Index<InstForm>> _ClassFormLookup;

        /// <summary>
        /// Specifies <see cref='InstGroupMember'/> associated with the current <see cref='LoadPattern'/>
        /// </summary>
        public InstGroupMember PatternGroup
            => _GroupMemberLookup.Find(PatternId, out var dst) ? dst : InstGroupMember.Empty;

        /// <summary>
        /// Specifies <see cref='InstForm'/> associated with the current <see cref='InstClass'/>
        /// </summary>
        public Index<InstForm> ClassForms
            => _ClassFormLookup.Find(InstClass, out var dst) ? dst : sys.empty<InstForm>();

        /// <summary>
        /// Specifies <see cref='InstGroupMember'> associated with the current <see cref='InstClass'/>
        /// </summary>
        public Index<InstGroupMember> ClassGroups
            => _ClassGroupLookup.Find(InstClass, out var dst) ? dst : sys.empty<InstGroupMember>();

        /// <summary>
        /// Specifies <see cref='LoadPattern'/> associated with the current <see cref='InstClass'/>
        /// </summary>
        public Index<InstPattern> ClassPatterns
            => _ClassPatternLookup.Find(InstClass, out var x) ? x : sys.empty<InstPattern>();
    }

    partial class XTend
    {
        public static SortedLookup<InstClass,Index<InstForm>> ClassForms(this Index<InstPattern> src)
            => src.Storage.Where(x => x.InstForm.IsNonEmpty)
                    .GroupBy(x => x.InstClass.Classifier)
                    .Select(x => (x.Key.Classifier, x.Select(y => y.InstForm).ToIndex()))
                    .ToSortedLookup();

        public static SortedLookup<InstClass,Index<InstPattern>> ClassPatterns(this Index<InstPattern> src)
            => src.Storage
                    .GroupBy(x => x.InstClass)
                    .Select(x => (x.Key, x.ToIndex()))
                    .ToSortedLookup();

        public static SortedLookup<InstClass,Index<InstGroupMember>> ClassGroups(this Index<InstGroup> src)
            => src.SelectMany(x => x.Members).GroupBy(x => x.Class.Classifier).Select(x => (x.Key.Classifier,x.Index())).ToDictionary();
    }
}