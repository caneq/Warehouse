using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;
using Warehouse.BusinessLogicLayer.Interfaces;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using Warehouse.ClassLibrary;
using DocumentFormat.OpenXml.Packaging;

namespace Warehouse.BusinessLogicLayer.Services
{
    public class DocumentService : IDocumentService
    {
        public MemoryStream CreateWordInvoice(ShipmentDTO shipment)
        {
            var body = new Body();
            var document = new Document(body);
            string fontName = "Times New Roman";

            var table = CreateTable();
            var headRow = new TableRow();
            table.Append(headRow);
            headRow.Append(new TableCell(CreateParagraph("№", fontName, 12, JustificationValues.Center)));
            headRow.Append(new TableCell(CreateParagraph("Код", fontName, 12, JustificationValues.Center)));
            headRow.Append(new TableCell(CreateParagraph("Товар", fontName, 12, JustificationValues.Center)));
            headRow.Append(new TableCell(CreateParagraph("Кол-во", fontName, 12, JustificationValues.Center)));
            headRow.Append(new TableCell(CreateParagraph("Ед.", fontName, 12, JustificationValues.Center)));
            headRow.Append(new TableCell(CreateParagraph("Цена", fontName, 12, JustificationValues.Center)));
            headRow.Append(new TableCell(CreateParagraph("Сумма", fontName, 12, JustificationValues.Center)));

            int i = 1;
            foreach(var orderItem in shipment.Order.Items)
            {
                var row = new TableRow();
                table.Append(row);
                row.Append(new TableCell(CreateParagraph(i.ToString(), fontName, 12, JustificationValues.Center)));
                row.Append(new TableCell(CreateParagraph(orderItem.ProductId.ToString(), fontName, 12, JustificationValues.Center)));
                row.Append(new TableCell(CreateParagraph(orderItem.Product.Name, fontName, 12, JustificationValues.Center)));
                row.Append(new TableCell(CreateParagraph("1", fontName, 12, JustificationValues.Center)));
                row.Append(new TableCell(CreateParagraph(orderItem.Product.Unit.ToString(), fontName, 12, JustificationValues.Center)));
                row.Append(new TableCell(CreateParagraph(orderItem.Price.ToString(), fontName, 12, JustificationValues.Center)));
                row.Append(new TableCell(CreateParagraph((new Price(orderItem.Price.Penny * 1)).ToString(), fontName, 12, JustificationValues.Center)));
                ++i;
            }

            var table2 = CreateTable(BorderValues.None);
            var row2 = new TableRow();
            row2.Append(new TableCell(CreateParagraph("Сдал:")));
            row2.Append(new TableCell(CreateParagraph(shipment.Conveyed.UserName ?? shipment.ConveyedName)));
            row2.Append(new TableCell(CreateParagraph("____________")));
            row2.Append(new TableCell(CreateParagraph("подпись")));
            table2.Append(row2);

            row2 = new TableRow();
            row2.Append(new TableCell(CreateParagraph("Получил:")));
            row2.Append(new TableCell(CreateParagraph(shipment.Repicient.UserName ?? shipment.RepicientName)));
            row2.Append(new TableCell(CreateParagraph("____________")));
            row2.Append(new TableCell(CreateParagraph("подпись")));
            table2.Append(row2);

            document.Append(CreateParagraph($"Накладная №{shipment.Id} от {shipment.DateTime.ToString("dd MMMM yyyy")}", fontName, 16, JustificationValues.Center));
            document.Append(table);
            document.Append(CreateParagraph($"Итого {shipment.Order.TotalPrice}"));
            document.Append(table2);

            MemoryStream resultStream = new MemoryStream();
            using (var doc = WordprocessingDocument.Create(
                    resultStream, WordprocessingDocumentType.Document))
            {
                doc.AddMainDocumentPart();
                doc.MainDocumentPart.Document = document;
                doc.MainDocumentPart.Document.Save();
            }
            resultStream.Flush();
            resultStream.Position = 0;
            return resultStream;
        }
        private static Paragraph CreateParagraph(string text, string fontName = "Times New Roman", int fontSize = 14, JustificationValues justification = JustificationValues.Left)
        {
            Run run = new Run(new Text(text));
            RunProperties prop = new RunProperties();

            prop.FontSize = new FontSize { Val = (fontSize*2).ToString() };
            prop.RunFonts = new RunFonts { Ascii = fontName, HighAnsi = fontName };

            run.PrependChild(prop);
            var para = new Paragraph(run);

            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.Append(new Justification { Val = justification });
            para.PrependChild(paragraphProperties);
            return para;
        }

        private static Table CreateTable(BorderValues border = BorderValues.Single)
        {
            TableProperties properties = new TableProperties();

            //table borders
            TableBorders borders = new TableBorders();

            borders.TopBorder = new TopBorder() { Val = new EnumValue<BorderValues>(border) };
            borders.BottomBorder = new BottomBorder() { Val = new EnumValue<BorderValues>(border) };
            borders.LeftBorder = new LeftBorder() { Val = new EnumValue<BorderValues>(border) };
            borders.RightBorder = new RightBorder() { Val = new EnumValue<BorderValues>(border) };
            borders.InsideHorizontalBorder = new InsideHorizontalBorder() { Val = border };
            borders.InsideVerticalBorder = new InsideVerticalBorder() { Val = border };

            properties.Append(borders);

            //set the table width to page width
            TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };
            properties.Append(tableWidth);

            //add properties to table
            Table table = new Table();
            table.Append(properties);
            return table;
        }

    }
}
