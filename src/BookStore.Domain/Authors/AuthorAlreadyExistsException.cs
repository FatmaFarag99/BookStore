using BookStore;
using Volo.Abp;

public class AuthorAlreadyExistsException : BusinessException
{
    public AuthorAlreadyExistsException(string name)
        : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}
