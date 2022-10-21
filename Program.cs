using System;
namespace micael3
{
    class Program {
        static void Main(string[] args) {
            string[,] gameScreen = new string[3,3] { { "*", "*", "*" }, { "*", "*" , "*" }, { "*", "*" , "*" } };
            bool playerON = true;


            void setColor(System.ConsoleColor value){
                Console.ForegroundColor = value;
            }
            void printGame(string[,] game){
                for(int c = 0;c<3;c++){
                    Console.Write("-" + game[c,0] + "-");
                    for(int l = 1;l<3;l++){
                        Console.Write("-" + game[c,l] + "-");
                    }
                    Console.Write("\n");
                }
            }
        
        ServicePlayer servicePlayer = new ServicePlayer();
        
        Console.WriteLine("Say what your player will be: X or O");

        string player_selected = Console.ReadLine();
        
        bool player_verified = servicePlayer.playerSelect(player_selected);

        if(player_verified) {
            int acumulador = 0;
            if(player_selected == "X") playerON = true;
            if(player_selected == "O") playerON = false;
            do {    
                Console.WriteLine("Player: " + (playerON == true ? "X": "O"));
                printGame(gameScreen);

                Console.WriteLine("Enter A ROW and a COLUMN: example = 1,2");
                string lineColluns = Console.ReadLine();
                
                bool played_play = servicePlayer.inserted_game(lineColluns);
                if(played_play){
                    Console.Clear();
                    setColor(ConsoleColor.Green);
                    Console.WriteLine("-----OK------");
                    setColor(ConsoleColor.White);
                    
                    string[] valueVerified = servicePlayer.gameVerified(lineColluns,gameScreen);
                    if(valueVerified[0] == "false"){
                        Console.WriteLine("Play again: ");
                    }else {
                        gameScreen[int.Parse(valueVerified[0]),int.Parse(valueVerified[1])] = (playerON == true ? "X": "O");
                        playerON = !playerON;
                        acumulador = acumulador + 1;
                    }
                }
                if(acumulador == gameScreen.Length){
                    Console.Clear();
                    Console.WriteLine("Do you want to play again: yes or no?");
                    string msgPlayer = Console.ReadLine();
                    if(msgPlayer == "yes"){
                        string[,] resetGame = new string[3,3] { { "*", "*", "*" }, { "*", "*" , "*" }, { "*", "*" , "*" } };
                        gameScreen = resetGame;
                        acumulador = 0;
                    }else if( msgPlayer != "yes" && msgPlayer != "no"){
                        Console.Clear();
                        Console.WriteLine("I will take this as no");
                        break;
                    }else {
                        break;
                    }
                }
            }while (acumulador <= gameScreen.Length);
        }

        }

        void printGame(string[,] game){
            var datetime = DateTime.Now.ToString("hh:mm:ss tt");
            for(int c = 0;c<3;c++){
                Console.Write("-" + game[c,0] + "-");
                for(int l = 1;l<3;l++){
                    Console.Write("-" + game[c,l] + "-");
                }
                Console.Write("\n");
            }
            Console.WriteLine(datetime);
        }
    }
}