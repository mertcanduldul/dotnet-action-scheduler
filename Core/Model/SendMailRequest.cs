namespace Core.Model;

public class SendMailRequest
{
    public string EMAIL_TO { get; set; }
    public string EMAIL_CC { get; set; }
    public string EMAIL_BCC { get; set; }
    public string EMAIL_SUBJECT { get; set; }
    public string EMAIL_BODY { get; set; }
}