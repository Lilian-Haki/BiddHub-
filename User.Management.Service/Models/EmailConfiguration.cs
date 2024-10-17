﻿//A model for the email data
//Update the EmailData Model.The EmailData model can stay the same, as it's used to capture the recipient's details:
namespace User.Management.Service.Models
{
    public class EmailData
    {
        //public required string From { get; set; }
        public required string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
