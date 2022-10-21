using System;
namespace micael3 {
    class ServicePlayer {
        public Boolean playerSelect(string s){
            if(s != "X" && s != "O"){
                Console.Clear();
                Console.WriteLine("Just type: X or O, run dotnet again just to learn");
                return false;
            }
            Console.Clear();
            return true;
        }
        public Boolean inserted_game(string p){
            char[] charArray = p.ToCharArray();
            if(!p.Contains(",")) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("The value entered is invalid, try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }else if (int.Parse(charArray[0].ToString()) > 3 | int.Parse(charArray[0].ToString()) < 1 | int.Parse(charArray[2].ToString()) > 3 | int.Parse(charArray[0].ToString()) < 1){
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are only 3 columns and 3 rows try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
        public string[] gameVerified(string query, string[,] gameLayout){
          string[] value = new string[]{"null","null"};
          string[] Error = new string[]{"false","The value has already been entered"};
          char[] charArray = query.ToCharArray();

          int line = int.Parse(charArray[2].ToString()) - 1;
          int collumn = int.Parse(charArray[0].ToString()) - 1;

          string valueVerified = gameLayout[collumn,line];
          if(valueVerified != "*"){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Error[1]);
            Console.ForegroundColor = ConsoleColor.White;
            return Error;
          }
          
          value[0] = collumn.ToString();
          value[1] = line.ToString();

          return value;
        }
    }
}