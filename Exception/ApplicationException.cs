using Naruto_Universe.Util;

namespace Naruto_Universe.Exception;

public class ApplicationException(Error error) : System.Exception
{
    public Error Error = error;
}