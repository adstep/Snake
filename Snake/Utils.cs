using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Utils
    {

        // http://buiba.blogspot.com/2009/06/copy-c-keyedcollection-list-or.html
        public unsafe static List<T> CopyList<T>(List<T> src) {
            object osrc = src;
            TList* psrc = (TList*)(*((int*)&psrc + 1));
            object srcArray = null;
            object dstArray = null;
            int* i = (int*)&i;

            i[2] = (int)psrc->_01_items;

            int capacity = (srcArray as Array).Length;
            List<T> dst = new List<T>(capacity);
            TList* pdst = (TList*)(*((int*)&pdst + 1));
            i[1] = (int)pdst->_01_items;

            Array.Copy(srcArray as Array, dstArray as Array, capacity);

            pdst->_03_size = psrc->_03_size;

            return dst;
        }

        public static bool IsOpposite(Direction d1, Direction d2)
        {
            
            return (((d2 - d1) + ((d2 - d1) >> 31)) ^ ((d2 - d1) >> 31)) == 1;
        }

        public static bool IsCellFree(Point p, SnakeBody snakeBody)
        {
            return p.IsInbounds() && snakeBody.BodySet
        }


    }

    struct TList
    {
        public uint _00_MethodInfo; //
        public uint _01_items;      // * T[] 
        public uint _02_syncRoot;   //   object
        public int _03_size;        // *
        public int _04_version;     //
    }
}
