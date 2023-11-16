namespace CC35_APIWithAnnotations;

/// <summary>
/// An interface for a service that implements the business logic of our Lambda functions
/// </summary>
public interface ICodeCampService
{
    string GetCodeCampName(int number);

    string GetSlogan(int number);

    string AddCodeCamp(int number);

}
