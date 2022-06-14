namespace Collaborator.Services;

public struct Messages
{
    internal struct GetAllByActive
    {
        internal const string OK = "Active personal data retrieved successfully";
        internal const string Ex = "Error retrieving active personal. See application log for details";
        internal const string EmptyList = "No active personal was found";
    }
    
    internal struct GetAll
    {
        internal const string OK = "Personal data retrieved successfully";
        internal const string Ex = "Error retrieving personal. See application log for details";
        internal const string EmptyList = "No personal was found";
    }
}