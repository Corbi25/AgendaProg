﻿using System;
using System.Globalization; //DateTime
using System.Text.RegularExpressions; //RegEx
using System.IO; //Ficher

int menu = 0;

while (menu != 7)
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
            string nom;
            do
            {
                Console.WriteLine("\n" + "Entra el teu nom: ");
                nom = Console.ReadLine();
            } while (!Nom(nom));

            string cognom;
            do
            {
                Console.WriteLine("\n" + "Entra el teu primer cognom: ");
                cognom = Console.ReadLine();
            } while (!Cognom(cognom));

            string dni;
            do
            {
                Console.WriteLine("\n" + "Entra el teu DNI: ");
                dni = Console.ReadLine();
            } while (!DNI(dni));

            string telefon;
            do
            {
                Console.WriteLine("\n" + "Entra el teu numero de telefon: ");
                telefon = Console.ReadLine();
            } while (!Telefon(telefon));

            string data;
            do
            {
                Console.WriteLine("\n" + "Entra la teva data de naixement (DD/MM/AAAA): ");
                data = Console.ReadLine();
            } while (!DMA(data));

            string mail;
            do
            {
                Console.WriteLine("\n" + "Entra el teu correu electronic: ");
                mail = Console.ReadLine();
            } while (!GMAIL(mail));

            TornarMenu();

            Console.WriteLine("La Informació es aquesta: ");
            Console.WriteLine("\n");
            Console.WriteLine("El nom: " + nom);
            Console.WriteLine("\n");
            Console.WriteLine("El cognom: " + cognom);
            Console.WriteLine("\n");
            Console.WriteLine("El DNI: " + dni);
            Console.WriteLine("\n");
            Console.WriteLine("El Telefon: " + telefon);
            Console.WriteLine("\n");
            Console.WriteLine("Data de naixement: " + data + " (Actual edat de : )");
            Console.WriteLine("\n");
            Console.WriteLine("El correu electronic: " + mail);
            string escriure = nom + ";" + cognom + ";" + dni + ";" + telefon + ";" + data + ";" + mail;
            GuardarAgenda(escriure);
            TornarMenu();
            break;
        case 2:
            string buscar;
            do
            {
                Console.WriteLine("Anem a buscar algun contacte: ");
                buscar = Console.ReadLine();
            } while (!Buscar(buscar));
            TornarMenu();
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
        if (!(Nom[i] >= 'a' && Nom[i] <= 'z') && !(Nom[i] >= 'A' && Nom[i] <= 'Z'))
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
        if (!(Cognom[i] >= 'a' && Cognom[i] <= 'z') && !(Cognom[i] >= 'A' && Cognom[i] <= 'Z'))
        {
            correcte = false;
        }
    }
    return correcte;
}
static bool DNI(string DNI)
{
    string patron = @"^\d{8}[A-Z]$";
    return Regex.IsMatch(DNI, patron);
}
static bool Telefon(string telefon)
{
    bool correcte = true;
    for (int i = 0; i < telefon.Length; i++)
    {
        if (telefon[i] < '0' || telefon[i] > '9')
        {
            correcte = false;
            break;
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
static void GuardarAgenda(string escriure)
{
    StreamWriter Agenda = new StreamWriter("Agenda",true);
    Agenda.WriteLine(escriure);
    Agenda.Close();
}
static bool Buscar(string buscar)
{
    StreamReader Agenda = new StreamReader("Agenda");
    bool trobat = false;

    while (!Agenda.EndOfStream && !trobat)
    {
        string AgendaString = Agenda.ReadLine();
        string[] parts = AgendaString.Split(';');

        if (parts[0] == buscar)
        {
            trobat = true;
            Console.Clear();
            Console.WriteLine("Tenim un contacte!");
            Console.WriteLine("\r");
            Console.WriteLine("La Informació es aquesta: ");
            Console.WriteLine("\n");
            Console.WriteLine("El nom: " + parts[0]);
            Console.WriteLine("\n");
            Console.WriteLine("El cognom: " + parts[1]);
            Console.WriteLine("\n");
            Console.WriteLine("El DNI: " + parts[2]);
            Console.WriteLine("\n");
            Console.WriteLine("El Telefon: " + parts[3]);
            Console.WriteLine("\n");
            Console.WriteLine("Data de naixement: " + parts[4] + " (Actual edat de : )");
            Console.WriteLine("\n");
            Console.WriteLine("El correu electronic: " + parts[5]);
        }
    }
    if (trobat == false)
    {
        Console.WriteLine("L'usuari no existeix, vols tornar a buscar? (s/n)");
        string tornar = Console.ReadLine();
        if (tornar == "s")
        {
            Console.WriteLine("Entra el nou usuari a buscar: ");
            buscar = Console.ReadLine();
            Buscar(buscar);
        }
        else
        {
            trobat = true;
        }
    }
    Agenda.Close();
    return trobat;
}