using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace VideoDownloadHelper.Helper
{
    public class WordHelper
    {
        public static string CutWordByKeyword(string word, string firstKeyword, string secondKeyword)
        {
            string temp;
            int start, over;
            temp = word.ToLower();
            firstKeyword = firstKeyword.ToLower();
            secondKeyword = secondKeyword.ToLower();

            start = temp.IndexOf(firstKeyword) + firstKeyword.Length;
            temp = temp.Substring(start);

            over = temp.IndexOf(secondKeyword);
            temp = temp.Substring(0, over);

            return temp;
        }

        public static string CutWordByKeyword(string word, string firstKeyword)
        {
            string temp;
            int start;
            temp = word.ToLower();
            firstKeyword = firstKeyword.ToLower();

            start = temp.IndexOf(firstKeyword) + firstKeyword.Length;
            temp = temp.Substring(start);

            return temp;
        }
        /// <summary>
        /// 获取批量文本数据
        /// </summary>
        /// <param name="source">源文本</param>
        /// <param name="keyWord1">关键词1</param>
        /// <param name="keyWord2">关键词2</param>
        /// <returns>所需数据（数组）</returns>
        public static string[] GetWords(string source, string keyWord1, string keyWord2)
        {
            ArrayList arrayList = new ArrayList();
            int x = source.IndexOf(keyWord1);
            while (source.IndexOf(keyWord1) != -1)
            {
                arrayList.Add(CutWordByKeyword(source, keyWord1, keyWord2));
                int k2 = source.IndexOf(keyWord2, x);
                int l2 = keyWord2.Length;
                source = source.Substring(k2 + keyWord2.Length);
            }
            string[] returnValue = new string[arrayList.Count];
            for (int i = 0; i < arrayList.Count; i++)
            {
                returnValue[i] = arrayList[i].ToString();
            }
            return returnValue;
        }
    }
}
