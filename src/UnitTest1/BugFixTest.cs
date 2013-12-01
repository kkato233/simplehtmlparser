using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class BugFixTest
    {
        /// <summary>
        /// https://github.com/kkato233/simplehtmlparser/issues/2
        /// &lt;body&gt タグを探そうとしたら見つからなかった バグの修正
        /// </summary>
        [TestMethod]
        public void TestFix02()
        {
            // HTML パーサーインスタンス
            HtmlTools.HtmlParser p = new HtmlTools.HtmlParser();

            // 入力のHTML
            string html =
@"<html>
<head>
</head>
<body>
hello world.
<div class='test'>div-test<br><unknwontag></div>
<br>
</body>
</html>";

            // 文字列を解析してDOMにする
            var dom = p.ParseHtmlString(html);

            var body = dom.GetElementsByTagName("body");

            Assert.IsTrue(body != null);
            Assert.AreEqual(1, body.Count());
        }

        [TestMethod]
        public void TestFix03()
        {
            // https://github.com/kkato233/simplehtmlparser/issues/3
            // 属性を書き換えたら ' が " に代わってしまった

            // HTML パーサーインスタンス
            HtmlTools.HtmlParser p = new HtmlTools.HtmlParser();

            // 入力のHTML
            string html =
@"<html>
<head>
</head>
<body>
<div class='test'></div>
<br>
</body>
</html>";

            // 文字列を解析してDOMにする
            var dom = p.ParseHtmlString(html);

            var div = dom.GetElementsByTagName("div").FirstOrDefault();

            Assert.IsNotNull(div);
            div.SetAttributes("class", "test2");

            string outHtml = dom.ToHtmlString();
            Assert.IsTrue(outHtml.Contains("<div class='test2'>"),outHtml);
        }


        [TestMethod]
        public void TestFix03_A()
        {
            // https://github.com/kkato233/simplehtmlparser/issues/3
            // 属性を書き換えたら ' が " に代わってしまった

            // HTML パーサーインスタンス
            HtmlTools.HtmlParser p = new HtmlTools.HtmlParser();

            // 入力のHTML
            string html = "<div class='te\"st'></div>";

            // 文字列を解析してDOMにする
            var dom = p.ParseHtmlString(html);

            var div = dom.GetElementsByTagName("div").FirstOrDefault();

            Assert.IsNotNull(div);
            div.SetAttributes("class", "let's");

            string outHtml = dom.ToHtmlString();
            Assert.IsTrue(outHtml.Contains("<div class='let's'>"), outHtml);
        }


        [TestMethod]
        public void TestFix03_B()
        {
            // https://github.com/kkato233/simplehtmlparser/issues/3
            // 属性を書き換えたら ' が " に代わってしまった

            // HTML パーサーインスタンス
            HtmlTools.HtmlParser p = new HtmlTools.HtmlParser();

            // 入力のHTML
            string html = "<div class='\"'></div>";

            // 文字列を解析してDOMにする
            var dom = p.ParseHtmlString(html);

            var div = dom.GetElementsByTagName("div").FirstOrDefault();

            Assert.IsNotNull(div);
            div.SetAttributes("class", "\"");

            string outHtml = dom.ToHtmlString();
            Assert.IsTrue(outHtml.Contains("<div class='\"'>"), outHtml);
        }
    }
}
