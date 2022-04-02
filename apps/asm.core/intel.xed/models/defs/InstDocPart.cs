//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedFields;
    using static XedModels;

    partial class XedDocs
    {
        public class InstDocPart
        {
            readonly InstPattern Inst;

            public readonly string OcMap;

            public readonly FieldSet Fields;

            public InstDocPart(InstPattern src)
            {
                Inst = src;
                OcMap = string.Format("{0}{1}", XedModels.indicator(src.OpCode.Class), text.bracket(src.OpCode.Digits.PadLeft(4,'0')));
                var fields = XedFields.set();
                for(var j=0; j<src.Body.FieldCount; j++)
                    fields = fields.Include(src.Body[j].FieldKind);
                Fields = fields;
            }

            public ref readonly Index<OpName> OpNames
            {
                [MethodImpl(Inline)]
                get => ref Inst.OpNames;
            }

            public ref readonly PatternOps Ops
            {
                [MethodImpl(Inline)]
                get => ref Inst.Ops;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Inst.InstForm;
            }

            public string Classifier
            {
                [MethodImpl(Inline)]
                get => Inst.Classifier;
            }

            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Inst.OpCode;
            }

            public ref readonly uint PatternId
            {
                [MethodImpl(Inline)]
                get => ref Inst.PatternId;
            }

            public ref readonly InstPatternBody Layout
            {
                [MethodImpl(Inline)]
                get => ref Inst.Layout;
            }

            public ref readonly InstPatternBody Constraints
            {
                [MethodImpl(Inline)]
                get => ref Inst.Constraints;
            }
        }
    }
}