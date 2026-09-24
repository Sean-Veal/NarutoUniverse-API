using Naruto_Universe.Util;

namespace Naruto_Universe.Exceptions;

public class ApplicationException(Error error) : Exception
{
    public Error Error = error;
}