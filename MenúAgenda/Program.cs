using System.Globalization;
using System.Text.RegularExpressions;

int menu = 0;

while (menu > 6)
{
    Console.WriteLine("+-------------------------------------+");
    Console.WriteLine("| 1. Alta Usuari                      |");
    Console.WriteLine("| 2. Recuperar Usuari                 |");
    Console.WriteLine("| 3. Modificar Usuari                 |");
    Console.WriteLine("| 4. Eliminar Usuari                  |");
    Console.WriteLine("| 5. Mostrar Agenda                   |");
    Console.WriteLine("| 6. Ordenar Agenda                   |");
    Console.WriteLine("+-------------------------------------+");
    Console.WriteLine("| Q. Sortir                           |");
    Console.WriteLine("+-------------------------------------+");
    menu = Int32.Parse(Console.ReadLine());

    switch (menu)
    {
        case 1:
            Console.WriteLine("\n" + "Entra el teu nom: ");
            string nom = Console.ReadLine();
            Nom(nom);

            Console.WriteLine("\n" + "Entra el teu primer cognom: ");
            string cognom = Console.ReadLine();
            Cognom(cognom);

            Console.WriteLine("\n" + "Entra el teu DNI: ");
            string dni = Console.ReadLine();
            DNI(dni);

            Console.WriteLine("\n" + "Entra el teu numero de telefon: ");
            string telefon = Console.ReadLine();
            Telefon(telefon);

            Console.WriteLine("\n" + "Entra la teva data de naixement (DD/MM/AAAA): ");
            string data = Console.ReadLine();
            DMA(data);

            Console.WriteLine("\n" + "Entra el teu correu electronic: ");
            string mail = Console.ReadLine();
            GMAIL(mail);

            TornarMenu();
            break;
        case 2:

            break;
        case 3:

            break;
        case 4:

            break;
        case 5:

            break;
        case 6:

            break;
    }
}
static int TornarMenu()
{
    for (int i = 5; i > 0; i--)
    {
        Console.Write("\r" + "Tornant al menú: " + i + "s");
        Thread.Sleep(1000);
    }
    Console.Clear();
    return 0;
}
static bool Nom(string Nom)
{
    bool correcte = true;
    for (int i = 0; i < Nom.Length; i++)
    {
        if (Nom[i] < 'a' || Nom[i] > 'Z')
        {
            correcte = false;
        }
    }
    return correcte;
}
static bool Cognom(string Cognom)
{
    bool correcte = true;
    for (int i = 0; i < Cognom.Length; i++)
    {
        if (Cognom[i] < 'a' || Cognom[i] > 'Z')
        {
            correcte = false;
        }
    }
    return correcte;
}
static bool DNI(string DNI)
{
    bool correcte = true;
    for (int i = 0; i <= 8; i++)
    {
        if (DNI[i] > 9 || DNI[i] < 0)
        {
            correcte = false;
        }
    }
    if (DNI[9] < 'a' || DNI[9] > 'Z')
    {
        correcte = false;
    }
    return correcte;
}
static bool Telefon(string telefon)
{
    bool correcte = true;
    for (int i = 0; i <= 9; i++)
    {
        if (telefon[i] > 9 || telefon[i] < 0)
        {
            correcte = false;
        }
    }
    if (telefon.Length != 9)
    {
        correcte = false;
    }
    return correcte;
}
static bool DMA(string data)
{
    bool correcte = false;
    if (DateTime.TryParseExact(data, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime fecha))
    {
        Console.WriteLine("Fecha ingresada: " + fecha.ToString("dd/MM/yyyy"));
        correcte = true;
    }
    return correcte;
}
static bool GMAIL(string correo)
{
    string patron = @"^[a-z0-9]{3,}@[a-z]{3,}$";
    Regex regex = new Regex(patron, RegexOptions.IgnoreCase);
    return regex.IsMatch(correo);
}