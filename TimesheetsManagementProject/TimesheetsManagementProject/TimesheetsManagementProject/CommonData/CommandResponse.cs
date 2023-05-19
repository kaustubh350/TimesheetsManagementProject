namespace TimesheetsManagementProject.CommonData
{
    public class CommandResponse : Response
    {
        public CommandResponse() { }
        public CommandResponse(string Message, bool status = false)
        {
            IsSuccessful = status;
            Errors.Add(Message);
        }

        public CommandResponse(List<string> Messages, bool status = false)
        {
            IsSuccessful = status;
            Errors.AddRange(Messages);
        }
    }
}
