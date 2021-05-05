using System;
using System.Globalization;

namespace MatrixClasses
{
    public class Matrica <T>
    {
        T[,] matrix;
        public int n;
        public int m;

        public void Create(int n, int m)
        {
            if ((n <= 0) || (m <= 0)){
                Exception exc = new ArgumentException("Ошибка размерности матрицы");
                throw exc;
            }
            if ((typeof(T) != typeof(int)) && (typeof(T) != typeof(double)) && (typeof(T) != typeof(float)))
            {
                Exception exс = new ArgumentException("Некорректный тип данных");
                throw exс;
            }
            this.n = n;
            this.m = m;
            matrix = new T[n, m];
        }

        public T this[int index1, int index2]
        {
            get
            {
                return matrix[index1, index2];
            }

            set
            {
                matrix[index1, index2] = value;
            }
        }

        static T Add<U>(U x, U y)
        {
            dynamic dx = x, dy = y;
            return dx + dy;
        }
        public static Matrica<T> operator +(Matrica<T> arrA, Matrica<T> arrB)
        {
            int nA = arrA.n;
            int mA = arrA.m;
            int nB = arrB.n;
            int mB = arrB.m;
            if ((nA != nB) || (mA != mB))
            {
                Exception exс = new ArgumentException("Размерности матриц А и В различны");
                throw exс;
            }
            Matrica<T> arrC = new Matrica<T>();
            arrC.Create(nA, mA);
            for (int i = 0; i < nA; i++)
                for (int j = 0; j < mA; j++)
                    arrC[i, j] = Add<T>(arrA[i,j],arrB[i,j]);
            return arrC;
        }

        static T Mult<U>(U x, U y, U z)
        {
            dynamic dx = x, dy = y, dz = z;
            return dx * dy + dz;
        }

        public static Matrica<T> operator *(Matrica<T> arrA, Matrica<T> arrB)
        {
            int nA = arrA.n;
            int mA = arrA.m;
            int nB = arrB.n;
            int mB = arrB.m;
            if ((mA != nB))
            {
                Exception exс = new ArgumentException("Кол-во стоблцов матрицы А не совпадает с кол-вом строк матрицы В");
                throw exс;
            }
            Matrica<T> arrC = new Matrica<T>();
            arrC.Create(nA, mB);
            for (int i = 0; i < nA; i++)
                for (int j = 0; j < mB; j++)
                    for (int k = 0; k < mA; k++)
                        arrC[i, j] = Mult<T>(arrA[i, k], arrB[k, j], arrC[i, j]);
            return arrC;
        }
        public void Generation(Func<int, int, T> f)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = f(i, j);
        }
    }
}
