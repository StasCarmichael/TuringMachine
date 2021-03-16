using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineWinForms
{
    class TuringMachine
    {
        private List<char> myList;
        private Dictionary<char, int> myDictionary;
        private MachineHead[,] machineHeads;

        public int startState { get; protected set; }
        public int startIndex { get; protected set; }
        public bool download { get; protected set; }

        public TuringMachine() { startState = 0; startIndex = 1; }


        public string StartMachine()
        {
            startState = 0; 
            startIndex = 1;


            char tempChar;
            int tempValue;

            while (startState != -1)
            {
                tempChar = myList[startIndex];


                if (myDictionary.TryGetValue(tempChar, out tempValue))
                {
                    MachineHead myMachineHead = machineHeads[startState, tempValue];

                    myList[startIndex] = myMachineHead.letter;

                    switch (myMachineHead.direction)
                    {
                        case -1:
                            startIndex--; break;

                        case 0:
                            break;

                        case 1:
                            startIndex++; break;


                        default:
                            new Exception("Machine Error"); break;
                    }

                    startState = myMachineHead.state;
                }

                if (startIndex == -1)
                {
                    myList.Insert(0, '#');
                    startIndex = 0;
                }
                else if (startIndex == myList.Count)
                {
                    myList.Add('#');
                }


            }


            string str = "";
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] != '#')
                {
                    str += myList[i];
                }
            }
            return str;

        }


        public void CreateList(string str)
        {
            myList = new List<char>(0);
            myList.Add('#');
            for (int i = 0; i < (str?.Length ?? 0); i++)
            {
                if (myDictionary.ContainsKey(str[i])) { myList.Add(str[i]); }
            }
            myList.Add('#');
        }


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
            catch (Exception )
            {
                throw new Exception("Неправилно введені дані з txt документу\nПеревірка їх коректність!!!");
            }
        }
    }
}
