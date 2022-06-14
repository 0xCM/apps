//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class Ancestry : Lineage<Ancestry,Label>
    {
        //public readonly Index<Label> Ancestors;

        //public readonly Label Name;

        //public readonly bool IsEmpty;

        // public bool Equals(Ancestry src)
        // {
        //     if(src is null)
        //         return false;

        //     if(object.ReferenceEquals(this,src))
        //         return true;

        //     if(!Name.Equals(src.Name))
        //         return false;

        //     var count = Ancestors.Length;
        //     if(count != src.Ancestors.Length)
        //         return false;

        //     for(var i=0; i<count; i++)
        //     {
        //         if(!Ancestors[i].Equals(src.Ancestors[i]))
        //             return false;
        //     }
        //     return true;
        // }

        public Ancestry(Label name, Label[] ancestors)
            : base(name,ancestors)
        {
            // Name = name;
            // Ancestors = ancestors;
            // IsEmpty = false;
        }

        public Ancestry(Label name)
        {
            // Name = name;
            // Ancestors = Index<Label>.Empty;
            // IsEmpty = false;
        }

        public Ancestry()
        {
            //Name = EmptyString;
            //IsEmpty = true;
        }


        // public bool IsNonEmpty
        // {
        //     [MethodImpl(Inline)]
        //     get => !IsEmpty;
        // }

        // public bool HasAncestor
        // {
        //     [MethodImpl(Inline)]
        //     get => Ancestors.IsNonEmpty;
        // }

        // public string Format()
        //     => Format(LeftToRight);

        // public string Format(string sep)
        // {
        //     var dst = text.buffer();
        //     if(IsNonEmpty)
        //     {
        //         dst.Append(Name.Format());
        //         var count = Ancestors.Count;
        //         for(var i=0; i<count; i++)
        //         {
        //             dst.Append(sep);
        //             dst.Append(Ancestors[i].Format());
        //         }
        //     }
        //     return dst.Emit();

        // }

        //const string LeftToRight = " -> ";

        //public static Ancestry Empty => new Ancestry();
    }
}