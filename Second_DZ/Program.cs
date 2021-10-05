using System;

namespace Second_DZ
{
    class Program
    {
        static void Main(string[] args)
        {   
            PrintAllValues();

            while(true){
                try{
                Console.WriteLine("Введите x");
                String user_input = Console.ReadLine();
                if(user_input == ""){
                    break;
                }
                double x = double.Parse(user_input);
                WhatIsFunction(x);
                }
                catch(System.FormatException){
                    Console.WriteLine("Введён некорректный x");
                }
            }               
        }

        static double GetYfromFirstSegment(double x){
            double y = Math.Round((double)0.25 * x + (double)(0.5), 2);
            Console.WriteLine($"Значение функции при x = {x}: {y}");
            return y;
        }


        static double GetYFromSecondSegment(double x, double first_radius){
            double correct_radius = 2;
            double y = 0;
            if (correct_radius > first_radius){
                Console.WriteLine($"При R={first_radius}: Разрыв второго рода, функция неопределена");
                return x;
            };
            if (correct_radius <= first_radius){
                double tetta = (double)(-Math.Acos((x + 2) / 2));
                y = Math.Round((double)((2 * Math.Sin(tetta) + 2)), 2);
                Console.WriteLine($"Значение функции при x = {x}: {y}");                          
            };
            return y;
        }
        
        static double GetYFromThirdSegment(double x, double second_radius){
            double correct_radius = 2;
            double y = 0;
            if (correct_radius > second_radius){
                Console.WriteLine($"При R={second_radius}: Разрыв второго рода, функция неопределена");
                return x;
            };

            if (correct_radius <= second_radius){
                 y = Math.Round((double)(Math.Sqrt(second_radius * second_radius - x * x)), 2);
                if (y >= 0 && y <= 2){
                    Console.WriteLine($"Значение функции при x = {x}: {y}");
                    return y;
                };
            };
            return y;
        }

        static double GetYFromFourthSegment(double x){
            double y = Math.Round((double)(-x + 2), 2) ;
            Console.WriteLine($"Значение функции при x = {x}: {y}");
            return y;
        }
        
        static void WhatIsFunction(double x){
            if((double)-6.5 <= x && x < (double)-2){
                GetYfromFirstSegment(x);
            };
            if((double)-2 <= x && x <= (double)0){
                Console.WriteLine("Введите радиус окружности: ");
                double first_radius = double.Parse(Console.ReadLine());
                GetYFromSecondSegment(x, first_radius);
            };
            if((double)-0 < x && x <= (double)2){
                Console.WriteLine("Введите радиус окружности: ");
                double second_radius = double.Parse(Console.ReadLine());
                GetYFromThirdSegment(x, second_radius);
            };
            if((double)2 < x && x <= (double)3){
                GetYFromFourthSegment(x);
            };
            if (x > (double)3 || x < (double)-6.5){
                Console.WriteLine("x должен принадлежать отрезку [-6.5, 3]");
            }            
        }

        static void PrintAllValues(){
            for(double x = -6.5; x <= 3; x += (double)0.2){
            WhatIsFunction(x);         
        }
                
            }
        }
    }

