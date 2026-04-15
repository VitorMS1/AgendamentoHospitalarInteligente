using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AgendamentoHospitalarInteligente.Application.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message) { }

        public static T WhenNull<T>([NotNull] T? value, string message)
        {
            if (value is null)
                throw new ResourceNotFoundException(message);

            return value;
        }
    }
}
