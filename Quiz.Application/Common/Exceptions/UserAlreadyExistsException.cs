namespace Quiz.Application.Common.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string email)
    : base($"Status Code 409. User with \"{email}\" email alerady exists.") { }
    }
}
