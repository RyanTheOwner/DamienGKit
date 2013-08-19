using System;
using System.IO;
using System.Text;

namespace DamienG.IO
{
    /// <summary>
    /// A TextWriter that can delegate the writing to any Action that takes a string.
    /// </summary>
    public class ActionTextWriter : TextWriter
    {
        private readonly Action<string> action;

        public ActionTextWriter(Action<string> action)
        {
            this.action = action;
        }

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Write(new string(buffer, index, count));
        }

        public override void Write(string value)
        {
            action(value);
        }
    }
}