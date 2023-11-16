namespace CC35_APIWithAnnotations;

public class CodeCampService : ICodeCampService
{
    public string AddCodeCamp(int number)
    {
        return $"Code Camp {number} has been scheduled";
    }

    public string GetCodeCampName(int number)
    {
        return $"Boston Code Camp {number}";
    }

    public string GetSlogan(int number)
    {
        return number switch
        {
            < 35 => $"Code Camp {number} - Already Happened!",
            > 35 => $"Code Camp {number} - Coming Soon!",
            _ => $"Code Camp {number} - That is today!",

        };
    }
}
