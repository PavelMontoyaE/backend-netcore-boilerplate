namespace Collaborator.Requests.Personal;

public class PersonalContractRequest
{
    public DateTime EntryDate  { get; set; }
    public DateTime? LeavingDate  { get; set; }
    public string? ExitReason  { get; set; }
}