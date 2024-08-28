namespace FimpleWebApi_1.Models;

public class DenemeViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
