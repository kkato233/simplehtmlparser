using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTest1
{
    [TestClass]
    public class SimpleTest
    {
        /// <summary>
        /// 使い方を簡単に説明するためのテストプログラム
        /// </summary>
        [TestMethod]
        public void Test01_SimpleTest()
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

            Assert.IsNotNull(dom);

            // DIV タグを探す。大文字小文字は関係なく探す
            var divList = dom.GetElementsByTagName("Div");
            Assert.IsNotNull(divList);
            Assert.AreEqual(1, divList.Count());

            // div タグを選択
            var div = divList.First();
            
            // div タグの InnerHtml を書き換え
            div.InnerHtml = "";

            // DOM の HTML を取得する
            string html2 = dom.ToHtmlString();

            // DIV の内容が書き換わっている事の確認
            Assert.IsTrue(html2.Contains("<div class='test'></div>"));
        }
    }
}
