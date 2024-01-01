using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Generates Microsoft intermediate language (MSIL) instructions.
    /// </summary>
    public abstract class ILGenerator
    {

        /// <summary>
        /// Specifies the namespace to be used in evaluating locals and watches for the current active lexical scope.
        /// </summary>
        /// <param name="usingNamespace"></param>
        public abstract void UsingNamespace(string usingNamespace);

        /// <summary>
        /// Declares a local variable of the specified type, optionally pinning the object referred to by the variable.
        /// </summary>
        /// <param name="localType"></param>
        /// <param name="pinned"></param>
        /// <returns></returns>
        public abstract LocalBuilder DeclareLocal(Type localType, bool pinned);

        /// <summary>
        /// Declares a local variable of the specified type.
        /// </summary>
        /// <param name="localType"></param>
        /// <returns></returns>
        public abstract LocalBuilder DeclareLocal(Type localType);

        /// <summary>
        /// Declares a new label.
        /// </summary>
        /// <returns></returns>
        public abstract Label DefineLabel();

        /// <summary>
        /// Marks the Microsoft intermediate language (MSIL) stream's current position with the given label.
        /// </summary>
        /// <param name="loc"></param>
        public abstract void MarkLabel(Label loc);

        /// <summary>
        /// Begins a catch block.
        /// </summary>
        /// <param name="exceptionType"></param>
        public abstract void BeginCatchBlock(Type exceptionType);

        /// <summary>
        /// Begins an exception block for a filtered exception.
        /// </summary>
        public abstract void BeginExceptFilterBlock();

        /// <summary>
        /// Begins an exception block for a non-filtered exception.
        /// </summary>
        /// <returns></returns>
        public abstract Label BeginExceptionBlock();

        /// <summary>
        /// Begins an exception fault block in the Microsoft intermediate language (MSIL) stream.
        /// </summary>
        public abstract void BeginFaultBlock();

        /// <summary>
        /// Begins a finally block in the Microsoft intermediate language (MSIL) instruction stream.
        /// </summary>
        public abstract void BeginFinallyBlock();

        /// <summary>
        /// Begins an exception block for a non-filtered exception.
        /// </summary>
        public abstract void EndExceptionBlock();

        /// <summary>
        /// Emits an instruction to throw an exception.
        /// </summary>
        /// <param name="excType"></param>
        public abstract void ThrowException(Type excType);

        /// <summary>
        /// Begins a lexical scope.
        /// </summary>
        public abstract void BeginScope();

        /// <summary>
        /// Ends a lexical scope.
        /// </summary>
        public abstract void EndScope();

        /// <summary>
        /// Puts the specified instruction onto the Microsoft intermediate language (MSIL) stream followed by the index of the given local variable.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="local"></param>
        public abstract void Emit(OpCode opcode, LocalBuilder local);

        /// <summary>
        /// Puts the specified instruction onto the Microsoft intermediate language (MSIL) stream followed by the metadata token for the given type.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="cls"></param>
        public abstract void Emit(OpCode opcode, Type cls);

        /// <summary>
        /// Puts the specified instruction onto the Microsoft intermediate language (MSIL) stream followed by the metadata token for the given string.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="str"></param>
        public abstract void Emit(OpCode opcode, string str);

        /// <summary>
        /// Puts the specified instruction and numerical argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, float arg);

        /// <summary>
        /// Puts the specified instruction and character argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, sbyte arg);

        /// <summary>
        /// Puts the specified instruction onto the Microsoft intermediate language (MSIL) stream followed by the metadata token for the given method.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="meth"></param>
        public abstract void Emit(OpCode opcode, MethodInfo meth);

        /// <summary>
        /// Puts the specified instruction and a signature token onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="signature"></param>
        public abstract void Emit(OpCode opcode, SignatureHelper signature);

        /// <summary>
        /// Puts the specified instruction onto the Microsoft intermediate language (MSIL) stream and leaves space to include a label when fixes are done.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="labels"></param>
        public abstract void Emit(OpCode opcode, Label[] labels);

        /// <summary>
        /// Puts the specified instruction and metadata token for the specified field onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="field"></param>
        public abstract void Emit(OpCode opcode, FieldInfo field);

        /// <summary>
        /// Puts the specified instruction and metadata token for the specified constructor onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="con"></param>
        public abstract void Emit(OpCode opcode, ConstructorInfo con);

        /// <summary>
        /// Puts the specified instruction and numerical argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, long arg);

        /// <summary>
        /// Puts the specified instruction and numerical argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, int arg);

        /// <summary>
        /// Puts the specified instruction and numerical argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, short arg);

        /// <summary>
        /// Puts the specified instruction and numerical argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, double arg);

        /// <summary>
        /// Puts the specified instruction and character argument onto the Microsoft intermediate language (MSIL) stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="arg"></param>
        public abstract void Emit(OpCode opcode, byte arg);

        /// <summary>
        /// Puts the specified instruction onto the stream of instructions.
        /// </summary>
        /// <param name="opcode"></param>
        public abstract void Emit(OpCode opcode);

        /// <summary>
        /// Puts the specified instruction onto the Microsoft intermediate language (MSIL) stream and leaves space to include a label when fixes are done.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="label"></param>
        public abstract void Emit(OpCode opcode, Label label);

        /// <summary>
        /// Puts a call or callvirt instruction onto the Microsoft intermediate language (MSIL) stream to call a varargs method.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="methodInfo"></param>
        /// <param name="optionalParameterTypes"></param>
        public abstract void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[]? optionalParameterTypes);

        /// <summary>
        /// Puts a Calli instruction onto the Microsoft intermediate language (MSIL) stream, specifying an unmanaged calling convention for the indirect call.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="unmanagedCallConv"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        public abstract void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type? returnType, Type[]? parameterTypes);

        /// <summary>
        /// Puts a Calli instruction onto the Microsoft intermediate language (MSIL) stream, specifying a managed calling convention for the indirect call.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="optionalParameterTypes"></param>
        public abstract void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type[]? optionalParameterTypes);

        /// <summary>
        /// Emits the Microsoft intermediate language (MSIL) to call WriteLine with a string.
        /// </summary>
        /// <param name="value"></param>
        public abstract void EmitWriteLine(string value);

        /// <summary>
        /// Emits the Microsoft intermediate language (MSIL) necessary to call WriteLine with the given field.
        /// </summary>
        /// <param name="fld"></param>
        public abstract void EmitWriteLine(FieldInfo fld);

        /// <summary>
        /// Emits the Microsoft intermediate language (MSIL) necessary to call WriteLine with the given local variable.
        /// </summary>
        /// <param name="localBuilder"></param>
        public abstract void EmitWriteLine(LocalBuilder localBuilder);

    }

}
