using System;

class Program
{
  
    struct Persona
    {
        public string CodID;
        public string Nome;
        public string Cognome;
        public int Eta;
        public string Telefono;
        public string Email;
    }

    
    static Persona[] anagrafica = new Persona[2];
    static int countPersone = 0;
    static int progressivo = 1;

    static void Main(string[] args)
    {
        // MENU PRINCIPALE
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n--- Menu Principale ---");
            Console.WriteLine("1 - Esercizi numerici");
            Console.WriteLine("2 - Anagrafica");
            Console.WriteLine("0 - Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    MenuEsercizi();
                    break;
                case "2":
                    MenuAnagrafica();
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }
    }

    //FUNZIONI MENU ESERCIZI
    static void MenuEsercizi()
    {
        bool esecuzione = true;
        while (esecuzione)
        {
            Console.WriteLine("\n--- Menu Esercizi ---");
            Console.WriteLine("1 - Inserire n numeri e stamparli");
            Console.WriteLine("2 - Vettore inverso");
            Console.WriteLine("3 - Verifica ordine vettore");
            Console.WriteLine("4 - 100 numeri casuali e statistiche");
            Console.WriteLine("5 - 100 numeri casuali e contare pari tra 10 e 20");
            Console.WriteLine("6 - Convertire numero in ASCII/Unicode");
            Console.WriteLine("0 - Torna al menu principale");
            Console.Write("Scegli un esercizio: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1": Esercizio1(); break;
                case "2": Esercizio2(); break;
                case "3": Esercizio3(); break;
                case "4": Esercizio4(); break;
                case "5": Esercizio5(); break;
                case "6": Esercizio6(); break;
                case "0": esecuzione = false; break;
                default: Console.WriteLine("Scelta non valida!"); break;
            }
        }
    }

    static void Esercizio1()
    {
        Console.Write("Quanti numeri vuoi inserire? ");
        int n = int.Parse(Console.ReadLine());
        int[] vettore = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Numero {i + 1}: ");
            vettore[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Valori inseriti:");
        for (int i = 0; i < n; i++) Console.Write(vettore[i] + " ");
        Console.WriteLine();
    }

    static void Esercizio2()
    {
        Console.Write("Quanti numeri vuoi inserire? ");
        int n = int.Parse(Console.ReadLine());
        int[] vettore = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Numero {i + 1}: ");
            vettore[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Vettore inverso:");
        for (int i = n - 1; i >= 0; i--) Console.Write(vettore[i] + " ");
        Console.WriteLine();
    }

    static void Esercizio3()
    {
        Console.Write("Quanti numeri vuoi inserire? ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Numero {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }
        bool crescente = true, decrescente = true;
        for (int i = 1; i < n; i++)
        {
            if (arr[i] <= arr[i - 1]) crescente = false;
            if (arr[i] >= arr[i - 1]) decrescente = false;
        }
        if (crescente) Console.WriteLine("Strettamente crescente");
        else if (decrescente) Console.WriteLine("Strettamente decrescente");
        else Console.WriteLine("Né crescente né decrescente");
    }

    static void Esercizio4()
    {
        Random rnd = new Random();
        int[] numeri = new int[100];
        int somma = 0, min = 101, max = 0;
        for (int i = 0; i < 100; i++)
        {
            numeri[i] = rnd.Next(1, 101);
            somma += numeri[i];
            if (numeri[i] < min) min = numeri[i];
            if (numeri[i] > max) max = numeri[i];
        }
        Console.WriteLine($"Somma: {somma}, Media: {(double)somma / 100}, Min: {min}, Max: {max}");
    }

    static void Esercizio5()
    {
        Random rnd = new Random();
        int count = 0;
        for (int i = 0; i < 100; i++)
        {
            int n = rnd.Next(1, 101);
            if (n % 2 == 0 && n >= 10 && n <= 20) count++;
        }
        Console.WriteLine($"Elementi pari tra 10 e 20: {count}");
    }

    static void Esercizio6()
    {
        Console.Write("Inserisci un numero intero (0-127): ");
        int numero = int.Parse(Console.ReadLine());
        if (numero >= 0 && numero <= 127)
        {
            char c = (char)numero;
            Console.WriteLine("Il carattere corrispondente è: " + c);
        }
        else
        {
            Console.WriteLine("Numero non valido per un carattere ASCII!");
        }
    }

    //FUNZIONI MENU ANAGRAFICA
    static void MenuAnagrafica()
    {
        bool esecuzione = true;
        while (esecuzione)
        {
            Console.WriteLine("\n--- Menu Anagrafica ---");
            Console.WriteLine("1 - Inserimento");
            Console.WriteLine("2 - Aggiornamento");
            Console.WriteLine("3 - Eliminazione");
            Console.WriteLine("4 - Stampa");
            Console.WriteLine("5 - Ricerca");
            Console.WriteLine("0 - Torna al menu principale");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1": InserimentoPersona(); break;
                case "2": AggiornamentoPersona(); break;
                case "3": EliminazionePersona(); break;
                case "4": StampaPersone(); break;
                case "5": RicercaPersona(); break;
                case "0": esecuzione = false; break;
                default: Console.WriteLine("Scelta non valida!"); break;
            }
        }
    }

    //FUNZIONI ANAGRAFICA
    static void InserimentoPersona()
    {
        if (countPersone >= anagrafica.Length)
        {
            Persona[] nuovoArray = new Persona[anagrafica.Length * 2];
            for (int i = 0; i < anagrafica.Length; i++)
                nuovoArray[i] = anagrafica[i];
            anagrafica = nuovoArray;
        }

        Persona p = new Persona();
        p.CodID = progressivo.ToString();
        progressivo++;

        Console.Write("Nome: ");
        p.Nome = Console.ReadLine();
        Console.Write("Cognome: ");
        p.Cognome = Console.ReadLine();
        Console.Write("Età: ");
        p.Eta = int.Parse(Console.ReadLine());
        Console.Write("Telefono: ");
        p.Telefono = Console.ReadLine();
        Console.Write("Email: ");
        p.Email = Console.ReadLine();

        anagrafica[countPersone] = p;
        countPersone++;
        Console.WriteLine("Persona inserita!");
        StampaPersone();
    }

    static void AggiornamentoPersona()
    {
        StampaPersone();
        Console.Write("Numero persona da aggiornare: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= countPersone) { Console.WriteLine("Numero non valido!"); return; }

        Persona p = anagrafica[index];

        Console.Write("Nuovo Nome (vuoto per mantenere): ");
        string nome = Console.ReadLine(); if (!string.IsNullOrEmpty(nome)) p.Nome = nome;
        Console.Write("Nuovo Cognome (vuoto per mantenere): ");
        string cognome = Console.ReadLine(); if (!string.IsNullOrEmpty(cognome)) p.Cognome = cognome;
        Console.Write("Nuova Età (vuoto per mantenere): ");
        string etaStr = Console.ReadLine(); if (!string.IsNullOrEmpty(etaStr)) p.Eta = int.Parse(etaStr);
        Console.Write("Nuovo Telefono (vuoto per mantenere): ");
        string tel = Console.ReadLine(); if (!string.IsNullOrEmpty(tel)) p.Telefono = tel;
        Console.Write("Nuova Email (vuoto per mantenere): ");
        string email = Console.ReadLine(); if (!string.IsNullOrEmpty(email)) p.Email = email;

        anagrafica[index] = p;
        Console.WriteLine("Aggiornamento completato!");
        StampaPersone();
    }

    static void EliminazionePersona()
    {
        StampaPersone();
        Console.Write("Numero persona da eliminare: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= countPersone) { Console.WriteLine("Numero non valido!"); return; }

        for (int i = index; i < countPersone - 1; i++)
            anagrafica[i] = anagrafica[i + 1];
        countPersone--;
        Console.WriteLine("Persona eliminata!");
        StampaPersone();
    }

    static void StampaPersone()
    {
        if (countPersone == 0) { Console.WriteLine("Anagrafica vuota."); return; }

        Console.WriteLine("\n--- Anagrafica ---");
        for (int i = 0; i < countPersone; i++)
        {
            Persona p = anagrafica[i];
            Console.WriteLine($"{i + 1}) CodID: {p.CodID}, Nome: {p.Nome}, Cognome: {p.Cognome}, Età: {p.Eta}, Tel: {p.Telefono}, Email: {p.Email}");
        }
    }

    static void RicercaPersona()
    {
        Console.WriteLine("Cerca per: 1-Nome, 2-Cognome, 3-CodID");
        string scelta = Console.ReadLine();
        Console.Write("Valore da cercare: ");
        string valore = Console.ReadLine();
        bool trovato = false;

        for (int i = 0; i < countPersone; i++)
        {
            Persona p = anagrafica[i];
            if ((scelta == "1" && p.Nome.Equals(valore, StringComparison.OrdinalIgnoreCase)) ||
                (scelta == "2" && p.Cognome.Equals(valore, StringComparison.OrdinalIgnoreCase)) ||
                (scelta == "3" && p.CodID == valore))
            {
                Console.WriteLine($"{i + 1}) CodID: {p.CodID}, Nome: {p.Nome}, Cognome: {p.Cognome}, Età: {p.Eta}, Tel: {p.Telefono}, Email: {p.Email}");
                trovato = true;
            }
        }
        if (!trovato) Console.WriteLine("Nessun risultato trovato.");
    }
}
