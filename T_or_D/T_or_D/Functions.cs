using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace T_or_D
{
    class Functions
    {
        public int returnRandom(int _x)
        {
            int x = _x;
            int y = new Random().Next(0, x + 1);
            return y;
        }

        public List<string> Add(List<string> _list, string _user)
        {
            _list.Add(_user);
            return _list;
        }

        public string RandomUser(List<string> _list)
        {
            int y = new Random().Next(0, _list.Count + 1);
            if (y != 0)
            {
                return _list[y - 1];
            }
            else
            {
                return _list[y];
            }
        }
        public List<string> complete(List<string> _custom, List<string> _complete)
        {
            int customSize = _custom.Count;

            int needed = 20 - customSize;

            for (int i = 0; i < needed; i++)
            {
                int y = new Random().Next(0, _complete.Count + 1);
                _custom.Add(_complete[y]);
            }
            return _complete;
        }
        public string[] complete(string[] _custom, string[] _complete)
        {
            int customSize = _custom.Length;

            int needed = 20 - customSize;

            for (int i = 0; i < needed; i++)
            {
                int y = new Random().Next(0, _complete.Length + 1);
                _custom.Append(_complete[y]);
            }
            return _complete;
        }
    }
}
