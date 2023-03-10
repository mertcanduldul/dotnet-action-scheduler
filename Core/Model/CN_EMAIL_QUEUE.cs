namespace Core.Model;

public class CN_EMAIL_QUEUE
{
    public int ID_EMAIL_QUEUE { get; set; }
    public string EMAIL_FROM { get; set; }
    public string EMAIL_TO { get; set; }
    public string EMAIL_CC { get; set; }
    public string EMAIL_BCC { get; set; }
    public string EMAIL_SUBJECT { get; set; }
    public string EMAIL_BODY { get; set; }
    public DateTime EMAIL_DATE { get; set; }
    public string EMAIL_STATUS { get; set; }
}