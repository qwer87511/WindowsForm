using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DrawingModel
{
    public class ShapeFactory
    {
        public ShapeFactory()
        {
        }

        // 使用type名產生instance
        public Shape CreateShape(string namespaceName, string typeName)
        {
            const char DOT = '.';
            if (namespaceName != string.Empty)
                typeName = namespaceName + DOT + typeName;
            Type type = Type.GetType(typeName);
            if (type == null)
                throw new Exception();
            Shape shape = (Shape)Activator.CreateInstance(type);
            if (shape == null)
                throw new Exception();
            return shape;
        }
    }
}
