using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineWinForms
{
    public class TuringMachine
    {
        //Вхідні дані
        private List<char> myList;
        //Алфавіт машини + звязок символа з індексом
        private Dictionary<char, int> myDictionary;
        //Матриця команд для машини
        private MachineHead[,] machineHeads;

        //Моя матриця в текстовфй формі
        public string[] myData { get; set; }


        #region MachineHeadClass

        protected enum eDirection { L = -1, N = 0, R = 1 };

        protected class MachineHead
        {
            //Літера
            public char letter { get; set; }
            //Напрямок переміщення для головки
            public eDirection direction { get; set; }
            //Стан головки
            public int state { get; set; }


            //Парсер для строки
            public MachineHead(string str)
            {
                try
                {
                    string[] elementArray = str.Split(',');


                    letter = Convert.ToChar(elementArray[0]);

                    switch (Convert.ToChar(elementArray[1]))
                    {
                        case 'L':
                            direction = eDirection.L; break;

                        case 'N':
                            direction = eDirection.N; break;

                        case 'R':
                            direction = eDirection.R; break;


                        default:
                            new Exception("System Error"); break;
                    }

                    state = Convert.ToInt32(elementArray[2]);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Convert Error" + ex.Message);
                }
            }

        }
        #endregion


        public int startState { get; protected set; }
        public int startIndex { get; protected set; }
        public bool download { get; protected set; }


        //Ctor
        public TuringMachine() { startState = 0; startIndex = 1; myData = new string[0]; }


        //Запуст машини
        public string StartMachine()
        {
            startState = 1;
            startIndex = 1;

            int addCounter = 0;
            char tempChar;
            int tempValue;

            while (startState != -1)
            {
                tempChar = myList[startIndex];


                if (myDictionary.TryGetValue(tempChar, out tempValue))
                {
                    MachineHead myMachineHead = machineHeads[startState - 1, tempValue];

                    myList[startIndex] = myMachineHead.letter;

                    switch (myMachineHead.direction)
                    {
                        case eDirection.L:
                            startIndex--; break;
                        case eDirection.N:
                            break;
                        case eDirection.R:
                            startIndex++; break;

                        default:
                            new Exception("Machine Error"); break;
                    }

                    startState = myMachineHead.state;
                }
                else { throw new Exception("Зустрівся незнайомий символ"); }


                //додавання безкінечного елемента
                if (startIndex == -1)
                {
                    myList.Insert(0, '^');
                    startIndex = 0;
                    addCounter++;
                }
                else if (startIndex == myList.Count)
                {
                    myList.Add('^');
                    addCounter++;
                }

                if (addCounter > 10000) { throw new Exception("Нескінчений цикл машини!!!\n Перевірте коректність алгоритму."); }
            }


            string str = string.Empty;
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] != '^') { str += myList[i]; }
            }
            return str;

        }


        //Створення вхідних даних
        public void CreateList(string str)
        {
            myList = new List<char>(0);
            myList.Add('^');

            bool tempProtect = false;
            bool addElProtect = false;

            for (int i = 0; i < (str?.Length ?? 0); i++)
            {
                if (str[i] == '^' && !tempProtect && !addElProtect) { myList.Add(str[i]); tempProtect = true; }
                else if (myDictionary.ContainsKey(str[i]) && !tempProtect && str[i] != '^')
                {
                    myList.Add(str[i]);
                    addElProtect = true;
                }
                else { throw new Exception("Перевірте коректність вводу даних !!!"); }
            }

            myList.Add('^');
        }


        //Завантаження матриці для роботи машини
        private void Preview(string path)
        {
            int counterRows = 0;
            int counterCols = 0;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] elementArray = line.Split('\t', ' ', '\n');


                    for (int index = 0; index < elementArray.Length; index++)
                    {
                        if (elementArray[index].Length != 0)
                        {
                            if (counterRows == 0) { counterCols++; }
                        }
                    }

                    counterRows++;
                }

                sr.Close();
            }


            machineHeads = new MachineHead[counterRows - 1, counterCols];

        }
        public void SetHeadCommand(string path)
        {
            try
            {
                Preview(path);

                int counterRows = -1;
                int counterCols = -1;

                //Add myData 
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    myData = sr.ReadToEnd().Split('\n');

                    sr.Close();
                }


                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] elementArray = line.Split('\t', ' ', '\n');
                        counterCols = -1;


                        if (counterRows == -1)
                        {
                            int dictionarySize = 0;

                            for (int index = 0; index < elementArray.Length; index++)
                            {
                                if (elementArray[index].Length != 0 && elementArray[index] != string.Empty)
                                {
                                    dictionarySize++;
                                }
                            }


                            myDictionary = new Dictionary<char, int>(dictionarySize);

                            int dictionryCount = 0;
                            for (int index = 0; index < elementArray.Length; index++)
                            {
                                if (elementArray[index].Length != 0 && elementArray[index] != string.Empty)
                                {
                                    myDictionary.Add((Convert.ToChar(elementArray[index])), dictionryCount);
                                    dictionryCount++;
                                }
                            }

                        }
                        else
                        {
                            for (int index = 0; index < elementArray.Length; index++)
                            {
                                if (elementArray[index].Length != 0 && elementArray[index] != string.Empty)
                                {
                                    if (counterCols == -1) { }
                                    else
                                    {
                                        machineHeads[counterRows, counterCols] = new MachineHead(elementArray[index]);
                                    }

                                    counterCols++;
                                }
                            }
                        }


                        counterRows++;
                    }

                    sr.Close();
                }

                download = true;
            }
            catch (Exception)
            {
                throw new Exception("Неправилно введені дані з txt документу\nПеревірка їх коректність!!!");
            }
        }


        private void PreviewOnFiele(string[] donwloadStr)
        {
            int counterRows = 0;
            int counterCols = 0;

            for (int i = 0; i < donwloadStr.Length; i++)
            {
                string[] elementArray = donwloadStr[i].Split('\t', ' ', '\n');


                for (int index = 0; index < elementArray.Length; index++)
                {
                    if (elementArray[index].Length != 0)
                    {
                        if (counterRows == 0) { counterCols++; }
                    }
                }

                counterRows++;
            }

            machineHeads = new MachineHead[counterRows - 1, counterCols];
        }
        public void DonwloadMatrix(string[] donwloadStr)
        {
            PreviewOnFiele(donwloadStr);

            myData = donwloadStr;


            int counterRows = -1;
            int counterCols = -1;


            for (int i = 0; i < donwloadStr.Length; i++)
            {
                string[] elementArray = donwloadStr[i].Split('\t', ' ', '\n');
                counterCols = -1;


                if (counterRows == -1)
                {
                    int dictionarySize = 0;

                    for (int index = 0; index < elementArray.Length; index++)
                    {
                        if (elementArray[index].Length != 0 && elementArray[index] != string.Empty)
                        {
                            dictionarySize++;
                        }
                    }


                    myDictionary = new Dictionary<char, int>(dictionarySize);

                    int dictionryCount = 0;
                    for (int index = 0; index < elementArray.Length; index++)
                    {
                        if (elementArray[index].Length != 0 && elementArray[index] != string.Empty)
                        {
                            myDictionary.Add((Convert.ToChar(elementArray[index])), dictionryCount);
                            dictionryCount++;
                        }
                    }

                }
                else
                {
                    for (int index = 0; index < elementArray.Length; index++)
                    {
                        if (elementArray[index].Length != 0 && elementArray[index] != string.Empty)
                        {
                            if (counterCols == -1) { }
                            else
                            {
                                machineHeads[counterRows, counterCols] = new MachineHead(elementArray[index]);
                            }

                            counterCols++;
                        }
                    }
                }


                counterRows++;
            }

            download = true;
        }

    }
}
