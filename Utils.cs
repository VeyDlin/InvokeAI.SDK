﻿using System.ComponentModel;
using System.Reflection;

namespace InvokeAI.SDK;


public static class Utils {
    public static string GetDescription<T>(T enumerationValue) where T : struct {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum) {
            throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
        }

        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString()!);
        if (memberInfo != null && memberInfo.Length > 0) {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0) {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }

        return enumerationValue.ToString()!;
    }
}