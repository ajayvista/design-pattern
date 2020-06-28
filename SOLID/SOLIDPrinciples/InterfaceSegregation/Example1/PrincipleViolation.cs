using System;
using System.Collections.Generic;
using System.IO;
namespace InterfaceSegregation.PrincipleViolation
{
    public interface IMessage
    {
		IList<string> SendToAddress { get; set; }
        string Subject { get; set; }
        string MessageText { get; set; }
        bool Send();
    }

	public class EmailMessage : IMessage
	{
		public IList<string> SendToAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string MessageText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool Send()
		{
			throw new NotImplementedException();
		}
	}

	public class TextMessage : IMessage
	{
		public IList<string> SendToAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		// Subject not relevant for text message, but it still need to be here

		public string MessageText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool Send()
		{
			throw new NotImplementedException();
		}
	}
}
