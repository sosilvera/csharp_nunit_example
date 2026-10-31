using Classes;

namespace Program{
    public class Program{
        public static void Main(string[] args){
            int[] lista = [1, 3, 2, 10, 5, 6, 4];

            Lista l = new Lista(lista);
            l.mostrar();        
            l.ordenar();
            Console.WriteLine("");
            l.mostrar();
            Console.WriteLine(l.getHead());
        }
    }
}