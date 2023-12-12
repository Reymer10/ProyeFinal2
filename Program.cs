using ProyecFinal;

class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static List<Prestamo> prestamos = new List<Prestamo>();
    static List<Pago> pagos = new List<Pago>();

    static void Main(string[] args)
    {
        {
            Calculoprestamo prestamo = new Calculoprestamo();
            prestamo.Recibir_datos();
            prestamo.Operaciones_cal();
            prestamo.Imprimir_datos();
            prestamo.Tablaamortizada();
            Console.ReadKey();
        }

    }

    class Calculoprestamo
    {
        private double monto;
        private double tasadeinteres, interes_mensual;
        private int plazomeses;
        private double cuotamensual;
        private DateTime fecha = DateTime.Today;

        public void Recibir_datos()
        {
            Console.Write("\n \n" + "=============================================");
            Console.Write(" CALCULADORA DE PRÉSTAMOS ");
            Console.WriteLine("=============================================" + "\n");

            Console.Write("Ingrese el Monto del préstamo en RD$: ");
            try
            {
                monto = double.Parse(Console.ReadLine());
                if (monto <= 0)
                {
                    Console.Write("Debe ingresar un valor mayor a $0. Vuela a infresar el monto: ");
                    monto = double.Parse(Console.ReadLine());
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("No has introducido un valor numérico válido. Ha tomado por monto el valor $0");
                Console.WriteLine(ex.Message);
                monto = 0;
            }


            Console.Write("Ingrese la Tasa de Porcentaje Anual %: ");
            try
            {
                tasadeinteres = double.Parse(Console.ReadLine());
                if (tasadeinteres <= 0)
                {
                    Console.Write("Debe ingresar un valor mayor a 0%. Vuela a infresar el la tasa de interes anual: ");
                    tasadeinteres = double.Parse(Console.ReadLine());
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("No has introducido un valor numérico válido. Ha tomado por tasa de interes anual el valor 0%");
                Console.WriteLine(ex.Message);
                tasadeinteres = 0;
            }


            Console.Write("Ingrese la cantidad de Plazos en meses: ");
            try
            {
                plazomeses = int.Parse(Console.ReadLine());
                if (plazomeses <= 0)
                {
                    Console.Write("Debe ingresar un valor mayor a 0. Vuela a infresar el plazo en meses: ");
                    plazomeses = int.Parse(Console.ReadLine());
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("No has introducido un valor numérico válido. Ha tomado el plazo en mese con valor 0");
                Console.WriteLine(ex.Message);
                plazomeses = 0;
            }
            
        }

        public void Operaciones_cal()
        {
            interes_mensual = tasadeinteres / 1200;
            cuotamensual = monto * (interes_mensual / (double)(1 - Math.Pow(1 + (double)interes_mensual, -plazomeses)));
        }

        public void Imprimir_datos()
        {
            Console.Clear();
            Console.Write("\n \n" + "=============================================");
            Console.Write(" CALCULADORA DE PRÉSTAMOS ");
            Console.WriteLine("=============================================" + "\n");
            Console.WriteLine("\n Usted está simulando un crédito con las siguientes características:");

            Console.WriteLine($"\n\t Monto del prestamo en RD$: \t \t {Math.Round(monto, 2)}");
            Console.WriteLine($"\t Tasa de Porcentaje Anual: \t \t {tasadeinteres}%");
            Console.WriteLine($"\t Plazo: \t \t \t \t {plazomeses}");
            Console.WriteLine($"\t Valor Cuota: \t \t \t \t RD$ {Math.Round(cuotamensual, 2)}");
        }

        public void Tablaamortizada()
        {
            Console.Write("\n \n" + "=============================================");
            Console.Write(" Tabla de Amortización ");
            Console.WriteLine("=============================================" + "\n");

            Console.WriteLine(" Pago \t\t Fecha de Pago \t\t Cuota \t\t Capital \t Interes \t Balance ");
            Console.WriteLine("_________________________________________________________________________________________________________________ ");

            for (int i = 1; i <= plazomeses; i++)
            {
                double pagointeres = interes_mensual * monto;
                double pagocapital = cuotamensual - pagointeres;
                monto = monto - pagocapital;
                fecha = fecha.AddDays(30);

                if (monto < 1)
                {
                    monto = 0;
                }

                Console.WriteLine($" {i} \t\t {fecha.ToString("dd-MMM-yyyy")} \t\t {Math.Round(cuotamensual, 2)} \t {Math.Round(pagocapital, 2)} \t " +
                    $"{Math.Round(pagointeres, 2)} \t {Math.Round(monto, 2)} ");
            }  
        } 
    }
}

