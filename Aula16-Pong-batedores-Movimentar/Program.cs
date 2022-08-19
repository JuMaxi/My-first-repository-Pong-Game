using System;
using System.Threading;
namespace Aula16_Pong_batedores_Movimentar
{
    class Program
    {
        static int posicaoBatedor1 = 9;
        static int posicaoBatedor2 = 13;
        static int coluna = 55;
        static int linha = 12;
        static bool BallGoingUp = false;
        static bool BallGoingRight = false;
        static int Jogador1 = 0;
        static int Jogador2 = 0;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int key);

        static bool CheckarTecla(int codigoTecla)
        {
            return (0x8000 & GetAsyncKeyState(codigoTecla)) != 0;
        }

        static void DesenharQuadrado()
        {
            for (int colunaright = 0; colunaright <= 111; colunaright++)
            {
                Console.SetCursorPosition(colunaright, 0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═");
                Console.ResetColor();
            }
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╔");
            Console.ResetColor();

            for (int linhadown = 1; linhadown <= 25; linhadown++)
            {
                Console.SetCursorPosition(0, linhadown);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("║");
                Console.ResetColor();
            }

            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╚");
            Console.ResetColor();

            for (int colunaright2 = 1; colunaright2 <= 111; colunaright2++)
            {
                Console.SetCursorPosition(colunaright2, 26);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═");
                Console.ResetColor();
            }

            Console.SetCursorPosition(111, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╗");
            Console.ResetColor();

            for (int linhadown2 = 1; linhadown2 <= 25; linhadown2++)
            {
                Console.SetCursorPosition(111, linhadown2);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("║");
                Console.ResetColor();
            }

            Console.SetCursorPosition(111, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╝");
            Console.ResetColor();
        }

        static void DesenharBatedores()
        {
            // Desenhar Batedor 1
            for (int batedor1 = posicaoBatedor1; batedor1 <= posicaoBatedor1 + 2; batedor1++)
            {
                Console.SetCursorPosition(6, batedor1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("▐ ");
                Console.ResetColor();
            }
            // Fim desenhar Batedor 1

            // Desenhar Batedor 2
            for (int batedor2 = posicaoBatedor2; batedor2 <= posicaoBatedor2 + 2; batedor2++)
            {
                Console.SetCursorPosition(105, batedor2);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("▐ ");
                Console.ResetColor();
            }
            // Fim desenhar Batedor 2
        }

        static void MovimentarBatedores()
        {
            //Verificar se a Tecla Q foi pressionada (subir o batedor 1)
            bool teclaQpressionada = CheckarTecla(81);
            if (teclaQpressionada)
            {
                Console.SetCursorPosition(6, (posicaoBatedor1 + 2));
                Console.WriteLine(" ");

                posicaoBatedor1--;

                if (posicaoBatedor1 == 0)
                {
                    posicaoBatedor1 = 1;
                }
            }
            // Fim de Verificar se a TEcla Q foi pressionada (subir o batedor 1)

            // Verificar se a Tecla A foi pressionada (descer o batedor 1)
            bool teclaApressionada = CheckarTecla(65);
            if (teclaApressionada)
            {
                Console.SetCursorPosition(6, posicaoBatedor1);
                Console.WriteLine(" ");

                posicaoBatedor1++;

                if (posicaoBatedor1 == 24)
                {
                    posicaoBatedor1 = 23;
                }
            }
            // Fim de Verificar se a Tecla A foi pressionada (descer o batedor 1)



            // Verificar se a Tecla P foi pressionada (subir o batedor 2)
            bool teclaPpressionada = CheckarTecla(80);
            if (teclaPpressionada)
            {
                Console.SetCursorPosition(105, posicaoBatedor2 + 2);
                Console.WriteLine(" ");

                posicaoBatedor2--;

                if (posicaoBatedor2 == 0)
                {
                    posicaoBatedor2 = 1;
                }
            }
            // Fim de Verificar se a Tecla P foi pressionada (subir o batedor 2)

            // Verificar se a Tecla L foi pressionada (descer o batedor 2)
            bool teclaLpressionada = CheckarTecla(76);
            if (teclaLpressionada)
            {
                Console.SetCursorPosition(105, posicaoBatedor2);
                Console.WriteLine(" ");

                posicaoBatedor2++;

                if (posicaoBatedor2 == 24)
                {
                    posicaoBatedor2 = 23;
                }
            }
            // Fim de Verificar se a Tecla L foi pressionada (descer o batedor 2)
        }

        static void DesenharBolinha()
        {
            // Desenhar a Bolinha
            Console.SetCursorPosition(coluna, linha);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("♥");
            Console.ResetColor();
            // Fim de desenhar a Bolinha
        }

        static void LimparBolinha()
        {
            // Limpar a bolinha
            Console.SetCursorPosition(coluna, linha);
            Console.WriteLine(" ");
            // Fim de limopar a Bolinha
        }

        static void MovimentarBolinhaSentidoLinhas()
        {

            // Movimentar a bolinha no sentido das linhas
            if (BallGoingUp == false)
            {
                linha--;


                if (linha == 0)
                {
                   BallGoingUp = true;
                }
            }
            if (BallGoingUp == true)
            {
                linha++;

                if (linha == 25)
                {
                    BallGoingUp = false;
                }
            }
            // Fim de movimentar a bolinha no sentido das linhas
        }

        static void MovimentarBolinhasSentidoColunasEPlacarJogador()
        {
            // Movimentar a bolinha no sentido das colunas
            if (BallGoingRight == false)
            {
                coluna++;
                if (coluna == 111)
                {
                    BallGoingRight = true;
                    coluna = 55;
                    linha = 12;
                    Jogador1 = Jogador1 + 1;
                }
            }
            if (BallGoingRight == true)
            {
                coluna--;
                if (coluna == 1)
                {
                    BallGoingRight = false;
                    coluna = 55;
                    linha = 12;
                    Jogador2 = Jogador2 + 1;
                }
            }
            // Fim de movimentar a bolinha no sentido das colunas
        }

        static void EncostarBatedorERetornar()
        {
            // Fazer o batedor entender que a bolinha encostou nele e deve retornar
            if (coluna == 7)
            {
                int posicao1 = posicaoBatedor1;
                for (int batedor1 = posicao1; batedor1 <= posicao1 + 2; batedor1++)
                    if (batedor1 == linha)
                    {
                        BallGoingRight = false;
                    }
            }
            if (coluna == 104)
            {
                int posicao2 = posicaoBatedor2;
                for (int batedor2 = posicao2; batedor2 <= posicao2 + 2; batedor2++)
                {
                    if (batedor2 == linha)
                    {
                        BallGoingRight = true;
                    }
                }
            }
            // Fim de Fazer o batedor entender que a bolinha encostou nele e deve retornar
        }

        static void DesenharPlacar()
        {
            // Desenhar Placar
            Console.SetCursorPosition(52, 27);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PLACAR:");
            Console.ResetColor();

            Console.SetCursorPosition(25, 28);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("JOGADOR 1");
            Console.ResetColor();

            Console.SetCursorPosition(74, 28);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("JOGADOR 2");
            Console.ResetColor();
            // Fim de desenhar placar
        }

        static void MostrarPlacar()
        {
            // Indicar pontuação dos jogadores
            Console.SetCursorPosition(29, 29);
            Console.WriteLine(Jogador1);

            Console.SetCursorPosition(79, 29);
            Console.WriteLine(Jogador2);
            // Fim de indicar a pontuação dos jogadores
        }

        static void Main(string[] args)
        {
            DesenharQuadrado();
            
            while (true)
            {
                DesenharBatedores();

                MovimentarBatedores();

                DesenharBolinha();

                // Tempo movimento bolinha 
                Thread.Sleep(150);
                // Fim de tempo movimento bolinha

                LimparBolinha();

                MovimentarBolinhaSentidoLinhas();

                MovimentarBolinhasSentidoColunasEPlacarJogador();

                EncostarBatedorERetornar();

                DesenharPlacar();

                MostrarPlacar();
            }
        }
    }
    
}

