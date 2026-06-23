using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace auto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Данные
        private FormCode formCode;
        private List<Token> _tokens = new List<Token>();
        private string currentIdentifier = null; // храним временно имя переменной для определения объявления/инициализации
        private HashTable hashTable = new HashTable();
        SyntaxTree logicTree = new SyntaxTree(); // Наше дерево для вычислений в ассемблере
        enum State { Expr, Ex1, Ex2, ExLL, ExLetter1, Ex3, F }
        // Словарь приоритетов операций
        private const int MaxPriority = 4;
        private Dictionary<string, int> OperatorPriority = new Dictionary<string, int>
        {
            { "not", 3 }, // наивысший приоритет
            { "and", 2 },
            { "or", 1 },
            { "xor", 1 },
            { ":=", 0 } // присваивание самый низкий приоритет
        };
        private int GetPriority(Token token)
        {
            if (OperatorPriority.TryGetValue(token.Name, out int priority))
                return priority;
            return MaxPriority; // идентификаторы, числа, ";", "end" - самый высокий приоритет
        }

        // Построение синтаксического дерева
        private void CreateTree()
        {
            // Формируем временный список и отправляем в парсер
            List<Token> tokensList = new List<Token>(); // будем отправлять список вида [token1, token2, ... , ";"]
            foreach (Token token in _tokens)
            {
                // Если встретили разделитель выражения (; или end), то отправляем сформировавшийся список
                if (token.Name == ";" || token.Name == "end")
                {
                    // Отправляем всё, кроме ; или end
                    if (tokensList.Count > 0)
                        QuickParse(tokensList, 0, tokensList.Count - 1, logicTree.Root);

                    tokensList.Clear();

                    // Добавляем ; или end как отдельный узел верхнего уровня
                    logicTree.Root.Children.Add(new SyntaxTree.Node(token));
                }
                // Продолжаем накапливать токены текущего выражения
                else
                    tokensList.Add(token);
            }
        }
        private int Partition(List<Token> tokens, int low, int high)
        {
            // Находим лексему с меньшим приоритетом
            int low_token_idx = low;
            int low_priority = GetPriority(tokens[low]);
            for (int i = low + 1; i <= high; ++i)
            {
                int priority = GetPriority(tokens[i]);
                if (priority <= low_priority)
                {
                    low_priority = priority;
                    low_token_idx = i;
                }
            }
            return low_token_idx;
        }
        private void QuickParse(List<Token> tokens, int low, int high, SyntaxTree.Node currentLogicNode)
        {
            if (low > high) return;

            // Находим элемент с меньшим приоритетом (он станет корнем поддерева)
            int idx_pi = Partition(tokens, low, high);
            Token rootToken = tokens[idx_pi];

            // Добавляем узел в логическое дерево
            var newLogicNode = new SyntaxTree.Node(rootToken);
            if (rootToken.Type == "OPERATOR" && rootToken.Name != ":=") currentLogicNode.Children.Insert(0, newLogicNode); // вставляем в начало. Оператор должен быть на 0 позиции в дереве
            else currentLogicNode.Children.Add(newLogicNode); // вставляем в конец, если это логическое значение или переменная

            // Рекурсивно обрабатываем токены слева и справа
            if (rootToken.Name == ":=")
            {
                QuickParse(tokens, idx_pi + 1, high, newLogicNode);
                QuickParse(tokens, low, idx_pi - 1, newLogicNode);
            }
            else
            {
                QuickParse(tokens, low, idx_pi - 1, newLogicNode);
                QuickParse(tokens, idx_pi + 1, high, newLogicNode);
            }
        }
        // Генерация ассемблерного кода
        private void FillTreeView()
        {
            TreeNode rootNode = new TreeNode("root");
            treeViewSyntax.Nodes.Add(rootNode);
            foreach (var logicChild in logicTree.Root.Children)
                FillTreeViewRecursive(rootNode, logicChild);
            treeViewSyntax.ExpandAll();
        }
        private void FillTreeViewRecursive(TreeNode viewNode, SyntaxTree.Node syntaxNode)
        {
            if (syntaxNode == null)
                return;

            // Создаём узел для текущего токена
            TreeNode currentNode = new TreeNode(syntaxNode.Token.Name);

            // Добавляем узел в коллекцию
            viewNode.Nodes.Add(currentNode);

            // Рекурсивно добавляем дочерние узлы
            foreach (var child in syntaxNode.Children)
            {
                FillTreeViewRecursive(currentNode, child);
            }
        }
        private void Optimize()
        {
            logicTree.Root = OptimizeRecursive(logicTree.Root);
        }
        private SyntaxTree.Node OptimizeRecursive(SyntaxTree.Node node)
        {
            if (node == null)
                return null;

            // Сначала оптимизируем потомков
            for (int i = 0; i < node.Children.Count; i++)
                node.Children[i] = OptimizeRecursive(node.Children[i]);

            // Далее идут сами правила
            string op = node.Token.Name;

            if (op == "and")
            {
                // Упрощения вроде "A and 1" → "A" и "A and 0" → "0"
                if (node.Children[1].Token.Name == "1") return node.Children[0];
                if (node.Children[0].Token.Name == "1") return node.Children[1];
                if (node.Children[1].Token.Name == "0") return node.Children[1];
                if (node.Children[0].Token.Name == "0") return node.Children[0];
            }
            else if (op == "or")
            {
                // Упрощения вроде "A or 1" → "1" и "A or 0" → "A"
                if (node.Children[1].Token.Name == "0") return node.Children[0];
                if (node.Children[0].Token.Name == "0") return node.Children[1];
                if (node.Children[1].Token.Name == "1") return node.Children[1];
                if (node.Children[0].Token.Name == "1") return node.Children[0];
            }
            else if (op == "xor")
            {
                // Упрощения вроде "A xor 0" → "A"
                if (node.Children[1].Token.Name == "0") return node.Children[0];
                if (node.Children[0].Token.Name == "0") return node.Children[1];
            }

            return node;
        }
        private string GenerateAsm(SyntaxTree.Node node, string register)
        {
            string token = node.Token.Name;
            int count_children = node.Children.Count;

            if (node == null || token == ";" || token == "end") return "";

            if (token == "root")
            {
                // Проходимся по корню
                string result = "";
                for (int i = 0; i < count_children; ++i)
                {
                    result += GenerateAsm(node.Children[i], "al");
                    if (node.Children[i].Token.Name == ";") result += "\n";
                }   
                return result;
            }
            // Лист — переменная или значение
            if (count_children == 0)
            {
                return $"mov {register}, {token}\n";
            }
            // Унарная операция
            if (count_children == 1)
            {
                if (token == "not")
                {
                    string childCode = GenerateAsm(node.Children[0], "al");
                    return childCode + "not al\n";
                }
            }
            // Бинарная операция
            if (count_children == 2)
            {
                string reg1 = (register == "al") ? "al" : "cl";

                if (token == ":=" && node.Children[0].Children.Count == 0)
                {
                    return $"mov {node.Children[1].Token.Name}, {node.Children[0].Token.Name}\n";
                }

                if (node.Children[1].Token.Type != "OPERATOR")
                {
                    string leftCode = GenerateAsm(node.Children[0], reg1);
                    string operation = "";

                    switch (token)
                    {
                        case "and": operation = $"and {reg1}, {node.Children[1].Token.Name}"; break;
                        case "or": operation = $"or {reg1}, {node.Children[1].Token.Name}"; break;
                        case "xor": operation = $"xor {reg1}, {node.Children[1].Token.Name}"; break;
                        case ":=": operation = $"mov {node.Children[1].Token.Name}, {reg1}"; break;
                        default: operation = $"; неизвестная операция {operation}"; break;
                    }
                    return leftCode + operation + "\n";
                }
                else
                {
                    string leftCode = GenerateAsm(node.Children[0], "cl");
                    string rightCode = "";
                    if (token != ":=") rightCode = GenerateAsm(node.Children[1], "al");
                    string operation = "";

                    switch (token)
                    {
                        case "and": operation = $"and al, cl"; break;
                        case "or": operation = $"or al, cl"; break;
                        case "xor": operation = $"xor al, cl"; break;
                        case ":=": operation = $"mov {node.Children[1].Token.Name}, al"; break;
                        default: operation = $"; неизвестная операция {operation}"; break;
                    }
                    return rightCode + leftCode + operation + "\n";
                }
            }
            return "";
        }

        // Методы
        private void AddToken(string name, string type, int line)
        {
            _tokens.Add(new Token(name, type, line));
        }
        private bool OnlyLatinLetters(string s)
        {
            return Regex.IsMatch(s, @"^[A-Za-z]+$");
        }
        private void Error(string message, int line)
        {
            MessageBox.Show($"Ошибка в строке {line}: {message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ResetState()
        {
            _tokens.Clear();
            hashTable.Clear();
            currentIdentifier = null;
            listViewTable.Items.Clear();
            treeViewSyntax.Nodes.Clear();
            logicTree.Clear();
        }
        private bool CheckIdentifierUsage(string name, int line)
        {
            var info = hashTable.Get(name);
            if (info == null)
            {
                Error($"Использование необъявленной переменной \"{name}\"", line);
                return false;
            }
            else if (info.LineInitialized < 0)
            {
                Error($"Переменная \"{name}\" используется до инициализации (объявлена в строке {info.LineDeclared})", line);
                return false;
            }

            info.IsUsed = true;
            return true;
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            ResetState();
            State state = State.Expr;
            string[] lines = richTextBoxCode.Lines;
            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue; // Проверка на пустую строку

                var words = Regex.Matches(line, @"[a-zA-Z]+|:=|[0-1]|;|[^\s]")
                 .Cast<Match>() // преобразуем MatchCollection → IEnumerable<Match>
                 .Select(m => m.Value) // берём из каждого Match его текст
                 .ToArray(); // получаем string[]
                foreach (string word in words)
                {
                    switch (state)
                    {
                        case State.Expr:
                            if (word == "end")
                            {
                                AddToken(word, "KEYWORD", i + 1);
                                currentIdentifier = word;
                                state = State.F;
                            }
                            else if (OnlyLatinLetters(word))
                            {
                                AddToken(word, "IDENTIFIER", i + 1);
                                currentIdentifier = word;
                                state = State.Ex1;
                            }
                            else
                            {
                                Error($"Ожидалось \"end\" или слово, состоящее из латинских букв. Введено: {word}", i + 1);
                                state = State.F;
                            }
                            break;
                        case State.Ex1:
                            if (word == ":=")
                            {
                                AddToken(word, "OPERATOR", i + 1);
                                // инициализация, добавляем в таблицу, если ещё нет
                                if (hashTable.Get(currentIdentifier) == null)
                                    hashTable.Insert(new IdentifierInfo(currentIdentifier, i + 1, i + 1));
                                else
                                {
                                    // если переменная уже есть, то просто обновим инициализацию
                                    hashTable.Edit(currentIdentifier, true);
                                    hashTable.Get(currentIdentifier).LineInitialized = i + 1;
                                }
                                state = State.Ex2;
                            }
                            else if (word == ";")
                            {
                                AddToken(word, "DELIMITER", i + 1);
                                // объявление
                                if (hashTable.Get(currentIdentifier) == null)
                                    hashTable.Insert(new IdentifierInfo(currentIdentifier, i + 1));
                                else
                                {
                                    Error($"Переменная {currentIdentifier} уже объявлена в строке {hashTable.Get(currentIdentifier).LineDeclared}. Нельзя её объявить снова", i + 1);
                                    state = State.F;
                                }
                                state = State.Expr;
                            }
                            else
                            {
                                Error($"Ожидалось \":=\". Введено: {word}", i + 1);
                                state = State.F;
                            }
                            break;
                        case State.Ex2:
                            if (word == "not")
                            {
                                AddToken(word, "OPERATOR", i + 1);
                                state = State.ExLL;
                            }
                            else if (word == "0" || word == "1")
                            {
                                AddToken(word, "NUMBER", i + 1);
                                state = State.Ex3;
                            }
                            else if (OnlyLatinLetters(word))
                            {
                                AddToken(word, "IDENTIFIER", i + 1);

                                // проверка на объявление/инициализацию переменной
                                if (!CheckIdentifierUsage(word, i + 1))
                                {
                                    state = State.F;
                                    break;
                                }

                                state = State.ExLetter1;
                            }
                            else
                            {
                                state = State.F;
                                Error($"Ожидалось \"not\", \"[0-1]\" или слово, состоящее из латинских букв. Введено: {word}", i + 1);
                            }
                            break;
                        case State.ExLL:
                            if (word == "0" || word == "1")
                            {
                                AddToken(word, "NUMBER", i + 1);
                                state = State.Ex3;
                            }
                            else if (OnlyLatinLetters(word))
                            {
                                AddToken(word, "IDENTIFIER", i + 1);

                                // проверка на объявление/инициализацию переменной
                                if (!CheckIdentifierUsage(word, i + 1))
                                {
                                    state = State.F;
                                    break;
                                }

                                state = State.ExLetter1;
                            }
                            else
                            {
                                Error($"Ожидалось \"[0-1]\" или слово, состоящее из латинских букв. Введено: {word}", i + 1);
                                state = State.F;
                            }
                            break;
                        case State.ExLetter1:
                            if (word == ";")
                            {
                                AddToken(word, "DELIMITER", i + 1);
                                state = State.Expr;
                            }
                            else if (word == "or" || word == "xor" || word == "and")
                            {
                                AddToken(word, "OPERATOR", i + 1);
                                state = State.Ex2;
                            }
                            else
                            {
                                Error($"Ожидалось \";\", \"or\", \"xor\" или \"and\". Введено: {word}", i + 1);
                                state = State.F;
                            }
                            break;
                        case State.Ex3:
                            if (word == ";")
                            {
                                AddToken(word, "DELIMITER", i + 1);
                                state = State.Expr;
                            }
                            else if (word == "or" || word == "xor" || word == "and")
                            {
                                AddToken(word, "OPERATOR", i + 1);
                                state = State.Ex2;
                            }
                            else
                            {
                                Error($"Ожидалось \";\", \"or\", \"xor\" или \"and\". Введено: {word}", i + 1);
                                state = State.F;
                            }
                            break;
                        case State.F:
                            break;
                    }
                }
                if (state == State.F)
                    break;
            }
            if (state != State.F)
                Error("Нет завершающего символа end", lines.Length);
            // После обработки ввода формируем таблицу
            foreach (var token in _tokens)
            {
                var item = new ListViewItem(token.Name);
                item.SubItems.Add(token.Type);
                item.SubItems.Add(token.Line.ToString());

                listViewTable.Items.Add(item);
            }

            // Формируем дерево
            CreateTree();
            Optimize();
            FillTreeView();

            // Формируем ассемблерный код
            string asm_code = GenerateAsm(logicTree.Root, "");
            richTextBoxAsmCode.Text = asm_code;
            richTextBoxAsmCodeMain.Text = asm_code;
        }

        private void buttonWindowCode_Click(object sender, EventArgs e)
        {
            // Если форма уже открыта и не закрыта — просто обновляем текст
            if (formCode != null && !formCode.IsDisposed)
            {
                formCode.SetCode(richTextBoxCode.Text, richTextBoxAsmCode.Text);
                formCode.BringToFront(); // делает окно активным
            }
            else
            {
                // Если формы нет — создаём новую
                formCode = new FormCode();
                formCode.SetCode(richTextBoxCode.Text, richTextBoxAsmCode.Text);
                formCode.Show();
            }
        }
    }
}
