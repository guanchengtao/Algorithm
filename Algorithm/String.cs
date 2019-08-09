using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class String
    {
        public static int LongestSubstringWithoutDuplication(string s)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            int res = 0;
            for (int i = 0, j = 0; j < s.Length; j++)
            {
                //aabb
                if(!count.ContainsKey(s[j]))  count[s[j]] = 1;
                else  count[s[j]]++;
                if (count[s[j]] > 1)
                {
                    while (count[s[i]] == 1)
                    {
                        count[s[i]]--; //把两个相同字符之间的值置零
                        i++;
                    }
                    count[s[i++]]--;
                }
                res = Math.Max(res, j - i + 1);
            }
            return res;
        }
    }
}
