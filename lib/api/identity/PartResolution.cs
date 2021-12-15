//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public readonly struct PartResolution
    {
        /// <summary>
        /// Retrieves the part identifier, if any, of the entry assembly
        /// </summary>
        public static PartId Executing
            => id(Assembly.GetEntryAssembly());

        public static PartId id(Assembly src)
        {
            if(src != null && Attribute.IsDefined(src, typeof(PartIdAttribute)))
                return ((PartIdAttribute)Attribute.GetCustomAttribute(src, typeof(PartIdAttribute))).Id;
            else
                return PartId.None;
        }

        public static bool resolve(Type type, out IPart part)
        {
            try
            {
                part = (IPart)Activator.CreateInstance(type);
                return true;
            }
            catch(Exception)
            {
                part = default;
                return false;
            }
        }

        public const string ResolutionProperty = "Resolved";
    }
}