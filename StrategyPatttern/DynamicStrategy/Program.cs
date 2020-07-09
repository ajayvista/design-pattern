using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DynamicStrategy
{
	public enum OutputFormat
	{
		Markdown,
		Html
	}

	public interface IRenderStrategy
	{
		void Start(StringBuilder sb);
		void End(StringBuilder sb);
		void AddItem(StringBuilder stringBuilder, string item);
	}

	public class HtmlOutput : IRenderStrategy
	{
		public void AddItem(StringBuilder stringBuilder, string item)
		{
			stringBuilder.AppendLine($"<li>{item}</li>");
		}

		public void End(StringBuilder sb)
		{
			sb.AppendLine($"<ul>");
		}

		public void Start(StringBuilder sb)
		{
			sb.AppendLine($"</ul>");
		}
	}

	public class TextOutput : IRenderStrategy
	{
		public void AddItem(StringBuilder stringBuilder, string item)
		{
			stringBuilder.AppendLine($"* {item}");
		}

		public void End(StringBuilder sb)
		{
			sb.AppendLine($"");
		}

		public void Start(StringBuilder sb)
		{
			sb.AppendLine($"");
		}
	}

	public class LogProcessor
	{
		StringBuilder sb = new StringBuilder("");
		IRenderStrategy renderStrategy;
		public void SetStrategy(OutputFormat outputFormat)
		{
			switch (outputFormat)
			{
				case OutputFormat.Html:
					{
						renderStrategy = new HtmlOutput();
						break;
					}
				case OutputFormat.Markdown:
					{
						renderStrategy = new TextOutput();
						break;
					}
				default:
					throw new Exception("Invalid output format for log processor");
			}
		}

		public void AppendList(IEnumerable<string> listOfItems)
		{
			renderStrategy.Start(sb);
			foreach (var item in listOfItems)
				renderStrategy.AddItem(sb, item);
			renderStrategy.End(sb);
		}

		public void Clear()
		{
			sb.Clear();
		}

		public override string ToString()
		{
			return sb.ToString();
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			var processor = new LogProcessor();
			processor.SetStrategy(OutputFormat.Html);
			processor.AppendList(new []{ "item1", "item2", "item3" });
			Console.WriteLine(processor.ToString());
			processor.Clear();

			processor.SetStrategy(OutputFormat.Markdown);
			processor.AppendList(new[] { "item4", "item5", "item6" });
			Console.WriteLine(processor.ToString());

			Console.ReadKey();
		}
	}
}

