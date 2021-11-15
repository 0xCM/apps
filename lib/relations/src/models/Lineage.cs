//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class Lineage2 : IEquatable<Lineage2>
    {
        public static Lineage2 parse(LabelAllocator allocator, string src, string sep = "->")
        {
            var input = text.trim(src);
            if(empty(input))
                return Lineage2.Empty;

            else if(input.Contains(sep))
            {
                var parts = @readonly(input.Split(sep).Select(x => x.Trim()));
                var count = parts.Length;
                if(count == 0)
                    return Lineage2.Empty;

                if(count == 1)
                {
                    allocator.Allocate(first(parts), out var name);
                    return new Lineage2(name);
                }
                else
                {
                    var names = alloc<Label>(count-1);
                    for(var i=1; i<count; i++)
                        allocator.Allocate(skip(parts,i), out seek(names,i-1));
                    return new Lineage2(first(parts), names);
                }
            }
            else
                return new Lineage2(input);
        }

        public bool Equals(Lineage2 src)
        {
            if(src is null)
                return false;

            if(object.ReferenceEquals(this,src))
                return true;

            if(!Name.Equals(src.Name))
                return false;

            var count = Ancestors.Length;
            if(count != src.Ancestors.Length)
                return false;

            for(var i=0; i<count; i++)
            {
                if(!Ancestors[i].Equals(src.Ancestors[i]))
                    return false;
            }
            return true;
        }

        Lineage2(Label name, Label[] ancestors)
        {
            Name = name;
            Ancestors = ancestors;
            IsEmpty = false;
        }

        Lineage2(Label name)
        {
            Name = name;
            Ancestors = Index<Label>.Empty;
            IsEmpty = false;
        }

        Lineage2()
        {
            Name = EmptyString;
            IsEmpty = true;
        }


        public Index<Label> Ancestors {get;}

        public Label Name {get;}

        public bool IsEmpty {get;}

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasAncestor
        {
            [MethodImpl(Inline)]
            get => Ancestors.IsNonEmpty;
        }

        public string Format()
            => Format(LeftToRight);

        public string Format(string sep)
        {
            var dst = text.buffer();
            if(IsNonEmpty)
            {
                dst.Append(Name.Format());
                var count = Ancestors.Count;
                for(var i=0; i<count; i++)
                {
                    dst.Append(sep);
                    dst.Append(Ancestors[i].Format());
                }
            }
            return dst.Emit();

        }

        const string LeftToRight = " -> ";

       public static Lineage2 Empty => new Lineage2();
    }

    public class Lineage
    {
        [MethodImpl(Inline)]
        public static Lineage root(string name)
            => new Lineage(name);

        public static Lineage parse(string src, string sep = "->")
        {
            var input = text.trim(src);
            if(empty(input))
                return Lineage.Empty;
            else if(input.Contains(sep))
            {
                var parts = @readonly(input.Split(sep).Select(x => x.Trim()));
                var count = parts.Length;
                if(count == 0)
                    return Lineage.Empty;

                if(count == 1)
                    return new Lineage(first(parts));
                else
                    return new Lineage(first(parts), slice(parts,1).ToArray());
            }
            else
                return new Lineage(input);
        }

        public static Lineage path(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            if(count == 0)
                return Lineage.Empty;
            else if(count == 1)
                return new Lineage(first(src));
            else
                return new Lineage(first(src), slice(src,1).ToArray());
        }

        Lineage(string name, string[] ancestors)
        {
            Name = name;
            Ancestors = ancestors;
            IsEmpty = false;
        }

        Lineage(string name)
        {
            Name = name;
            Ancestors = Index<string>.Empty;
            IsEmpty = false;
        }

        Lineage()
        {
            Name = EmptyString;
            IsEmpty = true;
        }

        public Index<string> Ancestors {get;}

        public string Name {get;}

        public bool IsEmpty {get;}

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasAncestor
        {
            [MethodImpl(Inline)]
            get => Ancestors.IsNonEmpty;
        }

        public string Format()
            => Format(LeftToRight);

        public string Format(string sep)
        {
            var dst = text.buffer();
            if(IsNonEmpty && nonempty(Name))
            {
                dst.Append(Name);
                var count = Ancestors.Count;
                for(var i=0; i<count; i++)
                {
                    dst.Append(sep);
                    dst.Append(Ancestors[i]);
                }
            }
            return dst.Emit();

        }

        const string LeftToRight = " -> ";

        public override string ToString()
            => Format();

        public static Lineage Empty => new Lineage();
    }
}