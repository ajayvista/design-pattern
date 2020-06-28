using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InterfaceSegregation.WithPrinciple
{
    public interface IMessage
    {
         IList<string> SendTo { get; set; }
         string MessageText { get; set; }
         bool Send();
    }

    public interface IEmailMessage
    {
         IList<string> CCTo { get; set; }
         IList<string> BCCTo { get; set; }
         IList<string> AttachementFilePaths { get; set; }
         string Subject { get; set; }
    }


	public class EmailMessage : IMessage, IEmailMessage
	{
		public IList<string> SendTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string MessageText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IList<string> CCTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IList<string> BCCTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IList<string> AttachementFilePaths { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool Send()
		{
			throw new NotImplementedException();
		}
	}

	public class TextMessage : IMessage
	{
		public IList<string> SendTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string MessageText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool Send()
		{
			throw new NotImplementedException();
		}
	}
}
