using System;
using System.Text;

public class CirculantMatrix
{
    private int[,] blocks;

    // Конструктор для инициализации блоков циркулянтной матрицы
    public CirculantMatrix(int[] coeffs)
    {
        int n = coeffs.Length;
        this.blocks = new int[n, n];

        // Инициализация блоков на основе коэффициентов циркулянтной матрицы
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Расчет значений блоков по коэффициентам циркулянтной матрицы
                this.blocks[i, j] = coeffs[(i - j + n) % n];
            }
        }
    }

    // Метод для генерации строкового представления блоков циркулянтной матрицы
    public string GetMatrixString()
    {
        int n = this.blocks.GetLength(0);
        StringBuilder matrixString = new StringBuilder();

        // Отображение блоков
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Добавление значений блоков в строку
                matrixString.Append(this.blocks[i, j] + " ");
            }
            // Добавление перевода строки для отделения строк матрицы
            matrixString.Append(Environment.NewLine);
        }

        return matrixString.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Определение коэффициентов циркулянтной матрицы для матриц разных размеров
        int[] coeffs1 = { 1, 2 }; // Размер 2x2
        int[] coeffs2 = { 1, 2, 3, 4 }; // Размер 4x4
        int[] coeffs3 = { 1, 2, 3, 4, 5, 6, 7 }; // Размер 7x7

        // Создание объектов циркулянтных матриц разных размеров
        CirculantMatrix matrix1 = new CirculantMatrix(coeffs1);
        CirculantMatrix matrix2 = new CirculantMatrix(coeffs2);
        CirculantMatrix matrix3 = new CirculantMatrix(coeffs3);

        // Отображение циркулянтных матриц разных размеров
        Console.WriteLine("Блоки циркулянтной матрицы 1:");
        Console.WriteLine(matrix1.GetMatrixString());

        Console.WriteLine("Блоки циркулянтной матрицы 2:");
        Console.WriteLine(matrix2.GetMatrixString());

        Console.WriteLine("Блоки циркулянтной матрицы 3:");
        Console.WriteLine(matrix3.GetMatrixString());
    }
}

/*
public class CirculantMatrix
{
    private int[] coefficients;

    // Constructor to initialize the circulant matrix coefficients
    public CirculantMatrix(int[] coeffs)
    {
        this.coefficients = coeffs;
    }

    // Method to generate a string representation of the circulant matrix
    public string GetMatrixString()
    {
        int n = this.coefficients.Length;
        StringBuilder matrixString = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int index = (i - j + n) % n;
                matrixString.Append(this.coefficients[index] + " ");
            }
            matrixString.Append(Environment.NewLine);
        }

        return matrixString.ToString();
    }

    // Encrypt a plaintext message using the circulant matrix
    public string Encrypt(string plaintext)
    {
        int n = this.coefficients.Length;
        int len = plaintext.Length;
        StringBuilder ciphertext = new StringBuilder(len);

        for (int i = 0; i < len; i++)
        {
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                int k = (i - j + len) % len;
                int charValue = (int)plaintext[k];
                sum += this.coefficients[j] * charValue;
            }
            char encryptedChar = (char)((sum % 256 + 256) % 256); // Ensure result is within ASCII range
            ciphertext.Append(encryptedChar);
        }

        return ciphertext.ToString();
    }

    // Decrypt a ciphertext message using the circulant matrix
    public string Decrypt(string ciphertext)
    {
        int n = this.coefficients.Length;
        int len = ciphertext.Length;
        StringBuilder plaintext = new StringBuilder(len);

        for (int i = 0; i < len; i++)
        {
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                int k = (i - j + len) % len;
                int charValue = (int)ciphertext[k];
                sum += this.coefficients[(n - j) % n] * charValue;
            }
            char decryptedChar = (char)((sum % 256 + 256) % 256); // Ensure result is within ASCII range
            plaintext.Append(decryptedChar);
        }

        return plaintext.ToString();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Define a circulant matrix coefficients (example)
        int[] coeffs = { 3, 1, 4, 6, 8, 9}; // Example coefficients

        // Create a circulant matrix object
        CirculantMatrix matrix = new CirculantMatrix(coeffs);

        // Display the circulant matrix in the console
        Console.WriteLine("Circulant Matrix:");
        Console.WriteLine(matrix.GetMatrixString());

        // Define a plaintext message
        string plaintext = "Hello";

        // Display the plaintext message
        Console.WriteLine("Plaintext: " + plaintext);

        // Encrypt the plaintext message using the circulant matrix
        string encrypted = matrix.Encrypt(plaintext);
        Console.WriteLine("Encrypted: " + encrypted);

        // Decrypt the ciphertext message using the same circulant matrix
        string decrypted = matrix.Decrypt(encrypted);
        Console.WriteLine("Decrypted: " + decrypted);

        // Compare the decrypted message with the original plaintext
        if (plaintext == decrypted)
        {
            Console.WriteLine("Encryption and decryption successful!");
        }
        else
        {
            Console.WriteLine("Encryption or decryption failed.");
        }
    }
}*/