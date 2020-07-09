using System;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace StaticStrategy
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

	public class LogProcessor<T> where T: IRenderStrategy, new()
	{
		StringBuilder sb = new StringBuilder("");
		IRenderStrategy renderStrategy = new T();
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
			var processor = new LogProcessor<HtmlOutput>();
			processor.AppendList(new[] { "item1", "item2", "item3" });
			Console.WriteLine(processor.ToString());
			processor.Clear();

			var processor1 = new LogProcessor<TextOutput>();
			processor1.AppendList(new[] { "item4", "item5", "item6" });
			Console.WriteLine(processor1.ToString());

			Console.ReadKey();
		}
	}
}

