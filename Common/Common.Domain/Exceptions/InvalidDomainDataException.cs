namespace Common.Domain.Exceptions
{
    public partial class BaseDomainExceotion
    {
        public class InvalidDomainDataException : BaseDomainExceotion
        {
            public InvalidDomainDataException()
            {

            }

            public InvalidDomainDataException(string message) : base(message)
            {
            }
        } 
    }
}
