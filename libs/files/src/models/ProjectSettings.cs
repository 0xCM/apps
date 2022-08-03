//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ProjectSetting
    {
        public readonly @string Key;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        internal ProjectSetting(@string key, dynamic value)
        {
            Key = key;
            Value = value;
        }
    }

    public readonly record struct ProjectSetting<V> //: IKeyed<@string>
        where V : IEquatable<V>
    {
        public readonly @string Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public ProjectSetting(@string key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ProjectSetting(ProjectSetting<V> src)
            => new ProjectSetting($"{src.Key}", src.Value);
    }

    public struct ProjectSetting<K,V>
        where V : IEquatable<V>
    {
        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public ProjectSetting(K key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ProjectSetting<V>(ProjectSetting<K,V> src)
            => new ProjectSetting<V>($"{src.Key}", src.Value);

        [MethodImpl(Inline)]
        public static implicit operator ProjectSetting(ProjectSetting<K,V> src)
            => new ProjectSetting($"{src.Key}", src.Value);
    }

    public class ProjectSettings : Seq<ProjectSettings,ProjectSetting>    
    {
        public ProjectSettings()
        {

        }

        public ProjectSettings(ProjectSetting[] src)
            : base(src)
        {

        }
    }
}