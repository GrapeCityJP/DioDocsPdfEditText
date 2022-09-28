// See https://aka.ms/new-console-template for more information
using GrapeCity.Documents.Pdf;
using GrapeCity.Documents.Pdf.TextMap;

Console.WriteLine("PDFドキュメント内のテキストを編集");

// トライアル版または製品版のライセンスキーを設定
//GcPdfDocument.SetLicenseKey("");

// PDFファイルを読み込む
var doc = new GcPdfDocument();
var fs = File.OpenRead("expense-report.pdf");
doc.Load(fs);

// PDFドキュメント内のテキストを置換
doc.ReplaceText(new FindTextParams("葡萄　太郎", false, false), "寺岡　次郎");
doc.ReplaceText(new FindTextParams("2022年9月28日", false, false), "2022-09-28");
doc.ReplaceText(new FindTextParams("筆記用具", false, false), "筆記用具（ボールペン）");

// PDFドキュメント内のテキストを削除
FindTextParams ftp = new FindTextParams("（カツサンド）", false, false);
doc.DeleteText(ftp, DeleteTextMode.Standard, null);

// 編集前のPDFドキュメントをマージ
var docOrig = new GcPdfDocument();
docOrig.Load(fs);
doc.MergeWithDocument(docOrig);

// PDFファイルに保存
doc.Save("result.pdf");