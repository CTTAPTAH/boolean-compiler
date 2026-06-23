using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    public class SyntaxTree
    {
        public Node Root;
        public class Node
        {
            public Token Token { get; set; }
            public List<Node> Children { get; set; }
            public Node(Token token)
            {
                Token = token;
                Children = new List<Node>();
            }
        }
        public SyntaxTree()
        {
            Root = new Node(new Token("root", "root", -1));
        }
        public void Clear()
        {
            ClearNode(Root);
        }

        private void ClearNode(Node node)
        {
            if (node == null) return;

            // Рекурсивно очищаем всех потомков
            foreach (var child in node.Children)
            {
                ClearNode(child);
            }

            // После очистки подузлов — очищаем список
            node.Children.Clear();
        }
    }
}
