// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace IKVM.Reflection.TypeLoading
{
    //
    // This interface is implemented by the MethodDecoder structs that are embedded in RoDefinitionMethod and RoDefinitionConstructor.
    // The MethodDecoder struct encapsulates the underlying metadata provider for both methods and constructors.
    //
    internal interface IMethodDecoder
    {
        RoModule GetRoModule();

        string ComputeName();
        MethodAttributes ComputeAttributes();
        CallingConventions ComputeCallingConvention();
        MethodImplAttributes ComputeMethodImplementationFlags();
        int MetadataToken { get; }

        int ComputeGenericParameterCount();
        RoType[] ComputeGenericArgumentsOrParameters();

        IEnumerable<CustomAttributeData> ComputeTrueCustomAttributes();
        DllImportAttribute ComputeDllImportAttribute();

        MethodSig<RoParameter> SpecializeMethodSig(IRoMethodBase member);
        MethodBody? SpecializeMethodBody(IRoMethodBase owner);
        MethodSig<string> SpecializeMethodSigStrings(in TypeContext typeContext);
    }
}
