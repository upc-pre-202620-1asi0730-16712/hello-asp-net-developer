namespace Acme.Hello.Platform.Generic.Domain.Model.Entities;

public class Developer
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public string FirstName { get; }
    
    public string LastName { get; }

    public Developer(string firstName, string lastName)
    {
        FirstName = string.IsNullOrWhiteSpace(firstName) ? "" : firstName;
        LastName = string.IsNullOrWhiteSpace(lastName) ? "" : lastName;
    }
    
    public string GetFullName => $"{FirstName} {LastName}";
    
    public bool IsAnyNameEmpty => string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName);
}