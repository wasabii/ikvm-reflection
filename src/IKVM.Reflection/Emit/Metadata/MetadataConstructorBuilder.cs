
namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataConstructorBuilder : ConstructorBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataConstructorBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override ConstructorInfo AsConstructorInfo()
        {
            throw new NotImplementedException();
        }

    }

}
