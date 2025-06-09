using System;
using ClosedXML.Excel;

namespace Exports
{
    public static class ExcelExport
    {
        public static void UlozVysledky(string cesta, string material, double t, double a, double b, double uhol, double r, double deltaT,
                                        double odpruzeneUhol, double BA, double BD, double shrinkage, double distortion)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Vysledok");

            ws.Cell(1, 1).Value = "Parameter";
            ws.Cell(1, 2).Value = "Hodnota";

            int row = 2;
            ws.Cell(row++, 1).Value = "Materiál"; ws.Cell(row - 1, 2).Value = material;
            ws.Cell(row++, 1).Value = "Hrúbka plechu [mm]"; ws.Cell(row - 1, 2).Value = t;
            ws.Cell(row++, 1).Value = "Rameno A [mm]"; ws.Cell(row - 1, 2).Value = a;
            ws.Cell(row++, 1).Value = "Rameno B [mm]"; ws.Cell(row - 1, 2).Value = b;
            ws.Cell(row++, 1).Value = "Uhol ohybu [°]"; ws.Cell(row - 1, 2).Value = uhol;
            ws.Cell(row++, 1).Value = "Vnútorný polomer [mm]"; ws.Cell(row - 1, 2).Value = r;
            ws.Cell(row++, 1).Value = "Teplotný rozdiel ΔT [K]"; ws.Cell(row - 1, 2).Value = deltaT;
            ws.Cell(row++, 1).Value = "Odpružený uhol [°]"; ws.Cell(row - 1, 2).Value = odpruzeneUhol;
            ws.Cell(row++, 1).Value = "Bend Allowance (BA) [mm]"; ws.Cell(row - 1, 2).Value = BA;
            ws.Cell(row++, 1).Value = "Bend Deduction (BD) [mm]"; ws.Cell(row - 1, 2).Value = BD;
            ws.Cell(row++, 1).Value = "Zvarová kontrakcia [mm]"; ws.Cell(row - 1, 2).Value = shrinkage;
            ws.Cell(row++, 1).Value = "Uhlová deformácia [°]"; ws.Cell(row - 1, 2).Value = distortion;

            wb.SaveAs(cesta);
        }
    }
}
