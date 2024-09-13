using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

namespace CSVTools
{
    public class CSVReader : MonoBehaviour
    {
        private CSVReader() { }
        private static CSVReader instance = null;
        public static CSVReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CSVReader();
                }
                return instance;
            }
        }

        private char lineBreak = '\n';
        private char fieldSeperator = ';';

        public void SetLineBreak(char seperator)
        {
            lineBreak = seperator;
        }

        public void SetFieldSeperator(char seperator)
        {
            fieldSeperator = seperator;
        }

        public List<List<string>> ReadData(string path, string filename)
        {
            List<List<string>> result = new List<List<string>>();
            try
            {
                TextAsset csvFile = Resources.Load<TextAsset>(filename);
                string[] lines = csvFile.text.Split(lineBreak);

                foreach (string line in lines)
                {
                    List<string> row = new List<string>();
                    string[] items = line.Split(fieldSeperator);
                    foreach (string item in items)
                        row.Add(item);

                    result.Add(row);
                }

            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                Debug.LogError("Problem reading content");

            }
            return result;
        }

        public void AppendData(string path, string filename, List<string> values)
        {
            
        }

    }
}