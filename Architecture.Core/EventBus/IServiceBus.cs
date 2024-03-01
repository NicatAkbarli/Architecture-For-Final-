﻿using System;
namespace Architecture.Core.EventBus
{
	public interface IServiceBus
	{
        void SendMessage(object model, string queue);
        void ReciveMessage(string queue);
    }
}

