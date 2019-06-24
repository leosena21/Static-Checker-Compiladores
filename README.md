# Static-Checker-Compiladores
Projeto de compiladores: um Static Checker sobre a linguagem Comp2019-1

AUTORES:

Bruna Andrade @brunandrade

Leonardo Sena @leosena21

Tarcio Carvalho @Tarcioc2

O projeto de implementação da discip![](https://ibb.co/WkTwpyD)lina Compiladores será a construção de um Static Checker (executando as tarefas de análise léxica e análise sintática) sobre a
linguagem Comp2019-1, construída pelo professor, baseada na especificação da linguagem de programação C. Observação: você não precisa entender a especificação
completa da linguagem C para a implementação do trabalho de compiladores, você deve entender a especificação da linguagem Comp2019-1 que será detalhada a seguir.

**A linguagem Comp2019-1 é definida inicialmente:**
  
   a) pela gramática formal especificada abaixo (escrita em PG) e composta de duas partes (regras sintáticas e padrões léxicos) e 
   
   b) pelas regras de funcionamento descritas neste documento de especificação.

A gramática formal de Comp2019-1 define: tanto a sintaxe da linguagem e dos comandos da linguagem (que deverão ser usados para a construção do analisador
sintático), como os padrões léxicos de formação dos átomos (que deverão ser usados para a construção do analisador léxico). As regras de funcionamento descritas neste
documento vão direcionar como construir o Static Checker, como devem funcionar as entradas e saídas, como armazenar as informações na tabela de símbolos entre outros.
Cada equipe formada desenvolverá o Static Checker, o qual depois de pronto estará apto a validar qualquer texto fonte escrito por usuários nesta linguagem (os textos
escritos pelos usuários da linguagem podem estar corretos ou não). A cada execução do programa Static Checker será fornecido um único texto fonte como parâmetro de
entrada. Daí em diante o Static Checker verifica o texto de entrada segundo as regras de validação e definição da linguagem Comp2019-1. Todas as equipes estarão
implementando programas para tratar a mesma linguagem de entrada.

# Entradas e saídas do Static Checker

O Static Checker a ser construído deve aceitar como entrada qualquer texto fonte escrito em ASCII que deverá ser analisado de acordo com as regras da linguagem
definidas nesta documentação. Este texto fonte deverá ter obrigatoriamente a extensão .191. Não deverá ser solicitada a extensão do texto fonte na chamada de execução
do Static Checker. Por exemplo: para que seja analisado o arquivo MeuTeste.191, deve ser passado como parâmetro apenas o nome MeuTeste e o programa Static Checker
deve procurar no disco a existência do texto fonte de nome MeuTeste.191 para começar os trabalhos. Caso seja fornecido apenas o nome do texto fonte, este deve ser
procurado no diretório corrente onde o Static Checker está sendo executado. Caso seja fornecido o caminho completo mais o nome do texto fonte como parâmetro de
entrada, o arquivo deve ser procurado neste caminho indicado na entrada.

Quando o static checker estiver completo, para cada texto fonte, que seja passado como parâmetro para o programa executável do projeto, deverão ser gerados
obrigatoriamente três arquivos de saída em separado na mesma pasta onde o texto fonte parâmetro se encontra: um arquivo com o relatório da análise léxica, outro com o
relatório da tabela de símbolos e um último com o relatório da análise sintática. Os arquivos gerados devem ter o mesmo nome base do texto fonte (modificando apenas a
extensão do arquivo). Por exemplo: caso o texto fonte a ser analisado seja o MeuTeste.191 devem ser gerados na saída os arquivos MeuTeste.LEX e MeuTeste.TAB
(respectivamente os relatórios da análise léxica e da tabela de símbolos correspondentes ao arquivo de entrada). Estes arquivos (juntamente com o conteúdo que cada um
destes relatórios devem conter) serão detalhados abaixo.

O relatório da análise léxica (contido no arquivo de extensão .LEX) deve mostrar a relação dos símbolos da linguagem que foram encontrados no texto fonte analisado,
na ordem em que estes aparecerem e tantas vezes quantas tenham aparecido. Este relatório deve indicar no cabeçalho: o número da equipe, os nomes, e-mails e telefones
de todos os componentes da equipe que participaram da elaboração desta etapa do projeto. Para cada linha detalhe do relatório de análise léxica, devem ser exibidas no
mínimo as informações: o elemento léxico formado (chamado de lexeme), o código do átomo correspondente a este elemento léxico e o índice deste símbolo na tabela de símbolos (quando for um símbolo que seja armazenado nesta estrutura de dados). Caso a equipe julgue interessante podem ser incluídas outras informações no relatório da
análise léxica.

# Analisador Léxico

No analisador léxico devem ser lidos todos os caracteres do texto fonte, um a um, e baseado nesta leitura devem ser montados os átomos que se encontram neste
texto fonte de acordo com os padrões de formação de cada um deles e com a situação que ocorre em cada texto fonte. Esta leitura poderá ser implementada usando a
técnica de bufferização de entrada com buffer de duas metades, embora não seja exigido. A relação dos átomos possíveis para a linguagem Comp2019-1 será fornecida logo
abaixo no item 10 desta especificação. Cada chamada ao analisador léxico tem por função formar apenas um átomo do texto fonte. A cada chamada, o analisador léxico é
informado da posição corrente no texto fonte e deve ser capaz de formar o próximo átomo que existe após esta posição retornando esta informação para o programa
chamador do analisador léxico.

A implementação do seu projeto não deve considerar diferenças entre letras maiúsculas e minúsculas. O texto fonte fornecido como parâmetros pode conter letras
maiúsculas e minúsculas, mas devem ser consideradas como se fossem todas maiúsculas. Os identificadores com diferença de caixa não serão considerados como símbolos
distintos (caixa alta ou caixa baixa é o mesmo que maiúsculo ou minúsculo).

O texto fonte pode ser formado de qualquer seqüência de caracteres. Alguns caracteres são caracteres válidos para a linguagem, outros caracteres são inválidos para a
linguagem. Os caracteres válidos são aqueles usados em alguma construção da linguagem (no padrão de formação de algum átomo da linguagem ou em construções
auxiliares como comentários e arrumação do texto). Os espaços em branco, os comentários, marcas de tabulação (ASCII 09), caractere de fim de linha (ASCII 10), o de quebra
de linha (ASCII 13), além de todos os caracteres usados na montagem de um átomo válido da linguagem são considerados caracteres válidos da linguagem. Os caracteres
inválidos devem ser filtrados no processo de formação dos átomos. Este filtro é chamado de filtro de primeiro nível e não deve significar erro na execução do analisador léxico. Neste caso os caracteres inválidos são simplesmente desconsiderados do texto fonte sem funcionar como um delimitador permitindo que a formação do átomo
continue.

Os espaços em branco existentes nos textos fontes normalmente funcionam como delimitadores na formação dos átomos para a maioria das linguagens. No caso da
linguagem Comp2019-1, eles se encaixam na regra geral, ou seja, todos os caracteres válidos que não fizerem parte do padrão de formação do átomo que estiver sendo
formado correntemente devem ser considerados como delimitadores para este processo de montagem de átomo. Nos casos onde o espaço em branco não faça parte do
padrão de formação do átomo sendo formado ele vai funcionar como um delimitador. Nos casos onde o espaço em branco faça parte do padrão léxico de formação do átomo
eles poderão ser considerados como parte do elemento léxico que está sendo formado. Os espaços em branco adicionais, repetidos, devem ser filtrados do texto fonte.

Os comentários em Comp2019-1 são fornecidos como recurso adicional da linguagem e não estão especificados na definição formal dada pela gramática. Os
comentários existentes nos textos fontes normalmente funcionam como delimitadores na formação dos átomos e neste caso deverão ser filtrados do texto para efeito das
etapas posteriores do static checker. Os comentários podem acontecer de duas formas nos textos fontes: devem ser iniciados com a cadeia “ /* “ (abre comentário) e
finalizados com a cadeia “ */ ” (fecha comentário). Neste caso, se não existir a segunda cadeia “ */ ” fechando o comentário, todo o restante do programa fonte até o final de
arquivo deverá ser considerado comentário. Os comentários podem ser iniciados também com a cadeia “ // “ (comentário de linha), devendo neste caso valer até o final da
linha corrente. Se não existir o final de linha fechando o comentário, todo o restante do programa fonte até o final de arquivo deverá ser considerado comentário.

Na leitura do primeiro caractere válido, logo após a chamada do analisador léxico, é seguido um dos padrões léxicos existentes para a linguagem. Este padrão vai ser
seguido até que se encontre algum caractere válido para a linguagem que não seja válido para o padrão de formação do átomo que está sendo montado. Ou seja, tudo o que
não puder fazer parte deste átomo será considerado como delimitador, usando o critério do máximo comprimento possível, ou seja, enquanto o caractere lido puder fazer
parte do átomo ele será considerado como parte do átomo que está sendo montado.
Para a linguagem Comp2019-1, os átomos possuem um limite máximo de 35 caracteres válidos de tamanho. Todas as seqüências de caracteres válidos para a
linguagem que respeitem a um determinado padrão de formação de átomo devem ser consideradas apenas até o limite máximo de 35 caracteres e após este limite devem
ser desconsiderados para o átomo que está sendo formado no momento. Por exemplo, um nome de variável que tenha 100 caracteres válidos de tamanho será reconhecido
pelo analisador léxico como sendo um átomo do tipo nome de variável com as 35 primeiras posições e o restante dos caracteres (os outros 65 caracteres) que poderiam fazer
parte deste átomo nome de variável pelo padrão léxico de formação deverão ser desconsiderados do texto fonte. Apenas os caracteres não filtrados são contados para o
limite de 35 caracteres de um átomo. A leitura deve continuar mesmo depois dos 35 primeiros caracteres até encontrar o ponto onde vai existir algum caractere delimitador
para aquele átomo.

No limite de 35 caracteres para a formação do átomo, o analisador léxico deve estar atento para formar apenas átomos válidos para o padrão definido para aquele
átomo. Algumas situações especiais devem ser tratadas como, por exemplo, forçar um final de cadeia na posição número 35, ou garantir que os números após truncar os
elementos após a posição 35 irão formar construções coerentes e válidas para o padrão que foi usado. Os abre e fecha aspas são considerados como caractere válido na
contabilização do tamanho do átomo. Para os comentários não valem as regras de tamanho máximo de um átomo, já que neste caso não se trata de átomo da linguagem.

A cada chamada da rotina do analisador léxico serão utilizadas três informações: 1) a posição corrente do texto fonte que deve ser analisada no momento, 2) o código
do átomo formado (parâmetro de retorno) e 3) o índice da tabela de símbolos onde o átomo foi gravado (apenas para os identificadores, também parâmetro de retorno). O
átomo formado pode ser verificado, após a sua montagem, com a tabela de palavras e símbolos reservados que irá conter todas as palavras definidas da linguagem e com a
tabela de símbolos, contendo todos os identificadores já reconhecidos. A análise léxica trabalhará sobre o arquivo texto com extensão .191 e irá gerar o relatório .LEX.

# Tabela de Simbolos

Apenas os átomos identificadores serão armazenados na tabela de símbolos. As palavras e símbolos reservados da linguagem Comp2019-1 deverão constar numa
tabela especial separada da tabela de símbolos, que será chamada de tabela de palavras e símbolos reservados e que deverá estar previamente carregada antes do início da
primeira análise. A tabela de palavras e símbolos reservados será fixa para todos os programas analisados. A tabela de símbolos irá variar a depender dos átomos existentes
no texto fonte que estiver sendo analisado. A tabela de símbolos do projeto irá conter os seguintes atributos: número da entrada da tabela de símbolos, código do átomo,
lexeme, quantidade de caracteres antes da truncagem, quantidade de caracteres depois da truncagem, tipo do símbolo e as cinco primeiras linhas onde o símbolo aparece.

Os números das entradas indicarão os índices de armazenamento daqueles símbolos na tabela e são usados em todo o processo de análise do texto fonte. Cada
símbolo (lexeme com o mesmo significado) na tabela de símbolos deverá ter um endereço único, ou seja, não existirão duas entradas na tabela de símbolos para o mesmo
símbolo. Esta informação não deve ser modificada durante o processo de análise.

Os códigos dos átomos, correspondentes aos tipos dos símbolos encontrados no texto fonte, seguirão a relação de códigos de átomos fornecida na especificação da
linguagem e constante no item 10 desta documentação (apenas para os átomos identificadores, que são os símbolos guardados na tabela de símbolos). Esta informação não
deve ser modificada durante a análise.

Os lexemes devem ser guardados com apenas os 35 primeiros caracteres válidos da linguagem que aparecem no texto fonte. Esta informação não deve ser modificada
durante a análise.

Os tipos dos símbolos deverão ser preenchidos apenas para os identificadores em que fizer sentido (Identifier, Function, Integer-Number, Float-Number, Constant-
String, Character). Os tipos podem um dos seguintes: FL,(ponto flutuante) IN (inteiro), ST (string), CH (character), BO (booleano), VO (void), AF,(array de ponto flutuante) AI
(array de inteiro), AS (array de string), AC (array de character), AB (array de booleano),. Esta informação não deve ser modificada durante a análise.

As quantidades de caracteres do lexeme levando em conta apenas os 35 primeiros caracteres válidos irão armazenar para cada símbolo a quantidade de caracteres
válidos antes do processo de truncagem acontecer. Não devem ser levados em consideração os caracteres filtrados na montagem do átomo (caracteres inválidos da
linguagem). Para as cadeias considerar as aspas simples ou duplas como parte do tamanho do átomo. Esta informação pode ser modificada durante a análise. As quantidades
de caracteres do lexeme sem levar em conta apenas os 35 primeiros caracteres válidos irão armazenar para cada símbolo a quantidade de caracteres independente do
processo de truncagem que tenha acontecido. Não devem ser levados em consideração os caracteres filtrados na montagem do átomo (caracteres inválidos da linguagem).
Para as cadeias considerar as aspas simples ou duplas como parte do tamanho do átomo. Esta informação pode ser modificada durante a análise.

Os números das linhas onde o símbolo aparece pelas primeiras cinco vezes serão guardados com base no controle de linhas a ser efetuado sobre o texto fonte. Para
este controle de linhas não devem ser descartadas as linhas de comentários existentes no texto. Deve ser considerada a linha onde o símbolo começa para os casos em que
um símbolo possa ser definido em mais de uma linha. Esta informação pode ser modificada durante a análise.

![ ](https://i.ibb.co/QP5RjN8/Codigos.png)

# Definição da Gramática da Linguagem COMP2019-1 – Sintaxe dos comandos

Todos os símbolos marcados em azul no texto abaixo são símbolos do alfabeto da linguagem e não da notação BNF
Todos os não terminais marcados em vermelho são átomos da linguagem e do ponto de vista sintático devem ser considerados como
se fossem terminais.
**Gramática para a sintaxe dos comandos:**

![ ](https://i.ibb.co/LkRTryj/hfthhft.png) 
![ ](https://i.ibb.co/tYMs2pq/hfthhft.png) 



# Definição da Gramática da Linguagem COMP2019-1 – Padrões Léxicos de formação

![ ](https://i.ibb.co/rmKdnXp/hfthhft.png)


