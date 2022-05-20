//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class IntrinsicsDoc
    {
        public struct Instruction
        {
            public const string ElementName = "instruction";

            public string name;

            public string form;

            public IFormType xed;

            public Instruction(string name, string form, IFormType xed)
            {
                this.name = name;
                this.form = form;
                this.xed  = xed;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(name) && text.empty(form) && xed == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0} {1}", name, form);

            public override string ToString()
                => Format();

            public static Instruction Empty =>new Instruction(EmptyString,EmptyString, 0);
        }
    }
}