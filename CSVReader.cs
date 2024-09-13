using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

namespace CSVTools
{
    /// <summary>
    /// A simple CSV reader class that reads the data from a CSV file and returns a list of list of strings readed.
    /// It uses a Singleton pattern to ensure that only one instance of the class is instantiated on gameplay.
    /// -------------------------------------
    /// USAGE:
    ///     using CSVTools;
    ///     ...
    ///      CSVReader.Instance.SetFieldSeperator(',');
    ///      List<List<string>> data = CSVReader.Instance.ReadData("Folder on Resources Folder", "FileName without extension");
    ///      for (int i = 1; i < data.Count - 1; i++) {
    ///         ...
    ///      }
    /// -------------------------------------     
    /// 
    /// easy duno?
    /// 
    /// </summary>
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

        /// <summary>
        /// Sets the line break character. Default is '\n'
        /// </summary>
        /// <param name="breaker"></param>
        public void SetLineBreak(char breaker)
        {
            lineBreak = breaker;
        }

        /// <summary>
        /// Sets the field seperator character. Default is ';'
        /// </summary>
        /// <param name="seperator"></param>
        public void SetFieldSeperator(char seperator)
        {
            fieldSeperator = seperator;
        }

        /// <summary>
        /// Reads the data from the file and returns a list of list of strings.
        /// - "path" is the directory where the file to read is located. Relative path to the Resources directory. 
        /// e.g. "CSV" is the "Assets/Resources/CSV" path in the Unity project.
        /// 
        /// - "filename" does not require the extension.
        /// 
        /// </summary>
        /// <param name="path">The directory where the file to read is located. Relative path to the Resources directory. 
        /// e.g. "CSV" is the "Assets/Resources/CSV" path in the Unity project.
        /// </param>
        /// <param name="filename">Name of the file, extension is not required.</param>
        /// <returns></returns>
        public List<List<string>> ReadData(string path, string filename)
        {
            List<List<string>> result = new List<List<string>>();
            try
            {
                //Filename has extension?
                if (filename.Contains("."))
                    filename = filename.Substring(0, filename.LastIndexOf('.'));

                string fullpath = path + "/" + filename;
                TextAsset csvFile = Resources.Load<TextAsset>(fullpath);
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

        /// <summary>
        /// TODO: NOT IMPLEMENTED YET.
        /// 
        /// Appends data to the file. If the file does not exist, it creates it.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="values"></param>
        public void AppendData(string path, string filename, List<string> values)
        {
            
        }

    }
}