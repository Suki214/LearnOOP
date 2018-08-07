using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsWithCommandPattern
{
    public interface IGraphicsCommand
    {
        void Draw();
        void Undo();
    }
}
