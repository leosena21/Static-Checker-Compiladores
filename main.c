//#include <stdio.h>
//#include <stdlib.h>
//#include <string.h>
//#include <ctype.h>

#include "analisadorlexico.c"


FILE *f;
int linha=1;
token tk;

int main (int argc, char **argv)
{
	//int aux;
	//char[] definicoes[9]={ID, PR, OS, intcon, realcon, caraccon, cadeiacon, booleano, INEXISTENTE};
	char NamePath[500];
	
	printf("Digite o nome ou caminho do arquivo: \n");
	scanf("%s", &NamePath);
	
    if(!(f = fopen(NamePath,"r")))
    {
        printf( "O arquivo nao pode ser aberto.\n" );
        system("pause");
        exit(0);
    }
    fseek(f,0,SEEK_SET);
       
    carregarTabelas();

	while (!feof(f)){
		tk = analex();
		switch(tk.cat){
			case 0:
				printf("%s - ","Identificador");
				printf("%s\n",tk.lexema);
				break;
			
			case 1:
				printf("%s - ","Palavra Reservada");
				printf("%d\n",tk.codigo);
				break;
				
			case 2:
				printf("%s\n","Operador e Sinal");
				break;
			
			case 3:
				printf("%s - ","Inteiro");
				printf("%d\n",tk.valorInteiro);
				break;
			
			case 4:
				printf("%s - ","Real");
				printf("%f\n",tk.valorFloat);
				break;
				
			case 5:
				printf("%s - ","Caracter");
				printf("%c\n",tk.caractere);
				break;
				
			case 6:
				printf("%s - ","Cadeia de Caracter");
				printf("%s\n",tk.lexema);
				break;
				
			case 7:
				printf("%s - ","Booleano");
				printf("%s\n",tk.valorInteiro);
				break;
			
			case 8:
				printf("%s\n","Inexistente");
				break;
		}
	}
    
    fclose(f);

    getchar();

    return 0;
}


