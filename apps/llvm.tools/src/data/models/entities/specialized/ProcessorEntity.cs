//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class ProcessorEntity : DefFields
    {
        public const string LlvmName = "Processor";

        public ProcessorEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public string Name
            => Value(nameof(Name), () => text.remove(this[nameof(Name)], Chars.Quote));

        public string SchedModel
            => this[nameof(SchedModel)];

        public list<string> Features
            => Parse(nameof(Features), out list<string> _);

        public list<string> TuneFeatures
            => Parse(nameof(TuneFeatures), out list<string> _);

        public string ProcItin
            => this[nameof(ProcItin)];
    }
}