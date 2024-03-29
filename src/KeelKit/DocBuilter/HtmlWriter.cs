﻿// SharpDevelop samples
// Copyright (c) 2007, AlphaSierraPapa
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are
// permitted provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this list
//   of conditions and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice, this list
//   of conditions and the following disclaimer in the documentation and/or other materials
//   provided with the distribution.
//
// - Neither the name of the SharpDevelop team nor the names of its contributors may be used to
//   endorse or promote products derived from this software without specific prior written
//   permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS &AS IS& AND ANY EXPRESS
// OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY
// AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
// IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
// OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.TextEditor.Document;

namespace KeelKit.HtmlSyntaxColorizer
{
	public class HtmlWriter
	{
		public bool AlternateLineBackground;
		public bool ShowLineNumbers;
		
		public string MainStyle = "font-size: small; font-family: Consolas, \"Courier New\", Courier, Monospace;";
		public string LineStyle = "margin: 0em;";
		public string AlternateLineStyle = "margin: 0em; width: 100%; background-color: #f0f0f0;";
		
		#region Stylesheet cache
		/// <summary>
		/// Specifies whether a CSS stylesheet should be created to reduce the size of the created code.
		/// The default value is true.
		/// </summary>
		public bool CreateStylesheet = true;
		
		/// <summary>
		/// Specifies the prefix to use in front of generate style class names.
		/// </summary>
		public string StyleClassPrefix = "code";
		
		Dictionary<string, string> stylesheetCache = new Dictionary<string, string>();
		
		/// <summary>
		/// Resets the CSS stylesheet cache. Stylesheet classes will be cached on GenerateHtml calls.
		/// If you want to reuse the HtmlWriter for multiple
		/// </summary>
		public void ResetStylesheetCache()
		{
			stylesheetCache.Clear();
		}
		
		string GetClass(string style)
		{
			return stylesheetCache[style];
		}
		
		void CacheClass(string style, StringBuilder b)
		{
			if (style == null) return;
			if (!stylesheetCache.ContainsKey(style)) {
				string styleName = StyleClassPrefix + stylesheetCache.Count;
				stylesheetCache[style] = styleName;
				b.Append('.');
				b.Append(styleName);
				b.Append(" { ");
				b.Append(style);
				b.AppendLine(" }");
			}
		}
		#endregion

        public string GenerateHtml(string filename, string highlighterName)
		{
			IDocument doc = new DocumentFactory().CreateDocument();
            if (highlighterName != null)
            {
                doc.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter(highlighterName);
            }
            else
            {
                doc.HighlightingStrategy = HighlightingManager.Manager.FindHighlighterForFile(filename);
            }
            string code = File.ReadAllText(filename);
			doc.TextContent = code;
			return GenerateHtml(doc);
		}
		
		HighlightColor currentDefaultTextColor;
		
		public string GenerateHtml(IDocument document)
		{
			string myMainStyle = MainStyle;
			currentDefaultTextColor = document.HighlightingStrategy.GetColorFor("Default");
			myMainStyle += " color: " + ColorToString(currentDefaultTextColor.Color) + ";"
				+ " background-color: " + ColorToString(currentDefaultTextColor.BackgroundColor) + ";";
			
			string LineNumberStyle;
			HighlightColor lineNumbersColor = document.HighlightingStrategy.GetColorFor("LineNumbers");
			if (lineNumbersColor != null) {
				LineNumberStyle = "color: " + ColorToString(lineNumbersColor.Color) + ";"
					+ " background-color: " + ColorToString(lineNumbersColor.BackgroundColor) + ";";
			} else {
				LineNumberStyle = "color: #606060;";
			}
			
			StringBuilder b = new StringBuilder();
			if (CreateStylesheet) {
				b.AppendLine("<style type=\"text/css\">");
				if (ShowLineNumbers || AlternateLineBackground) {
					CacheClass(myMainStyle, b);
					CacheClass(LineStyle, b);
				} else {
					CacheClass(myMainStyle + LineStyle, b);
				}
				if (AlternateLineBackground) CacheClass(AlternateLineStyle, b);
				if (ShowLineNumbers) CacheClass(LineNumberStyle, b);
				foreach (LineSegment ls in document.LineSegmentCollection) {
					foreach (TextWord word in ls.Words) {
						CacheClass(GetStyle(word), b);
					}
				}
				b.AppendLine("</style>");
			}
			if (ShowLineNumbers || AlternateLineBackground) {
				b.Append("<div");
				WriteStyle(myMainStyle, b);
				b.AppendLine(">");
				
				int longestNumberLength = 1 + (int)Math.Log10(document.TotalNumberOfLines);
				
				int lineNumber = 1;
				foreach (LineSegment lineSegment in document.LineSegmentCollection) {
					b.Append("<pre");
					if (AlternateLineBackground && (lineNumber % 2) == 0) {
						WriteStyle(AlternateLineStyle, b);
					} else {
						WriteStyle(LineStyle, b);
					}
					b.Append(">");
					
					if (ShowLineNumbers) {
						b.Append("<span");
						WriteStyle(LineNumberStyle, b);
						b.Append('>');
						b.Append(lineNumber.ToString().PadLeft(longestNumberLength));
						b.Append(":  ");
						b.Append("</span>");
					}
					
					
					if (lineSegment.Words.Count == 0) {
						b.Append("&nbsp;");
					} else {
						PrintWords(lineSegment, b);
					}
					b.AppendLine("</pre>");
					
					lineNumber++;
				}
				b.AppendLine("</div>");
			} else {
				b.Append("<pre");
				WriteStyle(myMainStyle + LineStyle, b);
				b.AppendLine(">");
				foreach (LineSegment lineSegment in document.LineSegmentCollection) {
					PrintWords(lineSegment, b);
					b.AppendLine();
				}
				b.AppendLine("</pre>");
			}
			return b.ToString();
		}
		
		void PrintWords(LineSegment lineSegment, StringBuilder b)
		{
			string currentSpan = null;
			foreach (TextWord word in lineSegment.Words) {
				if (word.Type == TextWordType.Space) {
					b.Append(' ');
				} else if (word.Type == TextWordType.Tab) {
					b.Append('\t');
				} else {
					string newSpan = GetStyle(word);
					if (currentSpan != newSpan) {
						if (currentSpan != null) b.Append("</span>");
						if (newSpan != null) {
							b.Append("<span");
							WriteStyle(newSpan, b);
							b.Append('>');
						}
						currentSpan = newSpan;
					}
					b.Append(HtmlEncode(word.Word));
				}
			}
			if (currentSpan != null) b.Append("</span>");
		}
		
		static string HtmlEncode(string word)
		{
			return word.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
		}
		
		void WriteStyle(string style, StringBuilder b)
		{
			if (CreateStylesheet) {
				b.Append(" class=\"");
				b.Append(GetClass(style));
				b.Append('"');
			} else {
				b.Append(" style='");
				b.Append(style);
				b.Append("'");
			}
		}
		
		string GetStyle(TextWord word)
		{
			if (word.SyntaxColor == null || word.SyntaxColor.ToString() == currentDefaultTextColor.ToString())
				return null;
			
			string style = "color: " + ColorToString(word.Color) + ";";
			if (word.Bold) {
				style += " font-weight: bold;";
			}
			if (word.Italic) {
				style += "  font-style: italic;";
			}
			if (word.SyntaxColor.HasBackground) {
				style += "  background-color: " + ColorToString(word.SyntaxColor.BackgroundColor) + ";";
			}
			return style;
		}
		
		static string ColorToString(System.Drawing.Color color)
		{
			return "#" + color.R.ToString("x2") + color.G.ToString("x2") + color.B.ToString("x2");
		}
	}
}
