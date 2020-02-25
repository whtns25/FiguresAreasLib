﻿using System;

namespace FiguresAreasLib
{
    public class FiguresAreas
    {


        public double CirclesArea(double R) //круг
        {
            double S;
            S = Math.Pow(R, 2) * Math.PI;
            return Math.Round(S, 3);
        }


        public double CirclesArea(double R, double r) //эллипс
        {
            double S;
            S = Math.Abs(r) * Math.Abs(R) * Math.PI;
            return Math.Round(S, 3);
        }



        public double TrianglesArea(double a, double b, double c) //треугольник
        {
            double S;
            double p = (Math.Abs(a) + Math.Abs(b) + Math.Abs(c)) / 2;                       //полупериметр
            S = Math.Sqrt(p * (p - Math.Abs(a)) * (p - Math.Abs(b)) * (p - Math.Abs(c)));   //т-ма Герона
            return Math.Round(S, 3);
        }                                                                                   //тут беру стороны по модулю, если будут заданы отрицательные значения




        public bool TrianglesCheck(double a, double b, double c) //прямоугольный треугольник или нет, a b c - стороны треугольника
        {                                                        //если тр. прямоугольный - его большая сторона - гипотенуза
            double gip = 0, k1 = 0, k2 = 0, num1, num2;  //гипотенуза, два катета, два числа для сравнения по теореме пифагора

            if (a > b)
            {
                if (a > c) { gip = a; k1 = b; k2 = c; }  //если a больше b и с, a - гипотенуза

            }
            else if (b > c)
            {
                gip = b; k1 = a; k2 = c;             // b больше a, и если b больше с, b - гипотенуза
            }
            else
            {
                gip = c; k1 = a; k2 = b;                 // ни а, ни b не больше с, c - гипотенуза
            }

            num1 = Math.Pow(gip, 2); num2 = Math.Pow(k1, 2) + Math.Pow(k2, 2); //сравниваем полученные числа по т-ме Пифагора

            bool p; // если true - прямоугольный

            if (num1 == num2)
            {
                p = true;
                Console.WriteLine("Rectangular triangle");
                return p;
            }
            else
            {
                p = false;
                Console.WriteLine("Not rectangular triangle");
                return p;
            }
        }


        //  Расчет площади фигуры неизвестного типа, а именно - выпуклый многоугольник любого порядка

        // 1. входной параметр - массив, представляющий собой 'x' и 'y' координаты каждой точки поочередно ( {x1, y1, x2, y2.. yn}
        // 2. От каждой точки к последующей строится вектор и находится его модуль (длина грани)
        // 3. Далее находится точка, лежащая внутри области фигуры
        // 4. К этой точке строим вектора от вершин многоугольника, также находим их модули
        // 5. Многоугольник разбивается таким образом на треугольники, их площади находятся и суммируются
        // --Подходит для всех выпуклых многоугольников любого порядка

        public double CustomFiguresArea(int[] coords)   //важно, чтобы это был именно выпуклый многоугольник, для невыпуклого принцип не сработает                        
        {

            int xy = coords.Length;                      //суммарное число координат                        

            int k = xy / 2;                              //количество граней фигуры
            int j = 0;                                   //счетчик

            double[] vectors = new double[k];            //массив, содержащий длины граней

            for (int i = 0; i < xy - 2;)                 //из каждой точки строим вектор в последующую
            {                                            //вычисляем длины граней, т.е. модули векторов по началу и концу, исходя из координат
                vectors[j] = Math.Sqrt(Math.Pow(coords[i + 2] - coords[i], 2) + Math.Pow(coords[i + 3] - coords[i + 1], 2));
                i = i + 2;
                j++;
            }                                        // тут получились все вектора, кроме вектора из конечной заданной точки в самую первую 

            vectors[j] = Math.Sqrt(Math.Pow(coords[0] - coords[xy - 2], 2) + Math.Pow(coords[1] - coords[xy - 1], 2)); // вектор от конечной точки до начальной



            int a = 0, b = 0;                        // теперь нужно найти координаты точки, лежащей внутри многоугольника, назовем ее центральной(условно), a b - ее координаты

            for (int i = 0; i < xy - 1;)             //проверяем условия для всех точек, кроме первой и последней(нет нужды)
            {
                if (coords[i + 2] > coords[i] & coords[i + 2] < coords[i + 4]) // есть точки, которые не имеют общих 'х' - координат с другими(параллелограм, например)
                {

                    if (coords[i + 3] >= coords[i + 1] & coords[i + 3] >= coords[i + 5])
                    {
                        a = coords[i + 2];
                        b = coords[i + 3] - 1;       // точка, от которой строим центральную, лежит выше соседних по оси у
                        break;
                    }
                    else
                    {
                        a = coords[i + 2];
                        b = coords[i + 3] + 1;       // точка, от которой строим центральную, лежит ниже соседних по оси у
                        break;
                    }
                }

                else if (coords[i + 2] >= coords[i] & coords[i + 2] <= coords[i + 4])  // у всех точек так или иначе совпадает 'х' - координата с другой любой
                {                                                                      //квадрат, например

                    if (coords[i + 3] >= coords[i + 1] & coords[i + 3] >= coords[i + 5])
                    {
                        a = coords[i + 2] + 1;
                        b = coords[i + 3] - 1;
                        break;
                    }
                    else                                         //ПОЯСНЕНИЕ: Берём точку, если она находится по оси абсцисс между другими двумя точками                                   
                    {                                            // то координата 'х' центральной точки будет совпадать с 'х' рассматриваемой точки. 
                        a = coords[i + 2] + 1;                   // Тогда просто задаем смещение по 'у' координате, в положительном направлении,
                        b = coords[i + 3] + 1;                   // если рассматриваемая точка ниже соседних(по ординате), в отрицательном, если наоборот.
                        break;                                   // Ну и для случая, если координты 'х' у точек могут совпасть (которые сравниваем), 
                    }                                            // даем смещение и по иксу, аналогично.

                }

            }
            // есть модули векторов, есть центральная точка, нужно построить вектора к ней от других точек и расчитать площадь фигуры

            double[] vectorsCentr = new double[k];       // векторов к центральной точке будет столько же, сколько и точек фигуры
            int h = 0;                                   //счетчик

            for (int i = 0; i < xy;)                     //расчет модулей "центральных" векторов
            {
                vectorsCentr[h] = Math.Sqrt(Math.Pow(a - coords[i], 2) + Math.Pow(b - coords[i + 1], 2));
                i = i + 2;
                h++;
            }

            // теперь вся фигура условно разбита на треугольники с вершинами в центральной точке, найдем площадь этой фигуры

            double S = 0; //площадь
            int q = 0;    //счетчик
            double p;     //полупериметр

            for (int i = 0; i < xy / 2 - 1; i++)
            {
                p = (vectors[i] + vectorsCentr[q] + vectorsCentr[q + 1]) / 2;
                S = Math.Sqrt(p * (p - vectors[i]) * (p - vectorsCentr[q]) * (p - vectorsCentr[q + 1])) + S; //т-ма Герона

                q++;
            }

            p = (vectors[xy / 2 - 1] + vectorsCentr[0] + vectorsCentr[xy / 2 - 1]) / 2;  //тут для последней грани фигуры и для: 1.первый центральный вектор, 2. последний центральный вектор
            S = Math.Sqrt(p * (p - vectors[xy / 2 - 1]) * (p - vectorsCentr[0]) * (p - vectorsCentr[xy / 2 - 1])) + S;

            return Math.Round(S, 3); // конец

            //если фигура будет очень маленькая, например, квадрат 1 на 1, метод не срабоатет, тк координаты точек заданы в int
            // А тк минимальное возможное смещение центральной точки - 1 единица, она попадёт на границу фигуры
        }

    }
}