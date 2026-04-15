namespace AgendamentoHospitalarInteligente.Domain.Exceptions
{
    public class DomainValidationException : DomainException
    {
        public DomainValidationException(string message) : base(message) { }
        public static new void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidationException(message);
        }
    }
}
