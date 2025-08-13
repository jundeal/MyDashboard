using DocumentAIProcessor;

// See https://aka.ms/new-console-template for more information

var doc = new Document();

var result = await doc.ProcessDocumentAsync(@"C:\Users\geron\Local\My Files\Financials\Stocks\COL\MONTHLY_LEDGER_2025\MONTHLY LEDGER_202502.html", "COL Finanancial Statement");

Console.WriteLine(result);
