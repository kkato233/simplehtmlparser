Simple Html Parser
================

#### シンプルなHTMLパーサー

HTMLから指定の要素を抽出したり、指定の部分を書き換えることを簡単に
行う事ができるプログラムです。

### コードの例

HTMLを読み込んで `<a href="#"` の `href` 部分を書き換えるためのコードは下記のようなコードになります。

```
var parser = new HtmlParser();
var dom = parser.ParseHtmlString(html);
foreach (var item in dom.GetElementsByTagName("a"))
{
    string href = item.GetAttribute("href");
    if (href == "#") {
        item.SetAttribute("href","/");
    }
}

string fixHTML = dom.ToHtmlString();
```

### このライブラリの特徴

C# から利用できる HTML パーサーとして有名なものは

・Html Agility Pack
https://nuget.org/packages/HtmlAgilityPack  

・SGMLReader
https://nuget.org/packages/SgmlReader  

があります。

これらのライブラリでは オリジナルのHTMLとかなり違ったHTMLを
生成してしまいます。

'Simple Html Parser' では 改行コードや空白を一切変更せず
変更したい場所を変更した HTML を生成します。
