
namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataLocalBuilder : LocalBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MetadataLocalBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override bool IsPinned => throw new NotImplementedException();

        public override int LocalIndex => throw new NotImplementedException();

        public override Type LocalType => throw new NotImplementedException();

        protected override LocalVariableInfo AsLocalVariableInfo()
        {
            throw new NotImplementedException();
        }

    }

}
