namespace Classes;
public class Lista{
    private int[] lista {get;}

    public Lista(int[] l){
        this.lista = l;
    }

    public int getHead(){
        return lista[1];
    }

    public int[] getTail(){
        int[] lista_r = new int[lista.Length-1];
        for(int i=1; i<lista.Length; i++){
            lista_r[i] = lista[i];
        }
        return lista_r;
    }

    public int getLast(){
        return lista[lista.Length-1];
    }

    public bool isVoid(){
        return lista.Length == 0;
    }

    public void ordenar(){
        // Bubble sort
        for (int i = 0; i < lista.Length; i++){
            for (int j = i; j < lista.Length; j++){
                if(lista[i] > lista[j]){
                    int a = lista[j];
                    lista[j] = lista[i];
                    lista[i] = a;
                }
            }
        }
    }
    public void mostrar(){
        for (int i = 0;i<lista.Length;i++){
            Console.WriteLine(lista[i]);
        }
    }
}