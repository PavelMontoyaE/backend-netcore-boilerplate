using BI.Core;

namespace Collaborator.Entities;

public class ContractEntity : MetaDataEntity
{
    public int IdContract { get; set; }
    public DateTime EntryDate { get; set; }
    public DateTime? LeavingDate { get; set; }
    public string? ExitType { get; set; }
    public string? ExitReason { get; set; }
}