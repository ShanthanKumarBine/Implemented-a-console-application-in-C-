using System;

public class RegistrationSystem
{
    private void Add(ref Student student)
    {
        bool flag1;
        do
        {
            flag1 = true;
            Console.Write("Student type: B(bachelor), M(master)? ");
            string str = Console.ReadLine().Trim();
            if (str.Length < 1)
            {
                flag1 = false;
            }
            else
            {
                switch (str.ToUpper()[0])
                {
                    case 'B':
                        student = (Student)new Bachelor();
                        break;
                    case 'M':
                        student = (Student)new Master();
                        break;
                    default:
                        flag1 = false;
                        break;
                }
            }
        }
        while (!flag1);
        bool flag2;
        do
        {
            flag2 = true;
            try
            {
                Console.Write("First Name: ");
                student.FirstName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag2 = false;
            }
        }
        while (!flag2);
        bool flag3;
        do
        {
            flag3 = true;
            try
            {
                Console.Write("Last Name: ");
                student.LastName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag3 = false;
            }
        }
        while (!flag3);
        bool flag4;
        do
        {
            flag4 = true;
            try
            {
                Console.Write("Gender (M/F): ");
                student.Gender = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag4 = false;
            }
        }
        while (!flag4);
        bool flag5;
        do
        {
            flag5 = true;
            Console.Write("Residency (I/O): ");
            string str = Console.ReadLine().Trim();
            if (str.Length < 1)
            {
                flag5 = false;
            }
            else
            {
                switch (str.ToUpper()[0])
                {
                    case 'I':
                        student.IsResident = true;
                        break;
                    case 'O':
                        student.IsResident = false;
                        break;
                    default:
                        flag5 = false;
                        break;
                }
            }
        }
        while (!flag5);
        bool flag6;
        do
        {
            flag6 = true;
            try
            {
                Console.Write("Credits Taking: ");
                student.Credits = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag6 = false;
            }
        }
        while (!flag6);
        bool flag7;
        do
        {
            flag7 = true;
            try
            {
                Console.Write("Entrance Date: ");
                student.EntranceDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag7 = false;
            }
        }
        while (!flag7);
        bool flag8;
        do
        {
            flag8 = true;
            try
            {
                Console.Write("Home Phone: ");
                student.HomePhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag8 = false;
            }
        }
        while (!flag8);
        bool flag9;
        do
        {
            flag9 = true;
            try
            {
                Console.Write("Mobile Phone: ");
                student.MobilePhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag9 = false;
            }
        }
        while (!flag9);
        student.HomeAddress = new Address();
        bool flag10;
        do
        {
            flag10 = true;
            try
            {
                Console.Write("Street Address: ");
                student.HomeAddress.Street = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag10 = false;
            }
        }
        while (!flag10);
        bool flag11;
        do
        {
            flag11 = true;
            try
            {
                Console.Write("City: ");
                student.HomeAddress.City = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag11 = false;
            }
        }
        while (!flag11);
        bool flag12;
        do
        {
            flag12 = true;
            try
            {
                Console.Write("State: ");
                student.HomeAddress.State = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag12 = false;
            }
        }
        while (!flag12);
        bool flag13;
        do
        {
            flag13 = true;
            try
            {
                Console.Write("Zip: ");
                student.HomeAddress.Zip = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag13 = false;
            }
        }
        while (!flag13);
        if (student is Bachelor)
        {
            bool flag14;
            do
            {
                flag14 = true;
                Console.Write("Is this student in the scholar program (Y/N)?: ");
                string str = Console.ReadLine().Trim();
                if (str.Length < 1)
                {
                    flag14 = false;
                }
                else
                {
                    switch (str.ToUpper()[0])
                    {
                        case 'N':
                            ((Bachelor)student).Scholar = false;
                            break;
                        case 'Y':
                            ((Bachelor)student).Scholar = true;
                            break;
                        default:
                            flag14 = false;
                            break;
                    }
                }
            }
            while (!flag14);
        }
        else
        {
            if (!(student is Master))
                return;
            bool flag15;
            do
            {
                flag15 = true;
                try
                {
                    Console.Write("Advisor's First Name: ");
                    ((Master)student).AdvisorFirstName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    flag15 = false;
                }
            }
            while (!flag15);
            bool flag16;
            do
            {
                flag16 = true;
                try
                {
                    Console.Write("Advisor's Last Name: ");
                    ((Master)student).AdvisorLastName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    flag16 = false;
                }
            }
            while (!flag16);
        }
    }

    private void Menu()
    {
        bool flag1 = false;
        Student student = (Student)null;
        Console.WriteLine("Welcome to the Continental University Registration System!");
        do
        {
            Console.WriteLine("Enter data about a student");
            Console.WriteLine();
            this.Add(ref student);
            Console.WriteLine();
            Console.WriteLine(student.ToString());
            Console.WriteLine();
            Console.WriteLine();
            bool flag2;
            do
            {
                flag2 = true;
                Console.Write("Do you want to quit (Y/N)?: ");
                string str = Console.ReadLine().Trim();
                if (str.Length < 1)
                {
                    flag2 = false;
                }
                else
                {
                    Console.WriteLine();
                    switch (str.ToUpper()[0])
                    {
                        case 'N':
                            flag1 = false;
                            break;
                        case 'Y':
                            flag1 = true;
                            break;
                        default:
                            flag2 = false;
                            break;
                    }
                }
            }
            while (!flag2);
        }
        while (!flag1);
        Console.WriteLine();
        Console.WriteLine("Thank you for using the Registration System!");
        Console.WriteLine();
    }

    public static void Main(string[] args) => new RegistrationSystem().Menu();
}
