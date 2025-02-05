using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace InvokeAI.SDK.Helpers;


[AttributeUsage(AttributeTargets.Property)]
public class IgnoreJsonPropertyAttribute : Attribute {
}


public class IgnorePropertiesResolver : DefaultContractResolver {
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
        var property = base.CreateProperty(member, memberSerialization);
        var ignoreAttr = member.GetCustomAttributes(true)
                            .OfType<IgnoreJsonPropertyAttribute>()
                            .FirstOrDefault();

        if (ignoreAttr != null) {
            property.Ignored = true;
        }

        return property;
    }
}