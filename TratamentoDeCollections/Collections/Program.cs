using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreach
{
    public class Nomes
    {
        public string Nome { get; set; }

        public Nomes(string nome)
        {
            this.Nome = nome;
        }

    }


    class Program
    {
        static List<Nomes> nomes;

        static void Main(string[] args)
        {
            Console.WriteLine("Digite o Nome desejado.");
            Console.ReadLine();

            nomes = new List<Nomes>();

            nomes.Add(new Nomes("José"));
            nomes.Add(new Nomes("João"));
            nomes.Add(new Nomes("Maria"));
            nomes.Add(new Nomes("Antonia"));


            foreach (Nomes nome in nomes)
            {
                Console.WriteLine(nome.Nome);
                Console.Read();

            }
        }
    }
}
