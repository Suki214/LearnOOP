using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsWithCommandPattern
{
    public class Graphics
    {
        private Stack<IGraphicsCommand> commands = new Stack<IGraphicsCommand>();

        public void Draw(IGraphicsCommand command)
        {
            command.Draw();
            commands.Push(command);
        }

        public void Undo()
        {
            IGraphicsCommand command = commands.Pop();
            command.Undo();
        }
    }
}
