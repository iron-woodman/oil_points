using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;

namespace oil_points
{
    /// <summary>
    /// класс предназначен для создания документа word по заданному шаблону
    /// </summary>
    class WordHelper
    {
        private FileInfo _fileInfo;
        private string resultFolder = @"Отчеты";

        public WordHelper(string filename, string rootFolder)
        {
            if (!File.Exists(filename))
            {
                throw new ArgumentException("Файл не найден");
            }
            resultFolder = Path.Combine(rootFolder, resultFolder);
            if (!Directory.Exists(resultFolder))
            {
                Directory.CreateDirectory(resultFolder);
            }
            _fileInfo = new FileInfo(filename);
        }

        /// <summary>
        /// создать новый документ word по заданному шаблону и наполнить его данными
        /// </summary>
        /// <param name="items"></param>
        /// <param name="result_order_filename"></param>
        /// <returns></returns>
        internal bool Process(Dictionary<string, string> items, ref string result_order_filename)
        {

            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;
                app.Documents.Open(file);
                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(
                        FindText: missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace
                        );

                }

                Object newFileName = Path.Combine(resultFolder, DateTime.Now.ToString("yyyyMMdd HHmmss") + _fileInfo.Name);
                app.ActiveDocument.SaveAs(newFileName);
                app.ActiveDocument.Close();
                //возвращаем имя созданного файла приказа
                result_order_filename = newFileName.ToString();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (app != null)
                {
                    app.Quit();
                }
            }
        }


        /// <summary>
        /// открыть файл отчета
        /// </summary>
        /// <param name="file_name"></param>
        public void OpenReport(string file_name)
        {
            System.Diagnostics.Process.Start(file_name);
        }
    }
}
