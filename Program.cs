using System;
using Calculations;
using Exports;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("FEM výpočet ohybu a zvárania – TrumaBend V130");

            Console.Write("Materiál (S235, AISI 304, AlMg3, Pozink): ");
            string material = Console.ReadLine();

            Console.Write("Hrúbka plechu [mm]: ");
            double t = double.Parse(Console.ReadLine());

            Console.Write("Rameno A [mm]: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Rameno B [mm]: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Uhol ohybu [°]: ");
            double uhol = double.Parse(Console.ReadLine());

            Console.Write("Vnútorný polomer [mm]: ");
            double r = double.Parse(Console.ReadLine());

            Console.Write("Teplotný rozdiel ΔT [°]: ");
            double deltaT = double.Parse(Console.ReadLine());

            var props = MaterialDatabase.Materialy[material];

            double odpruzeneUhol = FEMOhybCalculator.SpringbackAngle(uhol, props.Re, props.E, t, r);
            double BA = FEMOhybCalculator.BendAllowance(uhol, r, t, props.KFactor);
            double BD = FEMOhybCalculator.BendDeduction(a, b, BA);

            double shrinkage = FEMZvarCalculator.LinearShrinkage(props.Alpha, deltaT, a);
            double distortion = FEMZvarCalculator.AngularDistortion(shrinkage, t);

            Console.WriteLine();
            Console.WriteLine($"Odpružený uhol: {odpruzeneUhol:F2}°");
            Console.WriteLine($"Bend Allowance (BA): {BA:F2} mm");
            Console.WriteLine($"Bend Deduction (BD): {BD:F2} mm");
            Console.WriteLine($"Zvarová kontrakcia: {shrinkage:F3} mm");
            Console.WriteLine($"Uhlová deformácia po zvare: {distortion:F2}°");

            ExcelExport.UlozVysledky("Vysledky.xlsx", material, t, a, b, uhol, r, deltaT,
                odpruzeneUhol, BA, BD, shrinkage, distortion);

            Console.WriteLine("\nVýsledky uložené do 'Vysledky.xlsx'.");
        }
    }
}

