using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace auto
{
    public class HashTable
    {
        private const int size = 101;
        private List<IdentifierInfo>[] table;
        private int Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return -1;

            // Константа Кнута — часть золотого сечения ≈ 0.6180339887
            double A = (Math.Sqrt(5) - 1) / 2;

            // Преобразуем строку в числовой ключ (сумма кодов символов)
            ulong key = 0;
            foreach (char c in value)
            {
                key = key * 31 + c;
                key %= int.MaxValue;
            }

            // Мультипликативная хеш-функция
            double fractional = (key * A) % 1; // берём только дробную часть
            int index = (int)(size * fractional);

            return index;
        }
        public HashTable()
        {
            table = new List<IdentifierInfo>[size];
            for (int i = 0; i < size; i++)
                table[i] = new List<IdentifierInfo>();
        }
        public bool Insert(IdentifierInfo value)
        {
            int index = Hash(value.Name);
            if (index < 0) return false;
            foreach (IdentifierInfo el in table[index])
                if (el.Name == value.Name) return false;


            table[index].Add(value);
            return true;
        }
        public void Edit(string name, bool data)
        {
            int index = Hash(name);
            if (index < 0) return;
            for (int i = 0; i < table[index].Count; ++i)
            {
                if (table[index][i].Name == name)
                {
                    table[index][i].Value = data;
                    break;
                }
            }
        }
        public void Remove(string value)
        {
            int index = Hash(value);
            if (index < 0) return;
            for (int i = 0; i < table[index].Count; ++i)
            {
                if (table[index][i].Name == value)
                {
                    table[index].Remove(table[index][i]);
                    break;
                }
            }
        }
        public IdentifierInfo Get(string value)
        {
            int index = Hash(value);
            if (index < 0) return null;
            foreach (IdentifierInfo el in table[index])
                if (el.Name == value) return el;
            return null;
        }
        public void Clear()
        {
            for (int i = 0; i < table.Length; ++i)
                table[i] = new List<IdentifierInfo>();
        }
    }
}
