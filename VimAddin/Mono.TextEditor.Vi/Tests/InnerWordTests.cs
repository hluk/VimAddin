using System;
using Mono.TextEditor;
using NUnit.Framework;

namespace VimAddin.Tests
{
	[TestFixture]
	public class InnerWordTests
	{
		[Test]
		public void InnerWord_SelectFirst ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			ViActions.InnerWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (3, data.SelectionRange.Length);
		}

		[Test]
		public void InnerWord_SelectFirstTwo ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			ViActions.InnerWord (data);
			ViActions.InnerWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}

		[Test]
		public void InnerWord_SelectFirstThree ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			ViActions.InnerWord (data);
			ViActions.InnerWord (data);
			ViActions.InnerWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (7, data.SelectionRange.Length);
		}

		[Test]
		public void InnerWord_SelectSingleLetter ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "a b c";

			ViActions.InnerWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (1, data.SelectionRange.Length);

			ViActions.InnerWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (1, data.SelectionRange.Length);
		}

		[Test]
		public void InnerWord_SelectAtWordStart ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			data.Caret.Offset = 4;
			ViActions.InnerWord (data);
			Assert.AreEqual (4, data.SelectionRange.Offset);
			Assert.AreEqual (3, data.SelectionRange.Length);
		}

		[Test]
		public void InnerWord_SelectAtWordEnd ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			data.Caret.Offset = 6;
			ViActions.InnerWord (data);
			Assert.AreEqual (4, data.SelectionRange.Offset);
			Assert.AreEqual (3, data.SelectionRange.Length);
		}

		[Test]
		public void InnerWord_SelectLineStart ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc\ndef ghi";
			data.Caret.Offset = 4;
			ViActions.InnerWord (data);
			Assert.AreEqual (4, data.SelectionRange.Offset);
			Assert.AreEqual (3, data.SelectionRange.Length);
		}
	}
}
