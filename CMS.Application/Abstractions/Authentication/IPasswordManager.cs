namespace CMS.Application.Abstractions.Authentication;

public interface IPasswordManager
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}