// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// This file defines an internal static class used to throw exceptions in the
// the System.Reflection.MetadataLoadContext code.

using IKVM.Reflection.TypeLoading;

namespace IKVM.Reflection
{
    internal static class ThrowHelper
    {
        internal static AmbiguousMatchException GetAmbiguousMatchException(RoDefinitionType roDefinitionType)
        {
            return new AmbiguousMatchException(string.Format(SR.Arg_AmbiguousMatchException_RoDefinitionType, roDefinitionType.FullName));
        }

        internal static AmbiguousMatchException GetAmbiguousMatchException(MemberInfo memberInfo)
        {
            Type? declaringType = memberInfo.DeclaringType;
            return new AmbiguousMatchException(string.Format(SR.Arg_AmbiguousMatchException_MemberInfo, declaringType, memberInfo));
        }
    }
}
