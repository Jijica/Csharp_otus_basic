namespace Otus_Eighth_Homework
{
    internal class InputHandler
    {
        public static void StartSolution()
        {
            do
            {
                string variantToChoose;
                bool isZeroPressed = false;
                var emploeesInstance = new EmploeesSorted();

                EmploeeAndSalaryHandling(emploeesInstance);
                emploeesInstance.Traverse();
                SalarySearching(emploeesInstance);
                do
                {
                    Console.Write("Enter 0 to start again. Enter 1 to find a salary: ");
                    variantToChoose = Console.ReadLine();
                    switch (variantToChoose)
                    {
                        case "0":
                            isZeroPressed = true;
                            //emploeesInstance = new();
                            emploeesInstance.Clear();
                            break;
                        case "1":
                            SalarySearching(emploeesInstance);
                            break;
                        default:
                            Console.WriteLine("Wrong input! Press 0 or 1");
                            break;
                    }
                } while (!isZeroPressed);
            }
            while (true);
        }

        private static void EmploeeAndSalaryHandling(EmploeesSorted emploeesInstance)
        {
            while (true)
            {
                string emploee, salary;
                bool salaryIsCorrect;
                int salaryParsed;

                Console.Write("Emploee: ");
                emploee = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(emploee))
                {
                    break;
                }
                do
                {
                    Console.Write("Integer salary:");
                    salary = Console.ReadLine();
                    salaryIsCorrect = Int32.TryParse(salary, out salaryParsed);
                } while (!salaryIsCorrect);

                emploeesInstance.AddEmploee(emploee, salaryParsed);
            }
        }

        private static void SalarySearching(EmploeesSorted emploeesInstance)
        {
            string salaryToFind, emploeeFound;
            bool salaryIsCorrect;
            int salaryParsed;

            do
            {
                Console.Write("Integer salary to find: ");
                salaryToFind = Console.ReadLine();
                salaryIsCorrect = Int32.TryParse(salaryToFind, out salaryParsed);
            } while (!salaryIsCorrect);

            emploeeFound = emploeesInstance.FindSalary(salaryParsed);
            if (emploeeFound != null)
            {
                Console.WriteLine($"Emploee - {emploeeFound}");
            }
            else
            {
                Console.WriteLine("Emploee not found");
            }
        }
    }
}
