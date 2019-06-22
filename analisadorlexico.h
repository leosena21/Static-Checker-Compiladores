#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

typedef enum {
	ID, PR, OS, intcon, realcon, caraccon, cadeiacon, booleano, INEXISTENTE
} categorias;

typedef struct {
  categorias cat;
  union{
    char caractere;
    char lexema[31];
    int codigo;
    int posicao;
    int valorInteiro;
    float valorFloat;
  };
}token;

struct{
	char literais[501][1001];
	int posicaolivre;
}tabelaliterais;

enum palavrasreservadas {
	PL , VAR, ENDVAR, PROG, ENDPROG, NOPARAM, ENDFUNC, FWD, PROC, ENDPROC, IF, ELSE, ENDIF, WHILE, ENDWHILE, FOR,ENDFOR, RETURN, CALL, KEYBOARD, DISPLAY, DUP, NOT, AND, OR, INT, REAL, CHAR, BOOLEANO
};

char tabelaReservadas[29][10];

enum operadores_e_sinais {MAIS, MENOS, MULTIPLICACAO, DIVISAO, MENOR, MENORIGUAL, MAIOR, MAIORIGUAL, IGUAL, DIFERENTE, ATRIBUICAO,
VIRGULA, PONTO_E_VIRGULA, ABRE_PARENTESE, FECHA_PARENTESE};
char tabelaOpeSinais[15][3];

token analex();
void carregarTabelas();

