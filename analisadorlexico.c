#include "analisadorlexico.h"

extern FILE *f;
extern int linha;

token analex(){
    token tk;
    int i=0;
    int j=0;
    int estado=0;
    char caracter;
    char string_auxiliar[1001];
    caracter=getc(f);
    while(1){
    switch(estado){
    case 0:
                if (caracter==' '|| caracter=='\n'|| caracter=='\t'){
                    estado = 0;
                    if (caracter=='\n')
                        linha++;
                    caracter= fgetc(f);
                }else if (isalpha(caracter)){
                    estado = 1 ;
                }else if(isdigit(caracter)){
                    estado = 2;
                }else if(caracter=='('){
                    estado= 3;
                }else if(caracter==')'){
                    estado= 4;
                }else if(caracter=='+'){
                    estado = 5;
                }else if(caracter=='-'){
                    estado = 6;
                }else if(caracter=='/'){
                    estado = 7;
                }else if(caracter== '*'){
                    estado = 8;
                }else if(caracter=='<'){
                    estado= 9;
                }else if(caracter=='>'){
                    estado= 10;
                }else if(caracter=='='){
                    estado= 11;
                }else if(caracter=='#'){
                    estado= 12;
                }else if(caracter=='.'){
                    estado= 13;
                }else if(caracter==';'){
                    estado= 14;
                }else if(caracter==','){
                    estado= 15;
                }else if(caracter=='\"'){
                    estado= 16;
                }else if(caracter=='\''){ // apóstrofo
                    estado= 17;
                }else{
                    if(caracter != EOF){
                        printf("Caracter/comando invalido. Linha: %d\n", linha);
                        tk.cat = INEXISTENTE;
                        return tk;
                    }else{
                        tk.cat = INEXISTENTE;
                        return tk;
                    }
                }
                break;
    case 1:
            if(isalnum(caracter)){
                    string_auxiliar[i]=caracter;
                    i++;
                    caracter=getc(f);
                }else{
                    string_auxiliar[i]='\0';
                    ungetc(caracter,f);
                    estado=24;
                }
    break;
    case 2:
            if (isdigit(caracter)){
                string_auxiliar[i] = caracter;
                i++;
                }
            else if(caracter=='.'){
                string_auxiliar[i] = caracter;
                i++;
                estado=26;
            }else{
                ungetc(caracter,f);
                estado=25;
                }
            caracter= getc(f);
                break;
    break;
    case 3:
            tk.cat = OS;
            tk.codigo = ABRE_PARENTESE;
            return tk;
    case 4:
            tk.cat = OS;
            tk.codigo = FECHA_PARENTESE;
            return tk;
    case 5:
            tk.cat = OS;
            tk.codigo = MAIS;
            return tk;
    case 6:
            tk.cat = OS;
            tk.codigo = MENOS;
            return tk;
    case 7:
            caracter=fgetc(f);
            if (caracter == '/')
                estado=18;
            else{
                ungetc(caracter,f);
                tk.cat = OS;
                tk.codigo = DIVISAO;
                return tk;
            }
            break;
    case 8:
            tk.cat = OS;
            tk.codigo = MULTIPLICACAO;
            return tk;
    case 9:
            caracter=fgetc(f);
            if (caracter == '=')
                estado=19;
            else{
                ungetc(caracter,f);
                tk.cat = OS;
                tk.codigo = MENOR;
                return tk;
            }
            break;

    case 10:
            caracter=fgetc(f);
            if (caracter == '=')
                estado=20;
            else{
                ungetc(caracter,f);
                tk.cat = OS;
                tk.codigo = MAIOR;
                return tk;
            }
            break;
    case 11:
            caracter=fgetc(f);
            if (caracter == '=')
                estado=21;
            else{
                ungetc(caracter,f);
                tk.cat = OS;
                tk.codigo = ATRIBUICAO;
                return tk;
            }
            break;
    case 12:
            tk.cat = OS;
            tk.codigo = DIFERENTE;
            return tk;
    case 13:
            string_auxiliar[i]=caracter;
            i++;
            caracter=fgetc(f);
            if(isalpha(caracter)) estado=29;
            else{
                ungetc(caracter,f);
                printf("Erro na linha %d, voce pode estar querendo formar um operador logico ou um float.\n", linha);
                tk.cat = INEXISTENTE;
                return tk;
            }
    break;
    case 14:
            tk.cat = OS;
            tk.codigo = PONTO_E_VIRGULA;
            return tk;
    case 15:
            tk.cat = OS;
            tk.codigo = VIRGULA;
            return tk;
    case 16:
            caracter= getc(f);
                if (isprint(caracter) && caracter!='\\' && caracter!='\"'){
                    string_auxiliar[i++]=caracter;
                }else if (caracter=='\n'){
                    linha++;
                }else if(caracter=='\\') {
                    caracter=fgetc(f);
                        if (caracter == '\"'){
                            string_auxiliar[i++]='\"';
                        }
                        else{
                            ungetc(caracter,f);
                            string_auxiliar[i++]='\\';
                        }
                }else if(caracter=='\"'){
                        string_auxiliar[i++]='\0';
                        estado=22;
                }else{
                    ungetc(caracter,f);
                    printf("Caracter nao imprimivel encontrado na linha %d\n",linha);
                    tk.cat = INEXISTENTE;
                    return tk;
                }
                break;
    case 17:
                caracter=getc(f);
                if(isprint(caracter) && caracter!='\\'){
                    string_auxiliar[i]=caracter;
                    caracter=getc(f);
                        if(caracter=='\'')
                            estado=23;
                        else{
                            printf("Conteudo passado excede o tamanho do char. Linha: %d.\n", linha);
                            tk.cat = INEXISTENTE;
                            return tk;
                        }
                }else if(caracter=='\\'){
                    caracter=fgetc(f);
                    if (caracter=='\''){
                        if ((caracter=fgetc(f))!='\''){
                            ungetc(caracter,f);
                            string_auxiliar[i]='\\';
                            estado=23;
                        }
                        else{
                            string_auxiliar[i]='\'';
                            estado=23;
                        }
                    }
                }
                else{
                    printf("Erro na linha %d caracter nao imprimivel.\n", linha);
                    tk.cat = INEXISTENTE;
                    return tk;
                }
                break;
    break;
    case 18:
            if(caracter =='\n'){ // poderia ser while(caracter !='\n') caracter=fgetc(f); estado=0; break;
                caracter=fgetc(f);
                linha++;
                estado=0;
            }
            else
            caracter=fgetc(f);
            break;
    case 19:
                tk.cat = OS;
                tk.codigo = MENORIGUAL;
                return tk;
    case 20:
            tk.cat = OS;
            tk.codigo = MAIORIGUAL;
            return tk;
    case 21:
            tk.cat = OS;
            tk.codigo = IGUAL;
            return tk;
    case 22:
            strcpy(tabelaliterais.literais[tabelaliterais.posicaolivre],string_auxiliar);
            tk.posicao=tabelaliterais.posicaolivre;
            tk.cat=cadeiacon;
            tabelaliterais.posicaolivre++;
            return tk;
    case 23:
                    tk.cat = caraccon;
                    tk.caractere=string_auxiliar[i];
                    return tk;
    case 24:
            for(j=0;j<29;j++){
                    if(!strcmp(string_auxiliar,tabelaReservadas[j])){
                        tk.codigo=j;
                        tk.cat=PR;
                        return tk;
                    }
                }
                if(!strcmp(string_auxiliar, "CR")){
                    tk.caractere='\n';
                    tk.cat=caraccon;
                    return tk;}
                if(!strcmp(string_auxiliar, "NUL")){
                    tk.caractere=' ';
                    tk.cat=caraccon;
                    return tk;}
                strcpy(tk.lexema,string_auxiliar);
                tk.cat=ID;
                return tk;
    case 25:
            ungetc(caracter,f);
            string_auxiliar[i]='\0';
            tk.valorInteiro=atoi(string_auxiliar);
            tk.cat=intcon;
            fflush(stdin);
            return tk;
    case 26:
            if(isdigit(caracter))estado=27;
            else {
                     printf("Erro na linha %d, talvez voce queira formar um float.\n",linha);
                     ungetc(caracter,f);
                     tk.cat = INEXISTENTE;
                     return tk;
                }
            break;
    case 27:
            if(isdigit(caracter)){
                    string_auxiliar[i] = caracter;
                    i++;
                    caracter=getc(f);
                }else {
                    ungetc(caracter,f);
                    string_auxiliar[i] = '\0';
                    estado=28;
                }
                break;
    case 28:
            tk.valorFloat=atof(string_auxiliar);
            tk.cat= realcon;
            fflush(stdin);
            return tk;
    case 29:
            if(isalpha(caracter)){
                string_auxiliar[i]=caracter;
                i++;
                caracter=fgetc(f);
            }else if(caracter=='.'){
                string_auxiliar[i]=caracter;
                string_auxiliar[i+1]='\0';
                estado=30;
            }else{
            printf("Erro na linha %d, talvez voce queira declarar um operador\n", linha);
            tk.cat = INEXISTENTE;
            return tk;
            }
            break;
    case 30:
            for(j=0;j<29;j++){
                    if(!strcmp(string_auxiliar,tabelaReservadas[j])){
                        tk.codigo=j;
                        tk.cat=PR;
                        return tk;
                    }
            }
            printf("Erro na linha %d, talvez voce queira declarar um operador\n", linha);
            tk.cat = INEXISTENTE;
            return tk;
        }
    }
}
    void carregarTabelas(){
        tabelaliterais.posicaolivre = 0;

        strcpy (tabelaReservadas[0],"pl");
        strcpy (tabelaReservadas[1],"var");
        strcpy (tabelaReservadas[2],"endvar");
        strcpy (tabelaReservadas[3],"prog");
        strcpy (tabelaReservadas[4],"endprog");
        strcpy (tabelaReservadas[5],"noparam");
        strcpy (tabelaReservadas[6],"endfunc");
        strcpy (tabelaReservadas[7],"fwd");
        strcpy (tabelaReservadas[8],"proc");
        strcpy (tabelaReservadas[9],"endproc");
        strcpy (tabelaReservadas[10],"if");
        strcpy (tabelaReservadas[11],"else");
        strcpy (tabelaReservadas[12],"endif");
        strcpy (tabelaReservadas[13],"while");
        strcpy (tabelaReservadas[14],"endwhile");
        strcpy (tabelaReservadas[15],"for");
        strcpy (tabelaReservadas[16],"endfor");
        strcpy (tabelaReservadas[17],"return");
        strcpy (tabelaReservadas[18],"call");
        strcpy (tabelaReservadas[19],"keyboard");
        strcpy (tabelaReservadas[20],"display");
        strcpy (tabelaReservadas[21],"dup");
        strcpy (tabelaReservadas[22],".not.");
        strcpy (tabelaReservadas[23],".and.");
        strcpy (tabelaReservadas[24],".or.");
        strcpy (tabelaReservadas[25],"int");
        strcpy (tabelaReservadas[26],"real");
        strcpy (tabelaReservadas[27],"char");
        strcpy (tabelaReservadas[28],"bool");

        strcpy (tabelaOpeSinais[0],"+");
        strcpy (tabelaOpeSinais[1],"-");
        strcpy (tabelaOpeSinais[2],"*");
        strcpy (tabelaOpeSinais[3],"/");
        strcpy (tabelaOpeSinais[4],"<");
        strcpy (tabelaOpeSinais[5],"<=");
        strcpy (tabelaOpeSinais[6],">");
        strcpy (tabelaOpeSinais[7],">=");
        strcpy (tabelaOpeSinais[8],"==");
        strcpy (tabelaOpeSinais[9],"#");
        strcpy (tabelaOpeSinais[10],"=");
        strcpy (tabelaOpeSinais[11],",");
        strcpy (tabelaOpeSinais[12],";");
        strcpy (tabelaOpeSinais[13],"(");
        strcpy (tabelaOpeSinais[14],")");
    }
