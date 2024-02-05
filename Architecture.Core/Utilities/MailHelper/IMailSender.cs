using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;

namespace Architecture.Core.Utilities.MailHelper;

public interface IMailSender
{
    IResult SendEmail(string receiverEmail, string subject, string body);
}
