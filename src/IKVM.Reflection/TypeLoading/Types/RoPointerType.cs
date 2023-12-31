// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;

namespace IKVM.Reflection.TypeLoading
{
    /// <summary>
    /// All RoTypes that return true for IsPointer.
    /// </summary>
    internal sealed class RoPointerType : RoHasElementType
    {
        internal RoPointerType(RoType elementType)
            : base((RoType)elementType.UnderlyingSystemType)
        {
            Debug.Assert(elementType != null);
        }

        protected sealed override bool IsArrayImpl() => false;
        public sealed override bool IsSZArray => false;
        public sealed override bool IsVariableBoundArray => false;
        protected sealed override bool IsByRefImpl() => false;
        protected sealed override bool IsPointerImpl() => true;

        public sealed override int GetArrayRank() => throw new ArgumentException(SR.Argument_HasToBeArrayClass);

        protected sealed override TypeAttributes ComputeAttributeFlags() => TypeAttributes.Public;

        protected sealed override string Suffix => "*";

        internal sealed override RoType? ComputeBaseTypeWithoutDesktopQuirk() => null;
        internal sealed override IEnumerable<RoType> ComputeDirectlyImplementedInterfaces() => Array.Empty<RoType>();

        internal sealed override IEnumerable<ConstructorInfo> GetConstructorsCore(NameFilter? filter) => Array.Empty<ConstructorInfo>();
        internal sealed override IEnumerable<MethodInfo> GetMethodsCore(NameFilter? filter, Type reflectedType) => Array.Empty<MethodInfo>();
    }
}
