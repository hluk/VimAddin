using System;
using Mono.TextEditor;
using NUnit.Framework;

namespace VimAddin.Tests
{
	[TestFixture]
	public class OuterWordTests
	{
		[Test]
		public void OuterWord_SelectFirst ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			ViActions.OuterWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectFirstTwo ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			ViActions.OuterWord (data);
			ViActions.OuterWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (8, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectFirstThree ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			ViActions.OuterWord (data);
			ViActions.OuterWord (data);
			ViActions.OuterWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (11, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectSingleLetter ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "a b c";

			ViActions.OuterWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (2, data.SelectionRange.Length);

			ViActions.OuterWord (data);
			Assert.AreEqual (0, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectAtWordStart ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			data.Caret.Offset = 4;
			ViActions.OuterWord (data);
			Assert.AreEqual (4, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectAtWordEnd ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def ghi";
			data.Caret.Offset = 6;
			ViActions.OuterWord (data);
			Assert.AreEqual (4, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectLineStart ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc\ndef ghi";
			data.Caret.Offset = 4;
			ViActions.OuterWord (data);
			Assert.AreEqual (4, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}

		[Test]
		public void OuterWord_SelectLineEnd ()
		{
			TextEditorData data = new TextEditorData ();
			data.Text = "abc def\nghi";
			data.Caret.Offset = 6;
			ViActions.OuterWord (data);
			Assert.AreEqual (3, data.SelectionRange.Offset);
			Assert.AreEqual (4, data.SelectionRange.Length);
		}
	}
}
