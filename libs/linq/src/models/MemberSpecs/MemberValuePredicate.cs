//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public static class MemberValuePredicate
    {
        public static IMemberValuePredicate Define(IOperator Operator, MemberInfo Member, object Value)
        {

            var OP = Operator.GetType();
            var typedef = typeof(MemberValuePredicate<>).GetGenericTypeDefinition();
            var type = typedef.MakeGenericType(OP);
            var predicate = Activator.CreateInstance(type, Operator, Member, Value) as IMemberValuePredicate;
            return predicate;
        }
    }

    /// <summary>
    /// Represents an operation that evaluates the value of a member and returns a boolean result
    /// </summary>
    /// <typeparam name="OP">The type of operator that when applied carries out the evaluation represented by the predicate</typeparam>
    public sealed class MemberValuePredicate<OP> : MemberPredicate<OP>, IMemberValuePredicate
        where OP : BinaryOperator<OP>
    {
        public MemberValuePredicate(OP Operator, MemberInfo Member, object Value)
            : base(Operator, Member)
        {
            this.Value = Value;
        }
        public object Value { get; }


        protected override IReadOnlyList<object> Operands
            => new object[] { Member, Value };

        object IMemberValuePredicate.Value => Value;

        public override string ToString()
            => $"{Member.Name} {Operator} {Value}";
    }
}