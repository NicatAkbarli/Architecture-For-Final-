using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.MailHelper;
using Architecture.Entities.Commands;
using MassTransit;

namespace Architecture.Business.Consumers
{
public class SendEmailConsumer : IConsumer<SendEmailCommand>
{
     private readonly IMailSender _mailSender;

     public SendEmailConsumer(IMailSender mailSender)
     {
         _mailSender = mailSender;
     }

    public async Task Consume(ConsumeContext<SendEmailCommand> context)
    {
         _mailSender.SendEmail(context.Message.Email, "Confirmation", "Content");
    }


}}